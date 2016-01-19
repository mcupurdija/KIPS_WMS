using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KIPS_WMS.UI
{
    public partial class NoviArtikliDijalog : NonFullscreenForm
    {
        public NoviArtikliDijalog()
        {
            InitializeComponent();

            var myAutoScaleFactor = new SizeF(
                AutoScaleDimensions.Width / 96F,
                AutoScaleDimensions.Height / 96F);

            Height = (int)(myAutoScaleFactor.Height * 95 - SystemInformation.MenuHeight);
        }
    }
}