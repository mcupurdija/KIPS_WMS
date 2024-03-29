﻿using System;
using System.Drawing;
using System.Windows.Forms;
using KIPS_WMS.Model;
using KIPS_WMS.Properties;
using KIPS_WMS.UI.BarkodTest;
using KIPS_WMS.UI.Isporuka;
using KIPS_WMS.UI.Izdvajanje;
using KIPS_WMS.UI.Ostalo;
using KIPS_WMS.UI.Ponude;
using KIPS_WMS.UI.Preklasifikacija;
using KIPS_WMS.UI.Prijem;
using KIPS_WMS.UI.Skladistenje;
using KIPS_WMS.NAV_WS;
using KIPS_WMS.Web;
using KIPS_WMS.UI.Popis;
using System.Collections.Generic;

namespace KIPS_WMS.UI
{
    public partial class Meni : Form
    {
        private readonly MobileWMSSync _ws = WebServiceFactory.GetWebService();
        private List<ItemInventoryModel> _inventory;

        public Meni()
        {
            InitializeComponent();
            _inventory = new List<ItemInventoryModel>();
            LoginModel login = RegistryUtils.GetLoginData();

            if (login.RadiSkladistenje == 0)
            {
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

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);

            Text = string.Format("{0} - {1}", RegistryUtils.GetLastUsername(), "Meni");
        }

        private void bPonude_Click(object sender, EventArgs e)
        {
            try
            {
                _ws.TestIsAppVersionValid(Utils.AppVersion);
                new PonudePocetna().Show();
            }
            catch (Exception ex)
            {
                Utils.GeneralExceptionProcessing(ex);
            }
        }

        private void bLagerLista_Click(object sender, EventArgs e)
        {
            if (Utils.CheckDate())
            {
                new LagerLista().Show();
            }
            else
            {
                ShowErrorMessage();
            }
        }

        private void bPreklasifikacija_Click(object sender, EventArgs e)
        {
            if (Utils.CheckDate())
            {
                new PreklasifikacijaDetalji().Show();
            }
            else
            {
                ShowErrorMessage();
            }
        }

        private void bMagPrijemnice_Click(object sender, EventArgs e)
        {
            if (Utils.CheckDate())
            {
                new PrijemPocetna().Show();
            }
            else
            {
                ShowErrorMessage();
            }
        }

        private void bSkladistenja_Click(object sender, EventArgs e)
        {
            if (Utils.CheckDate())
            {
                new SkladistenjePocetna().Show();
            }
            else
            {
                ShowErrorMessage();
            }
        }

        private void bIzdvajanja_Click(object sender, EventArgs e)
        {
            if (Utils.CheckDate())
            {
                new IzdvajanjePretragaPoDokumentu().Show();
            }
            else
            {
                ShowErrorMessage();
            }
        }

        private void bPopis_Click(object sender, EventArgs e)
        {
            var popis = new NoviPopis(_inventory);
            DialogResult result = popis.ShowDialog();

            if (result == DialogResult.OK) {
                _inventory = popis._inventory;
            }
        }

        private void toolBar1_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            switch (toolBar1.Buttons.IndexOf(e.Button))
            {
                case 0:
                    contextMenu1.Show(toolBar1, new Point(10, 10));
                    break;
                case 1:
                    Close();
                    break;
            }
        }

        private void cUnosBarkoda_Click(object sender, EventArgs e)
        {
            //            if (Utils.CheckDate())
            //            {
            //                
            //            }
            //            else
            //            {
            //                ShowErrorMessage();
            //            }
        }

        private void cCrossDocking_Click(object sender, EventArgs e)
        {
            //            if (Utils.CheckDate())
            //            {
            //                
            //            }
            //            else
            //            {
            //                ShowErrorMessage();
            //            }
        }

        private void cUvozPodataka_Click(object sender, EventArgs e)
        {
            if (Utils.CheckDate())
            {
                new CsvImport().Show();
            }
            else
            {
                ShowErrorMessage();
            }
        }

        private void cPodesavanja_Click(object sender, EventArgs e)
        {
            if (Utils.CheckDate())
            {
                new Settings().Show();
            }
            else
            {
                ShowErrorMessage();
            }
        }

        private void bMagIsporuke_Click(object sender, EventArgs e)
        {
            if (Utils.CheckDate())
            {
                new IsporukaPretragaPoDokumentu().Show();
            }
            else
            {
                ShowErrorMessage();
            }
        }

        public static void ShowErrorMessage()
        {
            MessageBox.Show("Server na adresi 192.168.10.18 trenutno nije dostupan, molimo kontaktirajte administratora", Resources.Greska);
        }

        private void cUcitajNoveArtikle_Click(object sender, EventArgs e)
        {
            var loadingForm = new NoviArtikliDijalog();
            DialogResult result = loadingForm.ShowDialog();
        }

        private void bBarkodTest_Click(object sender, EventArgs e)
        {
            var barkodTest = new BarkodTest.BarkodTest();
            DialogResult result = barkodTest.ShowDialog();
        }
    }
}