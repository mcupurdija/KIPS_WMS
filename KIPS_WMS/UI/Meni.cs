using System.Windows.Forms;
using KIPS_WMS.UI.Ostalo;
using KIPS_WMS.UI.Ponude;
using KIPS_WMS.UI.Prijem;
using KIPS_WMS.UI.Skladistenje;
using KIPS_WMS.UI.Izdvajanje;
using KIPS_WMS.UI.Preklasifikacija;

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

        private void bPreklasifikacija_Click(object sender, System.EventArgs e)
        {
            new PreklasifikacijaDetalji().Show();
        }

        private void bUvozPodataka_Click(object sender, System.EventArgs e)
        {
            new CsvImport().Show();
        }

        private void bMagPrijemnice_Click(object sender, System.EventArgs e)
        {
            new PrijemPocetna().Show();
        }

        private void bSkladistenja_Click(object sender, System.EventArgs e)
        {
            new SkladistenjePocetna().Show();
        }

        private void bIzdvajanja_Click(object sender, System.EventArgs e)
        {
            new IzdvajanjePocetna().Show();
        }

        private void bPopis_Click(object sender, System.EventArgs e)
        {
            var pracenje = new Pracenje("BROJ",5,2);
            DialogResult result = pracenje.ShowDialog();
            if (result == DialogResult.OK) {
                MessageBox.Show(pracenje._lines.ToString());
            }
        }
    }
}