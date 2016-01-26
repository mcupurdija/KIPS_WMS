using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using FileHelpers;
using KIPS_WMS.Model;
using KIPS_WMS.NAV_WS;
using KIPS_WMS.Web;
using OpenNETCF.Windows.Forms;

namespace KIPS_WMS.UI.Prijem
{
    public partial class PrijemPretragaPoDokumentu : Form
    {
        private readonly KIPS_wms _ws = WebServiceFactory.GetWebService();
        private List<WarehouseReceiptModel> _warehouseReceipts;
        private WarehouseReceiptModel _selectedReceipt;

        public PrijemPretragaPoDokumentu()
        {
            InitializeComponent();

            new Thread(GetData).Start();
        }

        private void GetData()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                string warehouseReceiptsCsv = String.Empty;

                _ws.GetWarehouseReceipts("1", "001", "002", "", ref warehouseReceiptsCsv);

                var engine = new FileHelperEngine(typeof(WarehouseReceiptModel));
                _warehouseReceipts = ((WarehouseReceiptModel[]) engine.ReadString(warehouseReceiptsCsv)).ToList();
            }
            catch (Exception ex)
            {
                Utils.GeneralExceptionProcessing(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }

            Invoke(new EventHandler((sender, e) => DisplayData(null)));
        }

        private void DisplayData(string documentNo)
        {
            listBox1.Items.Clear();

            var data = _warehouseReceipts;
            if (documentNo != null)
            {
                data = new List<WarehouseReceiptModel> {_warehouseReceipts.Find(x => x.ReceiptCode.Contains(documentNo))};
            }

            foreach (var item in data)
            {
                var listItem = new ListItem(string.Format("{0} - {1}{2}{3} - {4}", item.ReceiptCode, item.ReceiptDate, Environment.NewLine, item.SourceCode, item.SourceDescription));
                listBox1.Items.Add(listItem);
            }
            
            tbPronadji.Focus();
        }

        private void bPronadji_Click(object sender, EventArgs e)
        {
            DisplayData(tbPronadji.Text);
        }

        private void bReset_Click(object sender, EventArgs e)
        {
            DisplayData(null);
            tbPronadji.Text = String.Empty;
            tbPronadji.Focus();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            if (index == -1) return;

            _selectedReceipt = _warehouseReceipts[index];
        }
    }
}