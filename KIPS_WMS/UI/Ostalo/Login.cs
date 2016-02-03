using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using FileHelpers;
using KIPS_WMS.Model;
using KIPS_WMS.NAV_WS;
using KIPS_WMS.Properties;
using KIPS_WMS.Web;

namespace KIPS_WMS.UI.Ostalo
{
    public partial class Login : Form
    {
        private readonly MobileWMSSync _ws = WebServiceFactory.GetWebService();
        private List<LoginModel> _loginData;

        public Login()
        {
            InitializeComponent();

            string lastUsername = RegistryUtils.GetLastUsername();
            if (lastUsername != null)
            {
                tbUsername.Text = lastUsername;
            }

            tbPassword.Text = String.Empty;
            tbPassword.Focus();
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);

            tbPassword.Text = String.Empty;
            tbPassword.Focus();
        }

        private void bLogin_Click(object sender, EventArgs e)
        {
            string username = tbUsername.Text.Trim();
            string password = tbPassword.Text.Trim();

            if (username.Length == 0)
            {
                MessageBox.Show("Potrebno je da unesete korisničko ime", Resources.Greska);
                tbUsername.Focus();
                return;
            }

            if (password.Length == 0)
            {
                MessageBox.Show("Potrebno je da unesete lozinku", Resources.Greska);
                tbPassword.Focus();
                return;
            }

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                string loginDataCsv = String.Empty;

                _ws.LogIn(username, password, ref loginDataCsv);

                var engine = new FileHelperEngine(typeof (LoginModel));
                _loginData = ((LoginModel[]) engine.ReadString(loginDataCsv)).ToList();

                Cursor.Current = Cursors.Default;

                var odabirMagacina = new OdabirMagacina(_loginData);
                DialogResult result = odabirMagacina.ShowDialog();

                if (result == DialogResult.OK)
                {
                    LoginModel selectedWarehouse = _loginData[odabirMagacina.SelectedWarehouseIndex];

                    RegistryUtils.SaveLastUsername(username);
                    RegistryUtils.SaveLoginData(selectedWarehouse);

                    new Meni().Show();
                }
            }
            catch (Exception ex)
            {
                Utils.GeneralExceptionProcessing(ex);
                Cursor.Current = Cursors.Default;
            }
        }

        private void bIzlaz_Click(object sender, EventArgs e)
        {
            RegistryUtils.DeleteLoginData();
            Close();
        }
    }
}