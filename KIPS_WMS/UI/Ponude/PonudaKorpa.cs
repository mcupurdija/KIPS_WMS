using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using FileHelpers;
using KIPS_WMS.Data;
using KIPS_WMS.Model;
using KIPS_WMS.NAV_WS;
using KIPS_WMS.Web;
using KIPS_WMS.Properties;

namespace KIPS_WMS.UI.Ponude
{
    public partial class PonudaKorpa : Form
    {
        private readonly string _customerCode;
        private readonly string _customerName;
        private readonly int _isAuthenticated;
        private readonly string _quoteNo;
        private readonly KIPS_wms _ws = WebServiceFactory.GetWebService();
        private List<ItemQuoteModel> _quoteItems;

        private List<Object[]> _searchedItems;
        private Object _selectedItem;
        private bool _tableBasket = true;
        private bool _sent;

        public PonudaKorpa()
        {
            InitializeComponent();
        }

        public PonudaKorpa(string customerCode, string customerName, int isAuthenticated, string quoteNo,
            List<ItemQuoteModel> quoteItems)
        {
            InitializeComponent();

            _customerCode = customerCode;
            _customerName = customerName;
            _isAuthenticated = isAuthenticated;
            _quoteNo = quoteNo;
            _quoteItems = quoteItems;

            lKupac.Text = _customerCode != Utils.UnknownCustomerCode ? string.Format("{0} - {1}", _customerCode, _customerName) : Resources.NepoznatKupac;
            
            DisplayLines();
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);

            if (_quoteNo != String.Empty)
            {
                Text = _quoteNo;
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            if (_sent)
            {
                RegistryUtils.DeleteSavedQuoteData();
            }
            else
            {
                RegistryUtils.SaveQuoteHeader(new QuoteHeaderHelper(_quoteNo, _customerCode, _customerName, _isAuthenticated));
                RegistryUtils.SaveQuoteLines(_quoteItems);
            }
        }

        private void DisplayLines()
        {
            _tableBasket = true;
            bDodaj.Visible = false;
            listView1.BackColor = Color.LightYellow;

            listView1.Clear();
            listView1.View = View.Details;
            listView1.Columns.Add(Resources.Sifra, 120, HorizontalAlignment.Left);
            listView1.Columns.Add(Resources.NazivArtika, 250, HorizontalAlignment.Left);
            listView1.Columns.Add(Resources.Kolicina, 80, HorizontalAlignment.Center);
            listView1.Columns.Add(Resources.Jedinica, 80, HorizontalAlignment.Center);

            foreach (ItemQuoteModel item in _quoteItems)
            {
                var lvi = new ListViewItem(new[]
                {
                    item.ItemCode, item.ItemDescription, item.Quantity, item.UnitOfMeasureCode
                });
                listView1.Items.Add(lvi);
            }

            lUkupno.Text = string.Format(Resources.Ukupno + ": {0}", SumPrices());
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count != 1) return;

            int index = listView1.SelectedIndices[0];
            _selectedItem = _tableBasket ? (object) _quoteItems[index] : _searchedItems[index];
        }

        private void listView1_KeyUp(object sender, KeyEventArgs e)
        {
            if (listView1.SelectedIndices.Count == 1 && !_tableBasket && _selectedItem != null && e.KeyCode == Keys.Return)
            {
                ShowLinesForm(PonudaLinija.ItemState.New);
            }
        }

        private string SumPrices()
        {
            try
            {
                CultureInfo culture = Utils.GetLocalCulture();
                return
                    _quoteItems.Sum(item => decimal.Parse(item.UnitPriceWithDiscount, culture)*decimal.Parse(item.Quantity, culture))
                        .ToString("N", culture.NumberFormat);
            }
            catch (Exception)
            {
                return "0,00";
            }
        }

