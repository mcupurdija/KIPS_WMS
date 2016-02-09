using System;
using System.Collections.Generic;
using System.Windows.Forms;
using KIPS_WMS.Data;
using KIPS_WMS.Model;
using KIPS_WMS.Properties;

namespace KIPS_WMS.UI.Ponude
{
    public partial class NovaPonuda : Form
    {
        private List<Object[]> _customers;
        private Object[] _selectedCustomer;

        public NovaPonuda()
        {
            InitializeComponent();
            _customers = new List<object[]>();
        }

        private void bPronadji_Click(object sender, EventArgs e)
        {
            FindCustomers(SearchType.Button);
        }

        private void FindCustomers(SearchType searchType)
        {
            if (tbPronadji.Text.Length > 2)
            {
                switch (searchType)
                {
                    case SearchType.Scanner:
                        _customers = SQLiteHelper.multiRowQuery(DbStatements.FindCustomersStatementBarcode,
                            new object[] {tbPronadji.Text});
                        break;
                    case SearchType.Button:
                        _customers = SQLiteHelper.multiRowQuery(DbStatements.FindCustomersStatementComplete,
                            new object[] {tbPronadji.Text});
                        break;
                }

                if (_customers.Count == 1)
                {
                    new PonudaKorpa(_customers[0][DatabaseModel.CustomerDbModel.CustomerCode].ToString(),
                        _customers[0][DatabaseModel.CustomerDbModel.CustomerName].ToString(), 1, String.Empty,
                        new List<ItemQuoteModel>()).Show();
                    Close();
                }
                else
                {
                    lvKupci.Clear();
                    lvKupci.View = View.Details;
                    lvKupci.Columns.Add(Resources.Sifra, 120, HorizontalAlignment.Left);
                    lvKupci.Columns.Add(Resources.ImeKupca, 200, HorizontalAlignment.Left);

                    foreach (var customer in _customers)
                    {
                        var lvi = new ListViewItem(new[]
                    {
                        customer[DatabaseModel.CustomerDbModel.CustomerCode].ToString(),
                        customer[DatabaseModel.CustomerDbModel.CustomerName].ToString()
                    });
                        lvKupci.Items.Add(lvi);
                    }

                    if (lvKupci.Items.Count > 0)
                    {
                        lvKupci.Focus();
                        lvKupci.Items[0].Selected = true;
                    }
                }
            }
        }

        private void bNepoznatKupac_Click(object sender, EventArgs e)
        {
            new PonudaKorpa(Utils.UnknownCustomerCode, String.Empty, 0, String.Empty, new List<ItemQuoteModel>()).Show();
            Close();
        }

        private void bKreiraj_Click(object sender, EventArgs e)
        {
            CreateNewOffer();
        }

        private void bNoviKupci_Click(object sender, EventArgs e)
        {
            var loadingForm = new NoviKupciDijalog();
            DialogResult result = loadingForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                FindCustomers(SearchType.Button);
            }
        }

        private void tbPronadji_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FindCustomers(SearchType.Scanner);
            }
        }

        private void lvKupci_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvKupci.SelectedIndices.Count == 1)
            {
                int index = lvKupci.SelectedIndices[0];
                _selectedCustomer = _customers[index];
            }
        }

        private void lvKupci_KeyUp(object sender, KeyEventArgs e)
        {
            if (lvKupci.SelectedIndices.Count == 1 && _selectedCustomer != null && e.KeyCode == Keys.Return)
            {
                CreateNewOffer();
            }
        }

        private void CreateNewOffer()
        {
            if (_selectedCustomer != null)
            {
                new PonudaKorpa(_selectedCustomer[DatabaseModel.CustomerDbModel.CustomerCode].ToString(),
                    _selectedCustomer[DatabaseModel.CustomerDbModel.CustomerName].ToString(), 0, String.Empty,
                    new List<ItemQuoteModel>()).Show();
                Close();
            }
            else {
                MessageBox.Show("Niste unijeli ime kupca. Molimo unesite kupca ili kliknite na nepoznat kupac.", Resources.Greska);
            }
        }

        private enum SearchType
        {
            Scanner,
            Button
        }

        private void toolBar1_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            switch (toolBar1.Buttons.IndexOf(e.Button))
            {
                case 0:
                    Close();
                    break;
                case 1:
                    var loadingForm = new NoviKupciDijalog();
                    DialogResult result = loadingForm.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        FindCustomers(SearchType.Button);
                    }
                    break;
            }
        }
    }
}