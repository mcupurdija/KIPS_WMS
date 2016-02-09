using System;
using System.Windows.Forms;

namespace KIPS_WMS.UI.Isporuka
{
    public partial class IsporukaPocetna : Form
    {
        public IsporukaPocetna()
        {
            InitializeComponent();
        }

        private void bDokument_Click(object sender, EventArgs e)
        {
            new IsporukaPretragaPoDokumentu().Show();
            Close();
        }

    }
}