        private void tbPronadji_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter || tbPronadji.Text.Length < 3) return;

            _searchedItems = SQLiteHelper.multiRowQuery(DbStatements.FindItemsStatementBarcode,
                new object[] {tbPronadji.Text});
            if (_searchedItems.Count == 1)
            {
                ShowLinesForm(PonudaLinija.ItemState.New);
            }

            DisplaySearchResults(_searchedItems);
        }

        private void bPronadji_Click(object sender, EventArgs e)
        {
            if (tbPronadji.Text.Length < 3) return;

            _searchedItems = SQLiteHelper.multiRowQuery(DbStatements.FindItemsStatementComplete,
                new object[] {tbPronadji.Text});

            DisplaySearchResults(_searchedItems);
        }

        private void DisplaySearchResults(IEnumerable<object[]> data)
        {
            _tableBasket = false;
            bDodaj.Visible = true;
            listView1.BackColor = Color.White;

            listView1.Clear();
            listView1.View = View.Details;
            listView1.Columns.Add(Resources.Sifra, 120, HorizontalAlignment.Left);
            listView1.Columns.Add(Resources.NazivArtika, 250, HorizontalAlignment.Left);

            foreach (var item in data)
            {
                var lvi = new ListViewItem(new[]
                {
                    item[DatabaseModel.ItemDbModel.ItemCode].ToString(),
                    item[DatabaseModel.ItemDbModel.ItemDescription].ToString()
                });
                listView1.Items.Add(lvi);
            }

            if (listView1.Items.Count > 0)
            {
                listView1.Focus();
                listView1.Items[0].Selected = true;
            }
        }

        private void bResetuj_Click(object sender, EventArgs e)
        {
            DisplayLines();
            _selectedItem = null;
            tbPronadji.Text = "";
            tbPronadji.Focus();
        }

        private void ShowLinesForm(PonudaLinija.ItemState itemState)
        {
            var ponudaLinija = new PonudaLinija(_customerCode, _isAuthenticated, itemState, _quoteNo, _selectedItem,
                _quoteItems);
            DialogResult result = ponudaLinija.ShowDialog();

            if (result == DialogResult.OK)
            {
                _quoteItems = ponudaLinija.QuoteItems;
                DisplayLines();
            }
        }

        private void bDodaj_Click(object sender, EventArgs e)
        {
            if (!_tableBasket && _selectedItem != null)
            {
                ShowLinesForm(PonudaLinija.ItemState.New);
            }
            else
            {
                MessageBox.Show(Resources.OdaberiteArtikal, Resources.Greska);
            }
        }

        private void bIzmeniLiniju_Click(object sender, EventArgs e)
        {
            if (_tableBasket && _selectedItem is ItemQuoteModel)
            {
                ShowLinesForm(PonudaLinija.ItemState.Edit);
            }
            else
            {
                MessageBox.Show(Resources.OdaberiteLiniju, Resources.Greska);
            }
        }

        private void bObrisiLiniju_Click(object sender, EventArgs e)
        {
            if (_tableBasket && _selectedItem is ItemQuoteModel)
            {
                _quoteItems.Remove((ItemQuoteModel)_selectedItem);
                DisplayLines();
            }
            else
            {
                MessageBox.Show(Resources.OdaberiteLiniju, Resources.Greska);
            }
        }

        private void bUcitajNoveArtikle_Click(object sender, EventArgs e)
        {
            var loadingForm = new NoviArtikliDijalog();
            DialogResult result = loadingForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (tbPronadji.Text.Length < 3) return;

                _searchedItems = SQLiteHelper.multiRowQuery(DbStatements.FindItemsStatementComplete, new object[] { tbPronadji.Text });
                DisplaySearchResults(_searchedItems);
            }
        }

        private void bPosalji_Click(object sender, EventArgs e)
        {
            var stampaDijalog = new StampaDijalog();
            DialogResult result = stampaDijalog.ShowDialog();

            if (result == DialogResult.OK)
            {
                new Thread(() => SendQuote(stampaDijalog.PrintTypeSelected)).Start();
            }
        }

        private void SendQuote(int selectedPrintType)
        {
            try
            {
                Cursor.Current = Cursors.Default;

                string documentNo = _quoteNo;
                int status = 0;
                int creditLimit = 0;
                List<SendQuoteModel> quotes = _quoteItems.Select(item => new SendQuoteModel
                {
                    ItemCode = item.ItemCode,
                    ItemQuantity = item.Quantity,
                    UnitOfMeasureCode = item.UnitOfMeasureCode,
                    VariantCode = "",
                    WarehouseCode = "001"
                }).ToList();

                var engine = new FileHelperEngine(typeof (SendQuoteModel));
                string lines = engine.WriteString(quotes);

                _ws.SendQuote("1", "001", ref documentNo, _customerCode, _isAuthenticated, lines, ref status,
                    ref creditLimit);

                if (status == 1)
                {
                    var printHeader = new PrintHeaderModel
                    {
                        PrinterName = RegistryUtils.GetPrinterName(),
                        PrintType = selectedPrintType,
                        DocumentNo = documentNo,
                        DocumentDate = DateTime.Now.ToString("dd.MM.yyyy. HH:mm:ss"),
                        CustomerCode = _customerCode,
                        CustomerName = _customerName,
                        Total = SumPrices(),
                        Lines = _quoteItems.Select(item => new PrintLineModel
                        {
                            ItemCode = item.ItemCode,
                            ItemDescription = item.ItemDescription,
                            ItemQuantity = item.Quantity,
                            ItemPrice = item.UnitPriceWithDiscount
                        }).ToList()
                    };

                    if (selectedPrintType != Utils.PrintTypeIgnore)
                    {
                        PrintHelper.Print(printHeader);
                    }

                    Invoke(new EventHandler((sender, e) => DisplayResults(printHeader, creditLimit)));
                }
            }
            catch (Exception ex)
            {
                Utils.GeneralExceptionProcessing(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void DisplayResults(PrintHeaderModel printHeader, int creditLimit)
        {
            var slanjeDijalog = new SlanjeDijalog(printHeader, creditLimit);
            DialogResult result2 = slanjeDijalog.ShowDialog();

            if (result2 == DialogResult.OK)
            {
                _sent = true;
                Close();
            }
        }
    }
}