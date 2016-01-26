using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KIPS_WMS.Model;
using KIPS_WMS.Properties;

namespace KIPS_WMS.UI.Preklasifikacija
{
    public partial class PreklasifikacijaDetalji : Form
    {
        private string _itemName;
        private string _itemUnitOfMeasure;

        public PreklasifikacijaDetalji()
        {
            InitializeComponent();
        }

        private void bPronadji_Click(object sender, EventArgs e)
        {
            var odabirArtikla = new OdabirArtiklaDijalog(tbPronadji.Text.Trim());
            DialogResult result = odabirArtikla.ShowDialog();

            if (result == DialogResult.OK)
            {
                _itemName = odabirArtikla._selectedItem[DatabaseModel.ItemDbModel.ItemDescription].ToString();
                _itemUnitOfMeasure = odabirArtikla._selectedItem[DatabaseModel.ItemDbModel.ItemUnitOfMeasure].ToString();
                lbNaziv.Text = "Naziv artikla: " + _itemName;
                lbJM.Text = "JM: " + _itemUnitOfMeasure;
                tbPronadji.Text = odabirArtikla._selectedItem[DatabaseModel.ItemDbModel.ItemBarcode].ToString();
                tbSaRegala.Focus();
            }
        }

        private void bDodaj_Click(object sender, EventArgs e)
        {

            listView1.View = View.Details;
            listView1.Columns.Add(Resources.Artikal, 200, HorizontalAlignment.Left);
            listView1.Columns.Add(Resources.Kolicina, 50, HorizontalAlignment.Left);
            listView1.Columns.Add(Resources.JM, 50, HorizontalAlignment.Left);
            listView1.Columns.Add(Resources.SaRegala, 100, HorizontalAlignment.Left);
            listView1.Columns.Add(Resources.NaRegal, 100, HorizontalAlignment.Left);
            var lvi = new ListViewItem(new[]
                    {
                        _itemName, tbKolicina.Text,_itemUnitOfMeasure, tbSaRegala.Text,tbNaRegal.Text
                    });
            listView1.Items.Add(lvi);
        }

        private void bPonisti_Click(object sender, EventArgs e)
        {
            tbPronadji.Text = "";
        }

    }
}