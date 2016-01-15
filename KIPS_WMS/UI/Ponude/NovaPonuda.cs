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
    public partial class NovaPonuda : Form
    {
        public NovaPonuda()
        {
            InitializeComponent();
        }

        private void NovaPonuda_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void bPronadji_Click(object sender, EventArgs e)
        {

        }

        private void bNepoznatKupac_Click(object sender, EventArgs e)
        {

        }

        private void bKreiraj_Click(object sender, EventArgs e)
        {

        }

        private void bNoviKupci_Click(object sender, EventArgs e)
        {

        }

        private void tbPronadji_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // SA SKENERA
            }
        }
    }
}