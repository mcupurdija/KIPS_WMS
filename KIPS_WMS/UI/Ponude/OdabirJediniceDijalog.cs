using System;
using System.Drawing;
using System.Windows.Forms;

namespace KIPS_WMS.UI.Ponude
{
    public partial class OdabirJediniceDijalog : NonFullscreenForm
    {
        public OdabirJediniceDijalog()
        {
            InitializeComponent();

            var myAutoScaleFactor = new SizeF(
                AutoScaleDimensions.Width/96F,
                AutoScaleDimensions.Height/96F);

            Height = (int) (myAutoScaleFactor.Height*95);
        }

        private void linkLabel1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}