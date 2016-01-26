using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OpenNETCF.Windows.Forms;
using KIPS_WMS.Model;
using KIPS_WMS.NAV_WS;
using KIPS_WMS.Web;
using System.Threading;
using FileHelpers;

namespace KIPS_WMS.UI.Prijem
{
    public partial class PrijemLinije : Form
    {
        private readonly KIPS_wms _ws = WebServiceFactory.GetWebService();
        private readonly string _receiptNo;
        private List<WarehouseReceiptLineModel> _warehouseReceiptLines;
        private WarehouseReceiptLineModel _selectedLine;

        public PrijemLinije()
        {
            InitializeComponent();
        }

        public PrijemLinije(string receiptNo)
        {
            InitializeComponent();

//            _receiptNo = receiptNo;
            _receiptNo = "MPR16-0004";
            new Thread(GetData).Start();
        }

        private void GetData()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                string warehouseReceiptsCsv = String.Empty;

                _ws.GetWarehouseReceiptLines("1", "1", "1", _receiptNo, ref warehouseReceiptsCsv);

                var engine = new FileHelperEngine(typeof(WarehouseReceiptLineModel));
                _warehouseReceiptLines = ((WarehouseReceiptLineModel[])engine.ReadString(warehouseReceiptsCsv)).ToList();
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

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);

            Text = _receiptNo;
        }

        private void bNazad_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DisplayData(string filterText)
        {
            listBox1.Items.Clear();

            List<WarehouseReceiptLineModel> data = _warehouseReceiptLines;
            if (filterText != null)
            {
                data = _warehouseReceiptLines.FindAll( x => x.ItemNo.Contains(filterText));
            }

            foreach (var item in data)
            {
                var listItem = new ListItem(string.Format("{0} / {1}{2}{3} / {4} / {5}", item.ItemNo, item.ItemDescription, Environment.NewLine, item.ItemVariant, item.QuantityOutstanding, item.QuantityToReceive));
                listBox1.Items.Add(listItem);
            }

            tbPronadji.Focus();
        }

        private void bPronadji_Click(object sender, EventArgs e)
        {
            DisplayData(tbPronadji.Text);
        }

        private void bPonisti_Click(object sender, EventArgs e)
        {
            DisplayData(null);
        }

        private void bDalje_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            if (index == -1) return;

            _selectedLine = _warehouseReceiptLines[index];
        }
    }
}