using System;
using System.Collections.Generic;
using System.Windows.Forms;
using KIPS_WMS.Data;
using KIPS_WMS.NAV_WS;
using KIPS_WMS.UI;
using KIPS_WMS.Web;

namespace KIPS_WMS
{
    public partial class Form1 : Form
    {

        private readonly KIPS_wms _ws = WebServiceFactory.GetWebService();

        public Form1()
        {
            InitializeComponent();
        }

        private void Test()
        {
            new Meni().Show();

            try
            {
//                List<Object[]> dates = SQLiteHelper.multiRowQuery("SELECT * FROM SyncData", new object[] {});
//                MessageBox.Show("Test: " + (string) dates[0][1] + " " + (string) dates[0][2]);


//                Cursor.Current = Cursors.WaitCursor;
//                string csvCustomers = String.Empty;
//                _ws.GetCustomers(ref csvCustomers, String.Empty, new DateTime(2015, 12, 1));
//
//                MessageBox.Show(csvCustomers);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
            
        }

        private void bTest_Click(object sender, EventArgs e)
        {
            Test();
        }
    }
}