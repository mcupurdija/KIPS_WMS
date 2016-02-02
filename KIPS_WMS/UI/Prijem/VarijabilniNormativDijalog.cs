using System;
using System.Drawing;
using System.Windows.Forms;
using KIPS_WMS.Model;
using KIPS_WMS.NAV_WS;
using KIPS_WMS.Web;

namespace KIPS_WMS.UI.Prijem
{
    public partial class VarijabilniNormativDijalog : NonFullscreenForm
    {
        private readonly WarehouseReceiptLineModel _selectedLine;
        private readonly KIPS_wms _ws = WebServiceFactory.GetWebService();

        public VarijabilniNormativDijalog(WarehouseReceiptLineModel selectedLine)
        {
            InitializeComponent();

            _selectedLine = selectedLine;

            var myAutoScaleFactor = new SizeF(
                AutoScaleDimensions.Width/96F,
                AutoScaleDimensions.Height/96F);

            Height = (int) (myAutoScaleFactor.Height*130);
        }

        private void bPosalji_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
            Close();
        }
    }
}