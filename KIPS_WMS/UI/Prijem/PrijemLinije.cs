using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using FileHelpers;
using KIPS_WMS.Model;
using KIPS_WMS.NAV_WS;
using KIPS_WMS.Properties;
using KIPS_WMS.Web;
using OpenNETCF.Windows.Forms;

namespace KIPS_WMS.UI.Prijem
{
    public partial class PrijemLinije : Form
    {
        private readonly string _receiptNo;
        private readonly KIPS_wms _ws = WebServiceFactory.GetWebService();
        private List<WarehouseReceiptLineModel> _filteredReceiptLines;
        private WarehouseReceiptLineModel _selectedLine;
        private List<WarehouseReceiptLineModel> _warehouseReceiptLines;

        public PrijemLinije()
        {
            InitializeComponent();
        }

        public PrijemLinije(string receiptNo)
        {
            InitializeComponent();

            _receiptNo = receiptNo;

            new Thread(GetData).Start();
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);

            Text = _receiptNo;
        }

        private void GetData()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                string warehouseReceiptsCsv = String.Empty;

                _ws.GetWarehouseReceiptLines("1", "1", "1", _receiptNo, ref warehouseReceiptsCsv);

                var engine = new FileHelperEngine(typeof (WarehouseReceiptLineModel));
                _warehouseReceiptLines =
                    ((WarehouseReceiptLineModel[]) engine.ReadString(warehouseReceiptsCsv)).ToList();

                listBox1.Invoke(new EventHandler((sender, e) => DisplayData(null)));
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

        private void bNazad_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DisplayData(string filterText)
        {
            listBox1.Items.Clear();
            listBox1.ItemHeight = 40;

            _selectedLine = null;
            _filteredReceiptLines = filterText != null
                ? _warehouseReceiptLines.FindAll(x => x.ItemNo.Contains(filterText))
                : _warehouseReceiptLines;

            foreach (WarehouseReceiptLineModel item in _filteredReceiptLines)
            {
                var listItem = new ListItem(item.ItemNo + Environment.NewLine + item.ItemDescription);
                listBox1.Items.Add(listItem);
            }
            if (_filteredReceiptLines.Count > 5)
            {
                listBox1.Items.Add(new ListItem());
            }

            tbPronadji.Focus();
        }

        private void bPronadji_Click(object sender, EventArgs e)
        {
            DisplayData(tbPronadji.Text);
        }

        private void bPonisti_Click(object sender, EventArgs e)
        {
            tbPronadji.Text = String.Empty;
            DisplayData(null);
        }

        private void bDalje_Click(object sender, EventArgs e)
        {
            if (_selectedLine != null)
            {
                // TODO
            }
            else
            {
                MessageBox.Show(Resources.OdaberiteLiniju, Resources.Greska);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            if (index == -1 || index >= _filteredReceiptLines.Count) return;

            _selectedLine = _filteredReceiptLines[index];
        }
    }
}