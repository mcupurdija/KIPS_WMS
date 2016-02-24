using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using KIPS_WMS.Model;
using KIPS_WMS.Properties;

namespace KIPS_WMS.UI.Ostalo
{
    public partial class OdabirMagacina : NonFullscreenForm
    {
        private readonly List<LoginModel> _loginData;
        public int SelectedWarehouseIndex = -1;

        public OdabirMagacina(List<LoginModel> loginData)
        {
            InitializeComponent();

            _loginData = loginData;

            var myAutoScaleFactor = new SizeF(
                AutoScaleDimensions.Width/96F,
                AutoScaleDimensions.Height/96F);

            Height = (int) (myAutoScaleFactor.Height*110);

            DisplayData();
        }

        private void DisplayData()
        {
            listView1.Clear();
            listView1.View = View.List;
            foreach (LoginModel item in _loginData)
            {
                var lvi = new ListViewItem(new[]
                    {
                        string.Format("{0} / {1}", item.Magacin, item.Podmagacin)
                    });
                listView1.Items.Add(lvi);
            }

            if (listView1.Items.Count > 0)
            {
                listView1.Focus();
                listView1.Items[0].Selected = true;
            }
        }

        private void listView1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (listView1.SelectedIndices.Count != 1) return;

            SelectedWarehouseIndex = listView1.SelectedIndices[0];
        }

        private void bDalje_Click(object sender, System.EventArgs e)
        {
            if (SelectedWarehouseIndex == -1)
            {
                MessageBox.Show("Potrebno je da odaberete magacin", Resources.Greska);
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void bOdustani_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Abort;
            Close();
        }

        private void listView1_KeyUp(object sender, KeyEventArgs e)
        {
            if (listView1.SelectedIndices.Count == 1 && e.KeyCode == Keys.Return)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

    }
}