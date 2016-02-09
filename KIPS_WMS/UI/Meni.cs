﻿using System.Windows.Forms;
using KIPS_WMS.UI.Ostalo;
using KIPS_WMS.UI.Ponude;
using KIPS_WMS.UI.Prijem;
using KIPS_WMS.UI.Skladistenje;
using KIPS_WMS.UI.Izdvajanje;
using KIPS_WMS.UI.Preklasifikacija;
using KIPS_WMS.Model;
using System;
using KIPS_WMS.UI.Isporuka;

namespace KIPS_WMS.UI
{
    public partial class Meni : Form
    {
        public Meni()
        {
            InitializeComponent();
            LoginModel login = RegistryUtils.GetLoginData();
            if (login.RadiSkladistenje == 0) {
                bSkladistenja.Enabled = false;
            }
            if (login.RadiPrijem == 0)
            {
                bMagPrijemnice.Enabled = false;
            }
            if (login.RadiPreklasifikaciju == 0)
            {
                bPreklasifikacija.Enabled = false;
            }
            if (login.RadiPonude == 0)
            {
                bPonude.Enabled = false;
            }
            if (login.RadiIzdvajanje == 0)
            {
                bIzdvajanja.Enabled = false;
            }
            if (login.RadiIsporuku == 0)
            {
                bMagIsporuke.Enabled = false;
            }
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
            new Form1().Show();
        }

        private void bLogout_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void bMagIsporuke_Click(object sender, EventArgs e)
        {
            new IsporukaPretragaPoDokumentu().Show();
        }
    }
}