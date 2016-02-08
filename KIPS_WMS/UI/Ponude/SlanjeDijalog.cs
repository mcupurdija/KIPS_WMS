using System;
using System.Drawing;
using System.Windows.Forms;
using KIPS_WMS.Model;
using KIPS_WMS.Properties;

namespace KIPS_WMS.UI.Ponude
{
    public partial class SlanjeDijalog : NonFullscreenForm
    {
        private readonly PrintHeaderModel _printHeaderModel;

        public SlanjeDijalog(PrintHeaderModel printHeaderModel, int creditLimit)
        {
            InitializeComponent();

            _printHeaderModel = printHeaderModel;

            var myAutoScaleFactor = new SizeF(
                AutoScaleDimensions.Width/96F,
                AutoScaleDimensions.Height/96F);

            Height = (int) (myAutoScaleFactor.Height*110);

            lStatus.Text = String.Format(Resources.UspesnoKreiranjeAzuriranje, _printHeaderModel.DocumentNo);
            if (creditLimit == 1 && _printHeaderModel.CustomerCode != Utils.UnknownCustomerCode)
            {
                lKreditniLimit.Text = Resources.PrekoracenKreditniLimit;
            }
            else
            {
                lKreditniLimit.Visible = false;
            }
            if (_printHeaderModel.PrintType == 3)
            {
                bPonovi.Visible = false;
            }
        }

        private void bOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void bPonovi_Click(object sender, EventArgs e)
        {
            PrintHelper.Print(_printHeaderModel);
        }
    }
}