using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KIPS_WMS.Model;
using KIPS_WMS.Data;
using KIPS_WMS.NAV_WS;
using KIPS_WMS.Web;
using FileHelpers;

namespace KIPS_WMS.UI
{
    public partial class NoviKupciDijalog : NonFullscreenForm
    {
        public CustomerModel[] Customers;
        private readonly KIPS_wms _ws = WebServiceFactory.GetWebService();

        public NoviKupciDijalog()
        {
            InitializeComponent();

            var myAutoScaleFactor = new SizeF(
               AutoScaleDimensions.Width / 96F,
               AutoScaleDimensions.Height / 96F);

            Height = (int)(myAutoScaleFactor.Height * 70);
            getData();
        }

        private void NoviKupciDijalog_Activated(object sender, EventArgs e)
        {

        }

        private void NoviKupciDijalog_Paint(object sender, PaintEventArgs e)
        {

        }

        public void getData()
        {
            //Cursor.Current = Cursors.WaitCursor;
            List<Object> date = SQLiteHelper.oneRowQuery(DbStatements.GetSyncDateCustomers, new object[] { });
            DateTime dt = Convert.ToDateTime(date[0]);

            string csvCustomers = string.Empty;
            _ws.GetCustomers(ref csvCustomers, String.Empty, new DateTime(2015, 11, 1));
            CustomerModel[] customers;
            var engine = new FileHelperEngine(typeof(CustomerModel));
            customers = (CustomerModel[])engine.ReadString(csvCustomers);
            Customers = customers;

            foreach (CustomerModel customer in customers)
            {
                List<Object> foundCustomer = SQLiteHelper.oneRowQuery(DbStatements.FindCustomersStatementComplete, new object[] { customer.CustomerBarcode });

                if (foundCustomer.Count > 0)
                {
                    SQLiteHelper.nonQuery(DbStatements.UpdateCustomersStatement,
                        new object[] { customer.CustomerBarcode, customer.CustomerCode, customer.CustomerName });
                }
                else
                {
                    SQLiteHelper.insertQuery(DbStatements.InsertCustomersStatement,
                        new object[] { customer.CustomerBarcode, customer.CustomerCode, customer.CustomerName });
                }

            }
            DialogResult = DialogResult.OK;
            //Cursor.Current = Cursors.Default;

        }
    }
}