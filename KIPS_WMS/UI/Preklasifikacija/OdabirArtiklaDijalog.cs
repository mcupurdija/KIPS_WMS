using System;
using System.Drawing;
using System.Windows.Forms;
using FileHelpers;
using KIPS_WMS.Model;
using KIPS_WMS.NAV_WS;
using KIPS_WMS.Web;
using KIPS_WMS.Properties;
using KIPS_WMS.Data;
using System.Collections.Generic;

namespace KIPS_WMS.UI.Preklasifikacija
{
    public partial class OdabirArtiklaDijalog : NonFullscreenForm
    {
        private readonly string _itemNo;
        private readonly KIPS_wms _ws = WebServiceFactory.GetWebService();

        private List<Object[]> _items;
        public Object[] _selectedItem;

        public OdabirArtiklaDijalog(string itemNo)
        {
            InitializeComponent();

            _itemNo = itemNo;

            var myAutoScaleFactor = new SizeF(
                AutoScaleDimensions.Width / 96F,
                AutoScaleDimensions.Height / 96F);

            Height = (int)(myAutoScaleFactor.Height * 110);

            GetData();
        }

        private void GetData()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                _items = SQLiteHelper.multiRowQuery(DbStatements.FindItemsStatementComplete,
                            new object[] { _itemNo });

                listView1.Clear();
                listView1.View = View.List;
                foreach (Object[] item in _items)
                {
                    var lvi = new ListViewItem(new[]
                    {
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
            _selectedItem = _items[index];
        }

        private void bPotvrdi_Click(object sender, EventArgs e)
        {
            if (_selectedItem != null)
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
    }
}