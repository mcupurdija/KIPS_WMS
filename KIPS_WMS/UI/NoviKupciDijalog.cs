using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using FileHelpers;
using KIPS_WMS.Data;
using KIPS_WMS.Model;
using KIPS_WMS.NAV_WS;
using KIPS_WMS.Web;

namespace KIPS_WMS.UI
{
    public partial class NoviKupciDijalog : NonFullscreenForm
    {
        public delegate void CloseDelagate();

        private readonly KIPS_wms _ws = WebServiceFactory.GetWebService();

        public NoviKupciDijalog()
        {
            InitializeComponent();

            var myAutoScaleFactor = new SizeF(
                AutoScaleDimensions.Width/96F,
                AutoScaleDimensions.Height/96F);

            Height = (int) (myAutoScaleFactor.Height*50);

            var thread = new Thread(GetData);
            thread.Start();
        }

        public void GetData()
        {
            List<Object> date = SQLiteHelper.oneRowQuery(DbStatements.GetSyncDateCustomers, new object[] {});
            DateTime dt = Convert.ToDateTime(date[0]);

            string csvCustomers = string.Empty;

            _ws.GetCustomers(ref csvCustomers, String.Empty, dt);

            var engine = new FileHelperEngine(typeof (CustomerModel));
            var customers = (CustomerModel[]) engine.ReadString(csvCustomers);

            foreach (CustomerModel customer in customers)
            {
                List<Object> foundCustomer = SQLiteHelper.oneRowQuery(DbStatements.FindCustomersStatementComplete,
                    new object[] {customer.CustomerBarcode});

                if (foundCustomer.Count > 0)
                {
                    SQLiteHelper.nonQuery(DbStatements.UpdateCustomersStatement,
                        new object[] {customer.CustomerBarcode, customer.CustomerCode, customer.CustomerName});
                }
                else
                {
                    SQLiteHelper.insertQuery(DbStatements.InsertCustomersStatement,
                        new object[] {customer.CustomerBarcode, customer.CustomerCode, customer.CustomerName});
                }
            }

            Invoke((CloseDelagate) delegate
            {
                DialogResult = DialogResult.OK;
                Close();
            });
        }
    }
}