using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using KIPS_WMS.Data;
using KIPS_WMS.Model;

namespace KIPS_WMS.UI.Ponude
{
    public partial class PonudaKorpa : Form
    {
        private readonly string _customerCode;
        private readonly string _customerName;
        private readonly string _quoteNo;
        private ItemQuoteModel[] _quoteItems;

        private List<Object[]> _searchedItems;
        private Object _selectedItem;
        private bool _tableBasket = true;

        public PonudaKorpa()
        {
            InitializeComponent();
        }

        public PonudaKorpa(string quoteNo, string customerCode, string customerName, ItemQuoteModel[] quoteItems)
        {
            InitializeComponent();

            _quoteNo = quoteNo;
            _customerName = customerName;
            _customerCode = customerCode;
            _quoteItems = quoteItems;

            lKupac.Text = string.Format("{0} - {1}", _customerCode, _customerName);
            lUkupno.Text = string.Format("Ukupno: {0}", SumPrices());
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
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count != 1) return;

            int index = listView1.SelectedIndices[0];
            _selectedItem = _tableBasket ? (object) _quoteItems[index] : _searchedItems[index];
        }

        private decimal SumPrices()
        {
            try
            {
                return _quoteItems.Sum(item => decimal.Parse(item.UnitPrice, Util.GetLocalCulture()));
            }
            catch (Exception)
            {
                return 0;
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

        private void ShowLinesForm()
        {
            var ponudaLinija = new PonudaLinija(_quoteNo, _quoteItems, _selectedItem);
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
                ShowLinesForm();
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
                ShowLinesForm();
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
                _quoteItems = _quoteItems.Where(val => val != _selectedItem).ToArray();
            }
            else
            {
                MessageBox.Show("Potrebno je da odaberete liniju iz korpe!", "Greška");
            }
        }

        private void bUcitajNoveArtikle_Click(object sender, EventArgs e)
        {
        }
    }
}