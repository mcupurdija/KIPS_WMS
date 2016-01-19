using System.Windows.Forms;
using KIPS_WMS.UI.Ponude;

namespace KIPS_WMS.UI
{
    public partial class Meni : Form
    {
        public Meni()
        {
            InitializeComponent();
        }

        private void bPonude_Click(object sender, System.EventArgs e)
        {
            new PonudePocetna().Show();
        }

        private void bPodesavanja_Click(object sender, System.EventArgs e)
        {
            new Settings().Show();
        }

        private void bLagerLista_Click(object sender, System.EventArgs e)
        {
            new LagerLista().Show();
        }
    }
}