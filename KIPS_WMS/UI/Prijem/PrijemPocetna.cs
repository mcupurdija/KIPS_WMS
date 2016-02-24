using System;
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
            new PrijemPretragaPoArtiklu().Show();
            Close();
        }

        private void toolBar1_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            Close();
        }

        private void PrijemPocetna_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                Close();
            }
        }
    }
}