using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KIPS_WMS.Model;
using KIPS_WMS.Data;
using KIPS_WMS.Properties;

namespace KIPS_WMS.UI.BarkodTest
{
    public partial class BarkodTest : Form
    {
        public BarkodTest()
        {
            InitializeComponent();
        }

        private void tbBarkod_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && tbBarkod.Text.Trim().Length > 0)
            {
                List<object[]> query = SQLiteHelper.multiRowQuery(DbStatements.FindItemsStatementBarcode,
                    new object[] { tbBarkod.Text.Trim() });
                if (query.Count == 1)
                {
                    object[] _dbItem = query[0];
                    lBarkod.Text = _dbItem[DatabaseModel.ItemDbModel.ItemBarcode].ToString();
                    lSifra.Text = _dbItem[DatabaseModel.ItemDbModel.ItemCode].ToString();
                    lNaziv.Text = _dbItem[DatabaseModel.ItemDbModel.ItemDescription].ToString();
                    lJm.Text = _dbItem[DatabaseModel.ItemDbModel.ItemUnitOfMeasure].ToString();

                    tbBarkod.SelectionStart = 0;
                    tbBarkod.SelectionLength = tbBarkod.Text.Length;

                }
                else
                {
                    MessageBox.Show(Resources.NijePronadjenArtikal, Resources.Greska);
                }
            }
            
        }

        private void bPronadji_Click(object sender, EventArgs e)
        {
            if (tbBarkod.Text.Trim().Length > 0)
            {
                List<object[]> query = SQLiteHelper.multiRowQuery(DbStatements.FindItemsStatementBarcode,
                    new object[] { tbBarkod.Text.Trim() });
                if (query.Count == 1)
                {
                    object[] _dbItem = query[0];
                    lBarkod.Text = _dbItem[DatabaseModel.ItemDbModel.ItemBarcode].ToString();
                    lSifra.Text = _dbItem[DatabaseModel.ItemDbModel.ItemCode].ToString();
                    lNaziv.Text = _dbItem[DatabaseModel.ItemDbModel.ItemDescription].ToString();
                    lJm.Text = _dbItem[DatabaseModel.ItemDbModel.ItemUnitOfMeasure].ToString();

                    tbBarkod.SelectionStart = 0;
                    tbBarkod.SelectionLength = tbBarkod.Text.Length;

                }
                else
                {
                    MessageBox.Show(Resources.NijePronadjenArtikal, Resources.Greska);
                }
            }
        }

    }
}