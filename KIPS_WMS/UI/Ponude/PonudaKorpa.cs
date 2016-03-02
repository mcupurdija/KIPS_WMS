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
using KIPS_WMS.Properties;
using KIPS_WMS.Web;
using OpenNETCF.Windows.Forms;

namespace KIPS_WMS.UI.Ponude
{
    public partial class PonudaKorpa : Form
    {
        private readonly CultureInfo _culture = Utils.GetLocalCulture();
        private readonly string _customerCode;
        private readonly string _customerName;
        private readonly int _isAuthenticated;
        private readonly string _quoteNo;
        private readonly MobileWMSSync _ws = WebServiceFactory.GetWebService();
        private List<ItemQuoteModel> _quoteItems;

        private List<Object[]> _searchedItems;
        private Object _selectedItem;
        private bool _sent;
        private bool _tableBasket = true;

        public PonudaKorpa()
        {
            InitializeComponent();
        }

        public PonudaKorpa(string customerCode, string customerName, int isAuthenticated, string quoteNo,
            List<ItemQuoteModel> quoteItems)
        {
            InitializeComponent();

            listBox1.DrawMode = DrawMode.OwnerDrawFixed;

            _customerCode = customerCode;
            _customerName = customerName;
            _isAuthenticated = isAuthenticated;
            _quoteNo = quoteNo;
            _quoteItems = quoteItems;

            lKupac.Text = _customerCode != Utils.UnknownCustomerCode
                ? string.Format("{0} - {1}", _customerCode, _customerName)
                : Resources.NepoznatKupac;

            DisplayLines();
            tbPronadji.Focus();
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);

            if (_quoteNo != String.Empty)
            {
                Text = _quoteNo;
            }

