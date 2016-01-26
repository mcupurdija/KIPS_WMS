using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KIPS_WMS.UI.Prijem
{
    public partial class PrijemPocetna : Form
    {
        public PrijemPocetna()
        {
            InitializeComponent();
        }

        private void bDokument_Click(object sender, EventArgs e)
        {
            new PrijemPretragaPoDokumentu().Show();
            Close();
        }

        private void bArtikal_Click(object sender, EventArgs e)
        {

        }
    }
}