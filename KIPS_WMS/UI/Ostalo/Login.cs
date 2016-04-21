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
            DoLogin();
        }

        private void DoLogin()
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

            // PROVERA BROJA KORISNIKA
//            string userCount = Utils.CheckUserCount(new DeviceModel(Device.GetDeviceId()));
//            if (userCount != null)
//            {
//                MessageBox.Show(userCount, Resources.Greska);
//                return;
//            }

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                string loginDataCsv = String.Empty;

                _ws.LogIn(username, password, ref loginDataCsv);

                var engine = new FileHelperEngine(typeof (LoginModel));
                _loginData = ((LoginModel[]) engine.ReadString(loginDataCsv)).ToList();

                Cursor.Current = Cursors.Default;

                if (_loginData.Count > 1)
                {
                    var odabirMagacina = new OdabirMagacina(_loginData);
                    DialogResult result = odabirMagacina.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        SaveLoginDataContinue(username, _loginData[odabirMagacina.SelectedWarehouseIndex]);
                    }
                }
                else
                {
                    SaveLoginDataContinue(username, _loginData[0]);
                }
            }
            catch (Exception ex)
            {
                Utils.GeneralExceptionProcessing(ex);
                Cursor.Current = Cursors.Default;
            }
        }

        private void SaveLoginDataContinue(string username, LoginModel selectedWarehouse)
        {
            RegistryUtils.SaveLastUsername(username);
            RegistryUtils.SaveLoginData(selectedWarehouse);

            new Meni().Show();
        }

        private void bIzlaz_Click(object sender, EventArgs e)
        {
            RegistryUtils.DeleteLoginData();
            Close();
        }

        private void tbUsername_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbPassword.Focus();
            }
        }

        private void tbPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DoLogin();
            }
        }

        private void toolBar1_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            switch (toolBar1.Buttons.IndexOf(e.Button))
            {
                case 0:
                    DoLogin();
                    break;
                case 1:
                    RegistryUtils.DeleteLoginData();
                    Close();
                    break;
            }
        }
    }
}