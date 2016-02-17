using System;
using System.Drawing;
using System.Windows.Forms;
using KIPS_WMS.Model;
using KIPS_WMS.NAV_WS;
using KIPS_WMS.Properties;
using KIPS_WMS.Web;

namespace KIPS_WMS.UI.Prijem
{
    public partial class OstecenoNekompletnoDijalog : NonFullscreenForm
    {
        private readonly WarehouseReceiptLineModel _selectedLine;
        private readonly MobileWMSSync _ws = WebServiceFactory.GetWebService();

        public OstecenoNekompletnoDijalog(WarehouseReceiptLineModel selectedLine)
        {
            InitializeComponent();

            _selectedLine = selectedLine;

            var myAutoScaleFactor = new SizeF(
                AutoScaleDimensions.Width/96F,
                AutoScaleDimensions.Height/96F);

            Height = (int) (myAutoScaleFactor.Height*110);

            tbJedinicaMere.Text = _selectedLine.UnitOfMeasureCode;

            tbOsteceno.Focus();
        }

        private void bPosalji_Click(object sender, EventArgs e)
        {
            string damaged = tbOsteceno.Text.Trim();
            string incomplete = tbNekompletno.Text.Trim();

            try
            {
                if (damaged.Length > 0)
                {
                    decimal.Parse(damaged,Utils.GetLocalCulture());
                }
                if (incomplete.Length > 0)
                {
                    decimal.Parse(incomplete, Utils.GetLocalCulture());
                }

                Cursor.Current = Cursors.WaitCursor;

                _ws.UpdateDamagedIncomplete(RegistryUtils.GetLastUsername(), _selectedLine.DocumentNo,
                    Convert.ToInt16(_selectedLine.LineNo), damaged, incomplete);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("Proverite format unetih podataka", Resources.Greska);
            }
            catch (Exception ex)
            {
                Utils.GeneralExceptionProcessing(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void bOdustani_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
            Close();
        }

        private void tbOsteceno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                tbOsteceno.Text += ",";
                tbOsteceno.SelectionStart = tbOsteceno.Text.Length;
                tbOsteceno.SelectionLength = 0;
                e.Handled = true;
            }
        }

        private void tbNekompletno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                tbNekompletno.Text += ",";
                tbNekompletno.SelectionStart = tbNekompletno.Text.Length;
                tbNekompletno.SelectionLength = 0;
                e.Handled = true;
            }
        }
    }
}