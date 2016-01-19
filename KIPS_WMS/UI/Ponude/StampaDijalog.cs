using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
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
                AutoScaleDimensions.Width / 96F,
                AutoScaleDimensions.Height / 96F);

            Height = (int)(myAutoScaleFactor.Height * 110);
        }

        private void bPotvrdi_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}