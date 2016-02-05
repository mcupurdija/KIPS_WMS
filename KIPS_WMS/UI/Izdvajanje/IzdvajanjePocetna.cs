using System;
using System.Windows.Forms;

namespace KIPS_WMS.UI.Izdvajanje
{
    public partial class IzdvajanjePocetna : Form
    {
        public IzdvajanjePocetna()
        {
            InitializeComponent();
        }

        private void bDokument_Click(object sender, EventArgs e)
        {
            new IzdvajanjePretragaPoDokumentu().Show();
            Close();
        }

        private void bArtikal_Click(object sender, EventArgs e)
        {

        }
    }
}