using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using FileHelpers;
using KIPS_WMS.Model;
using KIPS_WMS.NAV_WS;
using KIPS_WMS.Properties;
using KIPS_WMS.Web;

namespace KIPS_WMS.UI.Ostalo
{
    public partial class ArtikliPoRegalimaDijalog : NonFullscreenForm
    {
        private readonly string _binCode;
        private readonly string _itemNo;
        private readonly string _variantCode;
        private readonly MobileWMSSync _ws = WebServiceFactory.GetWebService();
        private List<ItemBinContentModel> _items;

        public ArtikliPoRegalimaDijalog(string binCode, string itemNo, string variantCode)
        {
            InitializeComponent();

            _binCode = binCode;
            _itemNo = itemNo;
            _variantCode = variantCode;

            var myAutoScaleFactor = new SizeF(
                AutoScaleDimensions.Width/96F,
                AutoScaleDimensions.Height/96F);

            Height = (int) (myAutoScaleFactor.Height*130);

            new Thread(GetData).Start();
        }

        private void GetData()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                string itemBinContentCsv = String.Empty;

                var loginData = RegistryUtils.GetLoginData();
                _ws.GetItemBinContent(RegistryUtils.GetLastUsername(), loginData.Magacin, loginData.Podmagacin, "", _itemNo, _variantCode, ref itemBinContentCsv);

                var engine = new FileHelperEngine(typeof (ItemBinContentModel));
                _items = ((ItemBinContentModel[]) engine.ReadString(itemBinContentCsv)).ToList();

                listView1.Invoke(new EventHandler((sender, e) => DisplayData()));
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

        private void DisplayData()
        {
            listView1.Clear();
            listView1.View = View.Details;
            listView1.Columns.Add("Regal", 100, HorizontalAlignment.Left);
            listView1.Columns.Add(Resources.Jedinica, 100, HorizontalAlignment.Left);
            listView1.Columns.Add(Resources.Kolicina, 80, HorizontalAlignment.Center);

            foreach (ItemBinContentModel item in _items)
            {
                var lvi = new ListViewItem(new[]
                {
                    item.BinCode, item.UnitOfMeasureCode, item.Quantity
                });
                listView1.Items.Add(lvi);
            }
        }

        private void bZatvori_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
            Close();
        }

        private void ArtikliPoRegalimaDijalog_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                bZatvori_Click(null, null);
            }
        }
    }
}