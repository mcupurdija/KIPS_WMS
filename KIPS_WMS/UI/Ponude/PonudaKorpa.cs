using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using FileHelpers;
using KIPS_WMS.Data;
using KIPS_WMS.Model;
using KIPS_WMS.NAV_WS;
using KIPS_WMS.Web;

namespace KIPS_WMS.UI.Ponude
{
    public partial class PonudaKorpa : Form
    {
        private readonly string _customerCode;
        private readonly int _isAuthenticated;
        private readonly string _quoteNo;
        private readonly KIPS_wms _ws = WebServiceFactory.GetWebService();
        private List<ItemQuoteModel> _quoteItems;

        private List<Object[]> _searchedItems;
        private Object _selectedItem;
        private bool _tableBasket = true;

        public PonudaKorpa()
        {
            InitializeComponent();
        }

        public PonudaKorpa(string customerCode, string customerName, int isAuthenticated, string quoteNo,
            List<ItemQuoteModel> quoteItems)
        {
            InitializeComponent();

            _customerCode = customerCode;
            _isAuthenticated = isAuthenticated;
            _quoteNo = quoteNo;
            _quoteItems = quoteItems;

            lKupac.Text = string.Format("{0} - {1}", _customerCode, customerName);
            DisplayLines();
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            Text = _quoteNo;
        }

        private void DisplayLines()
        {
            _tableBasket = true;
            bDodaj.Visible = false;
            listView1.BackColor = Color.LightYellow;

            listView1.Clear();
            listView1.View = View.Details;
            listView1.Columns.Add("Šifra", 120, HorizontalAlignment.Left);
            listView1.Columns.Add("Naziv artikla", 250, HorizontalAlignment.Left);
            listView1.Columns.Add("Količina", 80, HorizontalAlignment.Center);
            listView1.Columns.Add("Jedinica", 80, HorizontalAlignment.Center);

            foreach (ItemQuoteModel item in _quoteItems)
            {
                var lvi = new ListViewItem(new[]
                {
                    item.ItemCode, item.ItemDescription, item.Quantity, item.UnitOfMeasureCode
                });
                listView1.Items.Add(lvi);
            }

            lUkupno.Text = string.Format("Ukupno: {0}", SumPrices());

            tbPronadji.Focus();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count != 1) return;

            int index = listView1.SelectedIndices[0];
            _selectedItem = _tableBasket ? (object) _quoteItems[index] : _searchedItems[index];
        }

        private string SumPrices()
        {
            try
            {
                CultureInfo culture = Util.GetLocalCulture();
                return
                    _quoteItems.Sum(item => decimal.Parse(item.UnitPrice, culture)*decimal.Parse(item.Quantity, culture))
                        .ToString("N", culture.NumberFormat);
            }
            catch (Exception)
            {
                return "0";
            }
        }

        private void tbPronadji_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter || tbPronadji.Text.Length < 3) return;

            _searchedItems = SQLiteHelper.multiRowQuery(DbStatements.FindItemsStatementBarcode,
                new object[] {tbPronadji.Text});

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
            listView1.Columns.Add("Šifra", 120, HorizontalAlignment.Left);
            listView1.Columns.Add("Naziv artikla", 250, HorizontalAlignment.Left);

            foreach (var item in data)
            {
                var lvi = new ListViewItem(new[]
                {
                    item[DatabaseModel.ItemDbModel.ItemCode].ToString(),
                    item[DatabaseModel.ItemDbModel.ItemDescription].ToString()
                });
                listView1.Items.Add(lvi);
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
                MessageBox.Show("Potrebno je da odaberete artikal!", "Greška");
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
                MessageBox.Show("Potrebno je da odaberete liniju iz korpe!", "Greška");
            }
        }

        private void bObrisiLiniju_Click(object sender, EventArgs e)
        {
            if (_tableBasket && _selectedItem is ItemQuoteModel)
            {
                _quoteItems = (List<ItemQuoteModel>) _quoteItems.Where(val => val != _selectedItem);
            }
            else
            {
                MessageBox.Show("Potrebno je da odaberete liniju iz korpe!", "Greška");
            }
        }

        private void bUcitajNoveArtikle_Click(object sender, EventArgs e)
        {
        }

        private void bPosalji_Click(object sender, EventArgs e)
        {
            DialogResult result = new StampaDijalog().ShowDialog();

            if (result == DialogResult.OK)
            {
                
            }

            try
            {
                Cursor.Current = Cursors.WaitCursor;

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
            }
            catch (Exception ex)
            {
                Util.GeneralExceptionProcessing(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }



        }
    }
}