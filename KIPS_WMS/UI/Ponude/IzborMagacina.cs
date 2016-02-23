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
    public partial class IzborMagacina : NonFullscreenForm
    {
        private readonly string _itemNo;
        private readonly MobileWMSSync _ws = WebServiceFactory.GetWebService();

        private BinModel[] _bins;
        public BinModel SelectedBin;

        public IzborMagacina(string itemNo)
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
                string itemBinCsv = String.Empty;

                var loginData = RegistryUtils.GetLoginData();
                _ws.GetLocationsForQuote(RegistryUtils.GetLastUsername(), loginData.Magacin, loginData.Podmagacin, _itemNo, ref itemBinCsv);
                var engine = new FileHelperEngine(typeof(BinModel));
                _bins = ((BinModel[])engine.ReadString(itemBinCsv));

                listView1.Clear();
                listView1.View = View.Details;
                listView1.Columns.Add(Resources.Sifra, 80, HorizontalAlignment.Left);
                listView1.Columns.Add(Resources.Naziv, 200, HorizontalAlignment.Left);

                foreach (BinModel bin in _bins)
                {
                    var lvi = new ListViewItem(new[]
                {
                    bin.BinCode, bin.BinName
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
            SelectedBin = _bins[index];
        }

        private void bPotvrdi_Click(object sender, EventArgs e)
        {
            if (SelectedBin != null)
            {
                DialogResult = DialogResult.Yes;
                Close();
            }
            else
            {
                MessageBox.Show("Odaberite magacin", Resources.Greska);
            }
        }

        private void bOtkazi_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

    }
}