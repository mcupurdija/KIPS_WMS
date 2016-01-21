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

                lvKupci.Clear();
                lvKupci.View = View.Details;
                lvKupci.Columns.Add(Resources.Sifra, 120, HorizontalAlignment.Left);
                lvKupci.Columns.Add(Resources.ImeKupca, 200, HorizontalAlignment.Left);

                foreach (var customer in _customers)
                {
                    var lvi = new ListViewItem(new[]
                    {
                        customer[DatabaseModel.CustomerDbModel.CustomerCode].ToString(),
                        customer[DatabaseModel.CustomerDbModel.CustomerDescription].ToString()
                    });
                    lvKupci.Items.Add(lvi);
                }
            }
        }

        private void bNepoznatKupac_Click(object sender, EventArgs e)
        {
//            new PonudaKorpa(customerCode, customerName, isAuthenticatedCustomer, quoteNo, quoteItems.ToList()).Show();
            Close();
        }

        private void bKreiraj_Click(object sender, EventArgs e)
        {
//            new PonudaKorpa(customerCode, customerName, isAuthenticatedCustomer, quoteNo, quoteItems.ToList()).Show();
            Close();
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

        private enum SearchType
        {
            Scanner,
            Button
        }
    }
}