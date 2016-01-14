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
    public partial class PonudePocetna : Form
    {
        public PonudePocetna()
        {
            InitializeComponent();
        }

        private void bNova_Click(object sender, EventArgs e)
        {
            new NovaPonuda().Show();
        }

        private void bUcitaj_Click(object sender, EventArgs e)
        {

        }
    }
}