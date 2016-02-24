using System;
using System.Windows.Forms;

namespace KIPS_WMS.UI.Skladistenje
{
    public partial class SkladistenjePocetna : Form
    {
        public SkladistenjePocetna()
        {
            InitializeComponent();
        }

        private void bDokument_Click(object sender, EventArgs e)
        {
            new SkladistenjePretragaPoDokumentu().Show();
            Close();
        }

        private void bArtikal_Click(object sender, EventArgs e)
        {
            new SkladistenjePretragaPoArtiklu().Show();
            Close();
        }

        private void toolBar1_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            Close();
        }

        private void SkladistenjePocetna_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                Close();
            }
        }
    }
}