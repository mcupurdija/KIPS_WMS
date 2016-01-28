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

namespace KIPS_WMS.UI.Skladistenje
{
    public partial class SkladistenjePretragaPoDokumentu : Form
    {
        private readonly KIPS_wms _ws = WebServiceFactory.GetWebService();
        private List<WarehouseReceiptModel> _filteredList;
        private WarehouseReceiptModel _selectedReceipt;
        private List<WarehouseReceiptModel> _warehouseReceipts;

        public SkladistenjePretragaPoDokumentu()
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

                var engine = new FileHelperEngine(typeof (WarehouseReceiptModel));
                _warehouseReceipts = ((WarehouseReceiptModel[]) engine.ReadString(warehouseReceiptsCsv)).ToList();
                _filteredList = _warehouseReceipts;

                Invoke(new EventHandler((sender, e) => DisplayData(null)));
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

        private void DisplayData(string documentNo)
        {
            listBox1.Items.Clear();

            _selectedReceipt = null;
            _filteredList = documentNo != null
                ? _warehouseReceipts.FindAll(x => x.ReceiptCode.Contains(documentNo))
                : _warehouseReceipts;

            foreach (WarehouseReceiptModel item in _filteredList)
            {
                var listItem =
                    new ListItem(string.Format("{0} - {1}{2}{3} - {4}", item.ReceiptCode, item.ReceiptDate,
                        Environment.NewLine, item.SourceCode, item.SourceDescription));
                listBox1.Items.Add(listItem);
            }
            if (listBox1.Items.Count > 5)
            {
                listBox1.Items.Add(new ListItem());
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
            if (index == -1 || index >= listBox1.Items.Count - 1) return;

            _selectedReceipt = _filteredList[index];
        }

        private void bNazad_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bDalje_Click(object sender, EventArgs e)
        {
            if (_selectedReceipt != null)
            {
                new SkladistenjeLinije(_selectedReceipt.ReceiptCode).Show();
            }
            else
            {
                MessageBox.Show(Resources.OdaberiteDokument, Resources.Greska);
            }
        }
    }
}