using System;
using System.Net;
using System.Web.Services.Protocols;
using System.Windows.Forms;
using FileHelpers;
using KIPS_WMS.Model;
using KIPS_WMS.NAV_WS;
using KIPS_WMS.Web;

namespace KIPS_WMS.UI.Ponude
{
    public partial class PonudePocetna : Form
    {
        private readonly KIPS_wms _ws = WebServiceFactory.GetWebService();

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
            LoadQuote(0);
        }

        private void tbUcitaj_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadQuote(1);
            }
        }

        private void LoadQuote(int isAuthenticated)
        {
            string quoteNo = tbUcitaj.Text;
            int isAuthenticatedCustomer = isAuthenticated;

            if (quoteNo.Length > 0)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;

                    string customerCode = String.Empty;
                    string customerName = String.Empty;
                    string quoteLinesCsv = String.Empty;

                    _ws.GetQuote(quoteNo, "1", "", ref customerCode, ref customerName, ref isAuthenticatedCustomer,
                        ref quoteLinesCsv);

                    var engine = new FileHelperEngine(typeof (ItemQuoteModel));
                    var quoteItems = (ItemQuoteModel[]) engine.ReadString(quoteLinesCsv);

                    new PonudaKorpa(quoteNo, customerCode, customerName, quoteItems).Show();
                }
                catch (SoapException se)
                {
                    MessageBox.Show(se.Message, "SoapException");
                }
                catch (WebException we)
                {
                    MessageBox.Show(we.Message, "WebException");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Exception");
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }
        }
    }
}