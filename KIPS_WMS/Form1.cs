using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using FileHelpers;
using KIPS_WMS.Model;
using KIPS_WMS.NAV_WS;
using KIPS_WMS.UI.Ponude;
using KIPS_WMS.Web;
using OpenNETCF.Windows.Forms;

namespace KIPS_WMS
{
    public partial class Form1 : Form
    {

        private readonly MobileWMSSync _ws = WebServiceFactory.GetWebService();
        private List<WarehouseReceiptLineModel> _warehouseReceiptLines;


        public Form1()
        {
            InitializeComponent();
        }

        private void Test()
        {
            new NovaPonuda().Show();

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

        private void GetData()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                string warehouseReceiptsCsv = String.Empty;

                _ws.GetWarehouseReceipts("1", "001", "002", "", ref warehouseReceiptsCsv, Utils.AppVersion);

                _ws.GetWarehouseReceiptLines("1", "1", "1", "MPR15-0469", ref warehouseReceiptsCsv);

                var engine = new FileHelperEngine(typeof(WarehouseReceiptLineModel));
                _warehouseReceiptLines =
                    ((WarehouseReceiptLineModel[])engine.ReadString(warehouseReceiptsCsv)).ToList();

                listBox1.Items.Clear();
                listBox1.ItemHeight = 40;

                foreach (WarehouseReceiptLineModel item in _warehouseReceiptLines)
                {
                    var listItem =
                        new ListItem(item.ItemNo + Environment.NewLine + item.ItemDescription);
                    listBox1.Items.Add(listItem);
                }
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

        private void bTest_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
        
    }
}