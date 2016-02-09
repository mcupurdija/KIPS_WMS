using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using FileHelpers;
using KIPS_WMS.Data;
using KIPS_WMS.Model;
using KIPS_WMS.NAV_WS;
using KIPS_WMS.Properties;
using KIPS_WMS.Web;
using OpenNETCF.Windows.Forms;

namespace KIPS_WMS.UI.Isporuka
{
    public partial class IsporukaLinije : Form
    {
        private readonly string _shipmentNo;
        private readonly MobileWMSSync _ws = WebServiceFactory.GetWebService();
        private string _barcode;
        private List<WarehouseShipmentLineModel> _filteredShipmentLines;
        private WarehouseShipmentLineModel _selectedLine;
        private List<WarehouseShipmentLineModel> _warehouseShipmentLines;

        public IsporukaLinije(string shipmentNo)
        {
            InitializeComponent();

            _shipmentNo = shipmentNo;
            listBox1.DrawMode = DrawMode.OwnerDrawFixed;

            GetData();
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);

            _barcode = null;
            Text = _shipmentNo;
        }

        private void GetData()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                string warehouseShipmentsCsv = String.Empty;

                var loginData = RegistryUtils.GetLoginData();
                _ws.GetWarehouseShipmentLines(RegistryUtils.GetLastUsername(), loginData.Magacin, loginData.Podmagacin,
                    _shipmentNo, ref warehouseShipmentsCsv);

                var engine = new FileHelperEngine(typeof (WarehouseShipmentLineModel));
                _warehouseShipmentLines =
                    ((WarehouseShipmentLineModel[])engine.ReadString(warehouseShipmentsCsv)).ToList();

                DisplayData(null, false);
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
            listBox1.Dispose();
            Close();
        }

        private void DisplayData(string filterText, bool fromScanner)
        {
            if (_warehouseShipmentLines == null)
            {
                return;
            }

            listBox1.Items.Clear();
            listBox1.ItemHeight = 40;

            _selectedLine = null;
            listBox1.SelectedIndex = -1;

            _filteredShipmentLines = filterText != null
                ? _warehouseShipmentLines.FindAll(x => x.ItemNo.Contains(filterText) || x.ItemDescription.Contains(filterText))
                : _warehouseShipmentLines;

            var listItem = new ListItem();
            for (int i = 0; i < _filteredShipmentLines.Count; i++)
            {
                listBox1.Items.Add(listItem);
            }
            if (listBox1.Items.Count > 5)
            {
                listBox1.Items.Add(new ListItem {Tag = 0});
            }

            tbPronadji.Focus();

            if (fromScanner && _filteredShipmentLines.Count == 1)
            {
                _selectedLine = _filteredShipmentLines[0];
                ShowLineDetailsForm(_barcode);
            }
        }

        private void tbPronadji_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;

            List<object[]> query = SQLiteHelper.multiRowQuery(DbStatements.FindItemsStatementBarcode,
                new object[] { tbPronadji.Text.Trim() });
            if (query.Count == 1)
            {
                _barcode = query[0][DatabaseModel.ItemDbModel.ItemBarcode].ToString();
                DisplayData(query[0][DatabaseModel.ItemDbModel.ItemCode].ToString(), true);
            }
            if (query.Count == 0) {
                query = SQLiteHelper.multiRowQuery(DbStatements.FindItemsStatementCode,
                new object[] { tbPronadji.Text.Trim() });
                if (query.Count == 1)
                {
                    _barcode = query[0][DatabaseModel.ItemDbModel.ItemBarcode].ToString();
                    DisplayData(query[0][DatabaseModel.ItemDbModel.ItemCode].ToString(), true);
                }
                else{
                    MessageBox.Show("Nije pronađen aritkal.", Resources.Greska);
                }
            }
        }

        private void bPronadji_Click(object sender, EventArgs e)
        {
            DisplayData(tbPronadji.Text, false);
        }

        private void bPonisti_Click(object sender, EventArgs e)
        {
            tbPronadji.Text = String.Empty;
            DisplayData(null, false);
        }

        private void bDalje_Click(object sender, EventArgs e)
        {
            if (_selectedLine != null)
            {
                ShowLineDetailsForm(null);
            }
            else
            {
                MessageBox.Show(Resources.OdaberiteLiniju, Resources.Greska);
            }
        }

        private void ShowLineDetailsForm(string barcode)
        {
            var isporukaDetalji = new IsporukaDetalji(_shipmentNo, barcode, _selectedLine, _warehouseShipmentLines);
            DialogResult result = isporukaDetalji.ShowDialog();

            if (result == DialogResult.Yes)
            {
                _warehouseShipmentLines = isporukaDetalji.WarehouseShipmentLines;
                DisplayData(null, false);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            if (index == -1 || index >= listBox1.Items.Count || listBox1.Items[index].Tag != null)
            {
                _selectedLine = null;
                return;
            }

            _selectedLine = _filteredShipmentLines[index];
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

            WarehouseShipmentLineModel line = _filteredShipmentLines[index];

            var rectangle = new Rectangle(e.Bounds.Left, e.Bounds.Top, 7, e.Bounds.Height);
            e.Graphics.FillRectangle(new SolidBrush(GetLineStatusColor(line.QuantityOutstanding, line.QuantityToReceive)), rectangle);
            e.Graphics.DrawRectangle(new Pen(Color.White), rectangle);

            string firstLine = string.Format("{0} {1}", line.ItemNo, line.ItemDescription);
            string secondLine = string.Format("{0} / {1}", line.QuantityToReceive, line.QuantityOutstanding);

            e.Graphics.DrawString(firstLine,
                new Font(FontFamily.GenericSansSerif, 8F, FontStyle.Bold), brush, e.Bounds.Left + 10, e.Bounds.Top,
                new StringFormat {FormatFlags = StringFormatFlags.NoWrap});
            e.Graphics.DrawString(secondLine,
                new Font(FontFamily.GenericSansSerif, 8F, FontStyle.Regular), brush, e.Bounds.Left + 10,
                e.Bounds.Top + 20, new StringFormat {FormatFlags = StringFormatFlags.NoWrap});
        }

        public static Color GetLineStatusColor(string outstanding, string toReceive)
        {
            try
            {
                var culture = Utils.GetLocalCulture();
                decimal receivedQuantity = decimal.Parse(toReceive, culture);
                decimal outstandingQuantity = decimal.Parse(outstanding, culture);

                if (receivedQuantity == 0)
                {
                    return Color.Salmon;
                }
                if (outstandingQuantity > receivedQuantity)
                {
                    return Color.Yellow;
                }
                if (outstandingQuantity == receivedQuantity)
                {
                    return Color.SpringGreen;
                }
                return Color.Aqua;
            }
            catch (Exception)
            {
                return Color.White;
            }
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                _ws.SetDocumentStatus(Utils.DocumentTypeIsporuka, _shipmentNo, 1);

                listBox1.Dispose();
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
}