using System;
using System.Drawing;
using System.Windows.Forms;
using FileHelpers;
using KIPS_WMS.Model;
using KIPS_WMS.NAV_WS;
using KIPS_WMS.Web;

namespace KIPS_WMS.UI.Ponude
{
    public partial class OdabirJediniceDijalog : NonFullscreenForm
    {
        private readonly string _itemNo;
        private readonly KIPS_wms _ws = WebServiceFactory.GetWebService();

        private ItemUnitOfMeasureModel[] _itemUnitsOfMeasure;
        public ItemUnitOfMeasureModel SelectedUnitOfMeasure;

        public OdabirJediniceDijalog(string itemNo)
        {
            InitializeComponent();

            _itemNo = itemNo;

            var myAutoScaleFactor = new SizeF(
                AutoScaleDimensions.Width/96F,
                AutoScaleDimensions.Height/96F);

            Height = (int) (myAutoScaleFactor.Height*110);

            GetData();
        }

        private void GetData()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                string itemUnitOfMeasureCsv = String.Empty;
                _ws.GetItemUnitsOfMeasure(_itemNo, "", ref itemUnitOfMeasureCsv);

                var engine = new FileHelperEngine(typeof (ItemUnitOfMeasureModel));
                _itemUnitsOfMeasure = (ItemUnitOfMeasureModel[])engine.ReadString(itemUnitOfMeasureCsv);

                listView1.Clear();
                listView1.View = View.Details;
                listView1.Columns.Add("Jedinica mere", listView1.Width - 2, HorizontalAlignment.Left);
                foreach (ItemUnitOfMeasureModel item in _itemUnitsOfMeasure)
                {
                    var lvi = new ListViewItem(new[]
                    {
                        item.UnitOfMeasureCode
                    });
                    listView1.Items.Add(lvi);
                }
            }
            catch (Exception ex)
            {
                Util.GeneralExceptionProcessing(ex);
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
            SelectedUnitOfMeasure = _itemUnitsOfMeasure[index];
        }

        private void bPotvrdi_Click(object sender, EventArgs e)
        {
            if (SelectedUnitOfMeasure != null)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Potrebno je da odaberete jedinicu mere!", "Greška");
            }
        }
    }
}