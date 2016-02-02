using System;
using System.Collections.Generic;
using System.Drawing;
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
    public partial class PrijemPretragaPoDokumentu : Form
    {
        private readonly KIPS_wms _ws = WebServiceFactory.GetWebService();
        private List<WarehouseReceiptModel> _filteredList;
        private WarehouseReceiptModel _selectedReceipt;
        private List<WarehouseReceiptModel> _warehouseReceipts;

        public PrijemPretragaPoDokumentu()
        {
            InitializeComponent();

            listBox1.DrawMode = DrawMode.OwnerDrawFixed;

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
                _warehouseReceipts.Sort((x, y) => String.Compare(x.SourceDescription, y.SourceDescription, StringComparison.Ordinal));
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

            var listItem = new ListItem();
            for (int i = 0; i < _filteredList.Count; i++)
            {
                listBox1.Items.Add(listItem);
            }
            if (listBox1.Items.Count > 5)
            {
                listBox1.Items.Add(new ListItem {Tag = 0});
            }

            tbPronadji.Focus();
        }

        private void bPronadji_Click(object sender, EventArgs e)
        {
            string searchQuery = tbPronadji.Text.Trim();
            if (searchQuery.Length == 0) return;

            DisplayData(searchQuery);
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
            if (index == -1 || index >= listBox1.Items.Count || listBox1.Items[index].Tag != null)
            {
                _selectedReceipt = null;
                return;
            }

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
                new PrijemLinije(_selectedReceipt.ReceiptCode).Show();
            }
            else
            {
                MessageBox.Show(Resources.OdaberiteDokument, Resources.Greska);
            }
        }

        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            int index = e.Index;
            if (index >= listBox1.Items.Count || listBox1.Items[index].Tag != null) return;

            SolidBrush brush;
            if (e.State == DrawItemState.Selected)
            {
                e.DrawBackground(Color.Blue);
                brush = new SolidBrush(Color.White);
            }
            else
            {
                e.DrawBackground(index%2 == 0 ? SystemColors.Control : Color.White);
                brush = new SolidBrush(Color.Black);
            }

            WarehouseReceiptModel line = _filteredList[index];

            string firstLine = line.SourceDescription;
            string secondLine = string.Format("{0} - {1}", line.ReceiptCode, line.ReceiptDate);

            e.Graphics.DrawString(firstLine,
                new Font(FontFamily.GenericSansSerif, 8F, FontStyle.Bold), brush, e.Bounds.Left + 3, e.Bounds.Top,
                new StringFormat {FormatFlags = StringFormatFlags.NoWrap});
            e.Graphics.DrawString(secondLine,
                new Font(FontFamily.GenericSansSerif, 8F, FontStyle.Regular), brush, e.Bounds.Left + 3,
                e.Bounds.Top + 20, new StringFormat {FormatFlags = StringFormatFlags.NoWrap});
        }
    }
}