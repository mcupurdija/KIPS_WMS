using System;
using System.Drawing;
using System.Windows.Forms;
using KIPS_WMS.Model;
using KIPS_WMS.NAV_WS;
using KIPS_WMS.Web;
using KIPS_WMS.Properties;
using System.Collections.Generic;
using System.Globalization;
using KIPS_WMS.UI.Prijem;

namespace KIPS_WMS.UI.Isporuka
{
    public partial class PorukaDijalog : NonFullscreenForm
    {
        private string _poruka;

        public PorukaDijalog(string poruka)
        {
            InitializeComponent();
            _poruka = poruka;
            lPoruka.Text = _poruka;
        }

        private void bOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            Close();
        }



    }
}