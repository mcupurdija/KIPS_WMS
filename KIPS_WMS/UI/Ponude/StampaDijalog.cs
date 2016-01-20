using System;
using System.Drawing;
using System.Windows.Forms;

namespace KIPS_WMS.UI.Ponude
{
    public partial class StampaDijalog : NonFullscreenForm
    {
        public int PrintTypeSelected;

        public StampaDijalog()
        {
            InitializeComponent();

            var myAutoScaleFactor = new SizeF(
                AutoScaleDimensions.Width/96F,
                AutoScaleDimensions.Height/96F);

            Height = (int) (myAutoScaleFactor.Height*110);
        }

        private void bPotvrdi_Click(object sender, EventArgs e)
        {
            if (rbKratkaStampa.Checked)
            {
                PrintTypeSelected = Utils.PrintTypeShort;
            }
            else if (rbDugaStampa.Checked)
            {
                PrintTypeSelected = Utils.PrintTypeLong;
            }
            else
            {
                PrintTypeSelected = Utils.PrintTypeIgnore;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void bOdustani_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
            Close();
        }
    }
}