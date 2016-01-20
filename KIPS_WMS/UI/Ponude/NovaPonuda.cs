using System;
using System.Collections.Generic;
using System.Windows.Forms;
using KIPS_WMS.Data;

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

        private void NovaPonuda_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void bPronadji_Click(object sender, EventArgs e)
        {
            FindCustomers();
        }

        private void FindCustomers()
        {
            if (tbPronadji.Text.Length > 2)
            {
                _customers =
                    SQLiteHelper.multiRowQuery(
                        String.Format(DbStatements.FindCustomersStatementComplete, tbPronadji.Text), new object[] { });

                lvKupci.Clear();
                lvKupci.View = View.Details;
                lvKupci.Columns.Add("Šifra", 120, HorizontalAlignment.Left);
                lvKupci.Columns.Add("Ime kupca", 195, HorizontalAlignment.Left);

                foreach (var customer in _customers)
                {
                    var lvi = new ListViewItem(new[]
                    {
                        customer[2].ToString(), customer[3].ToString()
                    });
                    lvKupci.Items.Add(lvi);
                }
            }
        }

        private void bNepoznatKupac_Click(object sender, EventArgs e)
        {
        }

        private void bKreiraj_Click(object sender, EventArgs e)
        {
        }

        private void bNoviKupci_Click(object sender, EventArgs e)
        {
            var loadingForm = new NoviKupciDijalog();
            DialogResult result = loadingForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                FindCustomers();
            }
        }

        private void tbPronadji_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (tbPronadji.Text.Length > 2)
                {
                    _customers = SQLiteHelper.multiRowQuery(DbStatements.FindCustomersStatementBarcode,
                        new object[] {tbPronadji.Text});
                    lvKupci.Clear();
                    lvKupci.View = View.Details;
                    lvKupci.Columns.Add("Šifra", 120, HorizontalAlignment.Left);
                    lvKupci.Columns.Add("Ime kupca", 195, HorizontalAlignment.Left);

                    foreach (var customer in _customers)
                    {
                        var lvi = new ListViewItem(new[]
                        {
                            customer[2].ToString(), customer[3].ToString()
                        });
                        lvKupci.Items.Add(lvi);
                    }
                }
            }
        }

        private void lvKupci_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvKupci.SelectedIndices.Count == 1)
            {
                int index = lvKupci.SelectedIndices[0];
                _selectedCustomer = _customers[index];
//                MessageBox.Show(selectedCustomer[0] + "/" + selectedCustomer[1]);
            }
        }

        private void NovaPonuda_Activated(object sender, EventArgs e)
        {
        }
    }
}