            SaveData();
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
                SaveData();
            }
        }

        private void DisplayLines()
        {
            _tableBasket = true;
            bDodaj.Visible = false;
            listBox1.BackColor = Color.LightYellow;

            listBox1.Items.Clear();
            listBox1.SelectedIndex = -1;
            var listItem = new ListItem();
            for (int i = 0; i < _quoteItems.Count; i++)
            {
                listBox1.Items.Add(listItem);
            }
            if (listBox1.Items.Count > 3)
            {
                listBox1.Items.Add(new ListItem {Tag = 0});
            }

            lUkupno.Text = string.Format(Resources.Ukupno + ": {0}", SumPrices());
        }

        private string SumPrices()
        {
            try
            {
                return
                    _quoteItems.Sum(
                        item =>
                            decimal.Parse(item.UnitPriceWithDiscount, _culture)*decimal.Parse(item.Quantity, _culture))
                        .ToString("#,0.###", _culture);
            }
            catch (Exception)
            {
                return "0,00";
            }
        }

        private void tbPronadji_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter || tbPronadji.Text.Length < 3) return;
            if (e.KeyCode == Keys.Enter)
            {
                _searchedItems = SQLiteHelper.multiRowQuery(DbStatements.FindItemsStatementBarcode,
                    new object[] {tbPronadji.Text.Trim()});
                if (_searchedItems.Count == 1)
                {
                    ItemQuoteModel item =
                        _quoteItems.FirstOrDefault(
                            x => (string) _searchedItems[0][DatabaseModel.ItemDbModel.ItemCode] == x.ItemCode
                                 &&
                                 (string) _searchedItems[0][DatabaseModel.ItemDbModel.ItemUnitOfMeasure] ==
                                 x.UnitOfMeasureCode);
                    if (item != null)
                    {
                        _selectedItem = item;
                        ShowLinesForm(PonudaLinija.ItemState.Edit, true);
                    }
                    else
                    {
                        _selectedItem = _searchedItems[0];
                        ShowLinesForm(PonudaLinija.ItemState.New, true);
                    }
                }
                else if (_searchedItems.Count == 0)
                {
                    _searchedItems = SQLiteHelper.multiRowQuery(DbStatements.FindItemsStatementCode,
                        new object[] { tbPronadji.Text.Trim() });


                    //_searchedItems = SQLiteHelper.multiRowQuery(DbStatements.FindItemsStatementCode,
                    //    new object[] { tbPronadji.Text });
                    //if (_searchedItems.Count > 1)
                    //{
                    //    _selectedItem = _searchedItems[0];
                    //    //ShowLinesForm(PonudaLinija.ItemState.New, true);
                    //}
                    if (_searchedItems.Count == 1)
                    {
                        ItemQuoteModel item =
                            _quoteItems.FirstOrDefault(
                                x => (string) _searchedItems[0][DatabaseModel.ItemDbModel.ItemCode] == x.ItemCode
                                     &&
                                     (string) _searchedItems[0][DatabaseModel.ItemDbModel.ItemUnitOfMeasure] ==
                                     x.UnitOfMeasureCode);
                        if (item != null)
                        {
                            _selectedItem = item;
                            ShowLinesForm(PonudaLinija.ItemState.Edit, false);
                        }
                        else
                        {
                            _selectedItem = _searchedItems[0];
                            ShowLinesForm(PonudaLinija.ItemState.New, false);
                        }
                    }
                }
                else
                {
                    DisplaySearchResults(_searchedItems);
                }

                //ResetForm();
            }
        }

        private void bPronadji_Click(object sender, EventArgs e)
        {
            if (tbPronadji.Text.Length < 3) return;

            _searchedItems = SQLiteHelper.multiRowQuery(DbStatements.FindItemsStatementComplete,
                new object[] { tbPronadji.Text.Trim() });

            DisplaySearchResults(_searchedItems);
        }

        private void DisplaySearchResults(IEnumerable<object[]> data)
        {
            _tableBasket = false;
            bDodaj.Visible = true;
            listBox1.BackColor = Color.White;

            listBox1.Items.Clear();
            listBox1.SelectedIndex = -1;
            var listItem = new ListItem();
            foreach (var item in data)
            {
                listBox1.Items.Add(listItem);
            }
            if (listBox1.Items.Count > 3)
            {
                listBox1.Items.Add(new ListItem {Tag = 0});
            }

            if (listBox1.Items.Count > 0)
            {
                listBox1.Focus();
                listBox1.SelectedIndex = 0;
            }
        }

        private void bResetuj_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void ResetForm()
        {
            DisplayLines();
            _selectedItem = null;
            tbPronadji.Text = "";
            tbPronadji.Focus();
        }

        private void ShowLinesForm(PonudaLinija.ItemState itemState, bool fromScanner)
        {
            var ponudaLinija = new PonudaLinija(_customerCode, _isAuthenticated, itemState, _quoteNo, _selectedItem,
                _quoteItems, fromScanner);
            DialogResult result = ponudaLinija.ShowDialog();

            if (result == DialogResult.OK)
            {
                _quoteItems = ponudaLinija.QuoteItems;
                DisplayLines();
            }

            ResetForm();
        }

        private void bDodaj_Click(object sender, EventArgs e)
        {
            if (!_tableBasket && _selectedItem != null)
            {
                ShowLinesForm(PonudaLinija.ItemState.New, false);
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
                ShowLinesForm(PonudaLinija.ItemState.Edit, false);
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
                _quoteItems.Remove((ItemQuoteModel) _selectedItem);
                DisplayLines();
                tbPronadji.Text = "";
                tbPronadji.Focus();
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

                _searchedItems = SQLiteHelper.multiRowQuery(DbStatements.FindItemsStatementComplete,
                    new object[] {tbPronadji.Text});
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
                    WarehouseCode = item.LocationCode
                }).ToList();

                var engine = new FileHelperEngine(typeof (SendQuoteModel));
                string lines = engine.WriteString(quotes);

                _ws.SendQuote(RegistryUtils.GetLastUsername(), RegistryUtils.GetLoginData().Magacin, ref documentNo,
                    _customerCode, _isAuthenticated, lines, ref status,
                    ref creditLimit, Utils.AppVersion);

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
                            ItemQuantity = decimal.Parse(item.Quantity, _culture).ToString("#,0.##", _culture),
                            ItemPrice = decimal.Parse(item.UnitPriceWithDiscount, _culture).ToString("#,0.00", _culture),
                            ItemTotal = (decimal.Parse(item.Quantity, _culture) * decimal.Parse(item.UnitPriceWithDiscount, _culture)).ToString("#,0.00", _culture),
                            ItemUnitOfMeasure = item.UnitOfMeasureCode,
                            Warehouse = item.LocationCode
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

                listBox1.Dispose();
                Close();
            }
        }

        private void bOdustani_Click(object sender, EventArgs e)
        {
            _sent = true;

            listBox1.Dispose();
            Close();
        }

        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            int index = e.Index;
            if (index >= listBox1.Items.Count || listBox1.Items[index].Tag != null) return;

            SolidBrush brush;
            if (e.State == DrawItemState.Selected)
            {
                e.DrawBackground(Color.Blue);
                brush = new SolidBrush(Color.White);
            }
            else
            {
                e.DrawBackground(index%2 == 0 ? SystemColors.Control : Color.White);
                brush = new SolidBrush(Color.Black);
            }

            string firstLine;
            string secondLine;
            if (_tableBasket)
            {
                ItemQuoteModel line = _quoteItems[index];

                firstLine = string.Format("{0} {1}", line.ItemCode, line.ItemDescription);
                secondLine = string.Format("{0} {1}", line.Quantity, line.UnitOfMeasureCode);
            }
            else
            {
                object[] line = _searchedItems[index];

                firstLine = string.Format("{0} {1}", line[DatabaseModel.ItemDbModel.ItemCode],
                    line[DatabaseModel.ItemDbModel.ItemDescription]);
                secondLine = string.Format("{0}", line[DatabaseModel.ItemDbModel.ItemUnitOfMeasure]);
            }

            e.Graphics.DrawString(firstLine,
                new Font(FontFamily.GenericSansSerif, 8F, FontStyle.Bold), brush, e.Bounds.Left + 3, e.Bounds.Top,
                new StringFormat {FormatFlags = StringFormatFlags.NoWrap});
            e.Graphics.DrawString(secondLine,
                new Font(FontFamily.GenericSansSerif, 8F, FontStyle.Regular), brush, e.Bounds.Left + 3,
                e.Bounds.Top + 20, new StringFormat {FormatFlags = StringFormatFlags.NoWrap});
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            if (index == -1 || index >= listBox1.Items.Count || listBox1.Items[index].Tag != null)
            {
                _selectedItem = null;
                return;
            }

            _selectedItem = _tableBasket ? (object) _quoteItems[index] : _searchedItems[index];
        }

        private void listBox1_KeyUp(object sender, KeyEventArgs e)
        {
            int index = listBox1.SelectedIndex;
            if (index == -1 || index >= listBox1.Items.Count || listBox1.Items[index].Tag != null ||
                e.KeyCode != Keys.Return)
            {
                return;
            }

            ShowLinesForm(_tableBasket ? PonudaLinija.ItemState.Edit : PonudaLinija.ItemState.New, false);
        }

        private void cIzmeniLiniju_Click(object sender, EventArgs e)
        {
            if (_tableBasket && _selectedItem is ItemQuoteModel)
            {
                ShowLinesForm(PonudaLinija.ItemState.Edit, false);
            }
            else
            {
                MessageBox.Show(Resources.OdaberiteLiniju, Resources.Greska);
            }
        }

        private void cObrisiLiniju_Click(object sender, EventArgs e)
        {
            if (_tableBasket && _selectedItem is ItemQuoteModel)
            {
                _quoteItems.Remove((ItemQuoteModel) _selectedItem);
                DisplayLines();
                tbPronadji.Text = "";
                tbPronadji.Focus();
            }
            else
            {
                MessageBox.Show(Resources.OdaberiteLiniju, Resources.Greska);
            }
        }

        private void cUcitajNoveArtikle_Click(object sender, EventArgs e)
        {
            var loadingForm = new NoviArtikliDijalog();
            DialogResult result = loadingForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (tbPronadji.Text.Length < 3) return;

                _searchedItems = SQLiteHelper.multiRowQuery(DbStatements.FindItemsStatementComplete,
                    new object[] {tbPronadji.Text});
                DisplaySearchResults(_searchedItems);
            }
        }

        private void cOdustani_Click(object sender, EventArgs e)
        {
            _sent = true;

            listBox1.Dispose();
            Close();
        }

        private void toolBar1_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            switch (toolBar1.Buttons.IndexOf(e.Button))
            {
                case 0:
                    Close();
                    break;
                case 1:
                    contextMenu1.Show(toolBar1, new Point(80, 10));
                    break;
                case 2:
                    var stampaDijalog = new StampaDijalog();
                    DialogResult result = stampaDijalog.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        if (Utils.CheckDate())
                        {
                            new Thread(() => SendQuote(stampaDijalog.PrintTypeSelected)).Start();
                        }
                        else
                        {
                            Meni.ShowErrorMessage();
                        }
                    }
                    break;
            }
        }

        private void PonudaKorpa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                listBox1.Dispose();
                Close();
            }
        }

        private void SaveData()
        {
            RegistryUtils.SaveQuoteData(new QuoteHeaderHelper(_quoteNo, _customerCode, _customerName,
                    _isAuthenticated), _quoteItems);
        }
    }
}