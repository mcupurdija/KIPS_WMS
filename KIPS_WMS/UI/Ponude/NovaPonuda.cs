using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KIPS_WMS.Data;
using KIPS_WMS.Model;

namespace KIPS_WMS.UI.Ponude
{
    public partial class NovaPonuda : Form
    {

        List<Object[]> customers;
        Object[] selectedCustomer;

        public NovaPonuda()
        {
            InitializeComponent();
            customers = new List<object[]>();
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
            if (tbPronadji.Text.Length > 2)
            {
                customers = SQLiteHelper.multiRowQuery(String.Format(DbStatements.FindCustomersStatementComplete, tbPronadji.Text), new object[] { });
                lvKupci.Clear();
                lvKupci.View = View.Details;
                lvKupci.Columns.Add("Šifra artikla", 120, HorizontalAlignment.Center);
                lvKupci.Columns.Add("Naziv", 195, HorizontalAlignment.Center);

                foreach (Object[] customer in customers)
                {
                    ListViewItem lvi;

                    lvi =
                        new ListViewItem(new[]
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

        }

        private void tbPronadji_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (tbPronadji.Text.Length > 2)
                {
                    customers = SQLiteHelper.multiRowQuery(DbStatements.FindCustomersStatementBarcode, new object[] { tbPronadji.Text });
                    lvKupci.Clear();
                    lvKupci.View = View.Details;
                    lvKupci.Columns.Add("Šifra artikla", 120, HorizontalAlignment.Center);
                    lvKupci.Columns.Add("Naziv", 195, HorizontalAlignment.Center);

                    foreach (Object[] customer in customers)
                    {
                        ListViewItem lvi;

                        lvi =
                            new ListViewItem(new[]
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
                selectedCustomer = customers[index];
                MessageBox.Show(selectedCustomer[0]+"/"+selectedCustomer[1]);
            }
        }
    }
}