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
        private readonly KIPS_wms _ws = WebServiceFactory.GetWebService();

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
                    Convert.ToInt16(damaged);
                }
                if (damaged.Length > 0)
                {
                    Convert.ToInt16(incomplete);
                }

                Cursor.Current = Cursors.WaitCursor;

                _ws.UpdateDamagedIncomplete("1", Convert.ToString(Utils.DocumentTypePrijem),
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
    }
}