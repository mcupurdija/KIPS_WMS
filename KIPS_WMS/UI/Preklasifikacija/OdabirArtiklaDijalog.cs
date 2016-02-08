using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using KIPS_WMS.Data;
using KIPS_WMS.Model;
using KIPS_WMS.Properties;

namespace KIPS_WMS.UI.Preklasifikacija
{
    public partial class OdabirArtiklaDijalog : NonFullscreenForm
    {
        private readonly string _itemNo;

        public Object[] SelectedItem;
        private List<Object[]> _items;

        public OdabirArtiklaDijalog(string itemNo)
        {
            InitializeComponent();

            _itemNo = itemNo;

            var myAutoScaleFactor = new SizeF(
                AutoScaleDimensions.Width/96F,
                AutoScaleDimensions.Height/96F);

            Height = (int) (myAutoScaleFactor.Height*130);

            GetData();
        }

        private void GetData()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                _items = SQLiteHelper.multiRowQuery(DbStatements.FindItemsStatementComplete,
                    new object[] {_itemNo});

                listView1.Clear();
                listView1.View = View.Details;
                listView1.Columns.Add(Resources.Sifra, 100, HorizontalAlignment.Left);
                listView1.Columns.Add(Resources.NazivArtika, 250, HorizontalAlignment.Left);
                foreach (var item in _items)
                {
                    var lvi = new ListViewItem(new[]
                    {
                        item[DatabaseModel.ItemDbModel.ItemCode].ToString(),
                        item[DatabaseModel.ItemDbModel.ItemDescription].ToString()
                    });
                    listView1.Items.Add(lvi);
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

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count != 1) return;

            int index = listView1.SelectedIndices[0];
            SelectedItem = _items[index];
        }

        private void bPotvrdi_Click(object sender, EventArgs e)
        {
            if (SelectedItem != null)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show(Resources.OdaberiteArtikal, Resources.Greska);
            }
        }

        private void OdabirArtiklaDijalog_Paint(object sender, PaintEventArgs e)
        {
            if (_items.Count == 0)
            {
                MessageBox.Show(Resources.NijePronadjenArtikal, Resources.Greska);
                DialogResult = DialogResult.No;
                Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}