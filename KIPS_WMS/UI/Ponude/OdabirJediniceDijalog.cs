using System;
using System.Drawing;
using System.Windows.Forms;
using FileHelpers;
using KIPS_WMS.Model;
using KIPS_WMS.NAV_WS;
using KIPS_WMS.Web;
using KIPS_WMS.Properties;

namespace KIPS_WMS.UI.Ponude
{
    public partial class OdabirJediniceDijalog : NonFullscreenForm
    {
        private readonly string _itemNo;
        private readonly MobileWMSSync _ws = WebServiceFactory.GetWebService();

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
                _ws.GetItemUnitsOfMeasure(_itemNo, RegistryUtils.GetLastUsername(), RegistryUtils.GetLoginData().Magacin, ref itemUnitOfMeasureCsv);

                var engine = new FileHelperEngine(typeof (ItemUnitOfMeasureModel));
                _itemUnitsOfMeasure = (ItemUnitOfMeasureModel[])engine.ReadString(itemUnitOfMeasureCsv);

                listView1.Clear();
                listView1.View = View.List;
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
                MessageBox.Show(Resources.OdaberiteJM, Resources.Greska);
            }
        }

        private void bOtkazi_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

    }
}