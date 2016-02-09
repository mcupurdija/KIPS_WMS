using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using FileHelpers;
using KIPS_WMS.Model;
using KIPS_WMS.NAV_WS;
using KIPS_WMS.Web;

namespace KIPS_WMS.UI.Ponude
{
    public partial class PonudePocetna : Form
    {
        private readonly MobileWMSSync _ws = WebServiceFactory.GetWebService();

        public PonudePocetna()
        {
            InitializeComponent();

            QuoteHeaderHelper savedQuoteHeader = RegistryUtils.GetQuoteHeader();
            if (savedQuoteHeader == null) return;

            Cursor.Current = Cursors.WaitCursor;
            List<ItemQuoteModel> savedQuoteLines = RegistryUtils.GetQuoteLines();
            new PonudaKorpa(savedQuoteHeader.CustomerCode, savedQuoteHeader.CustomerName,
                savedQuoteHeader.IsAuthenticated, savedQuoteHeader.DocumentNo, savedQuoteLines).Show();
            Cursor.Current = Cursors.Default;
            Close();
        }

        private void bNova_Click(object sender, EventArgs e)
        {
            new NovaPonuda().Show();
            Close();
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

                    _ws.GetQuote(quoteNo, RegistryUtils.GetLastUsername(), RegistryUtils.GetLoginData().Magacin, ref customerCode, ref customerName, ref isAuthenticatedCustomer,
                        ref quoteLinesCsv);

                    var engine = new FileHelperEngine(typeof (ItemQuoteModel));
                    var quoteItems = (ItemQuoteModel[]) engine.ReadString(quoteLinesCsv);

                    new PonudaKorpa(customerCode, customerName, isAuthenticatedCustomer, quoteNo, quoteItems.ToList()).Show();
                    Close();
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
        }

        private void toolBar1_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            Close();
        }
    }
}