using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using FileHelpers;
using KIPS_WMS.Data;
using KIPS_WMS.Model;
using KIPS_WMS.NAV_WS;
using KIPS_WMS.Properties;
using KIPS_WMS.UI.Ostalo;
using KIPS_WMS.Web;
using OpenNETCF.Windows.Forms;
using KIPS_WMS.UI.Preklasifikacija;

namespace KIPS_WMS.UI.Prijem
{
    public partial class PrijemDetalji : Form
    {
        private readonly string _receiptNo;
        private WarehouseReceiptLineModel _selectedLine;
        private readonly MobileWMSSync _ws = WebServiceFactory.GetWebService();
        private Object[] _dbItem;
        private bool _lineSplit;
        private LoginModel loginData = RegistryUtils.GetLoginData();

        public List<WarehouseReceiptLineModel> WarehouseReceiptLines;

        public PrijemDetalji(string receiptNo, string barcode, WarehouseReceiptLineModel selectedLine, List<WarehouseReceiptLineModel> warehouseReceiptLines)
        {
            InitializeComponent();

            listBox1.DrawMode = DrawMode.OwnerDrawFixed;

            _receiptNo = receiptNo;
            _selectedLine = selectedLine;
            WarehouseReceiptLines = warehouseReceiptLines;

            if (loginData.SkeniranjeBarkodaNaPrijemu == 0) {
                tbRegal.Visible = false;
                label1.Visible = false;
            }

//            _selectedLine.UnitOfMeasureCode = "PAK";

            DisplayData(barcode);
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);

            Text = _receiptNo;
        }

        private void DisplayData(string barcode)
        {
            listBox1.Items.Clear();
            var listItem = new ListItem();
            for (int i = 0; i < 7; i++)
            {
                listBox1.Items.Add(listItem);
            }

            tbRegal.Text = String.Empty;
            tbJedinicaKolicina.Text = String.Empty;
            tbKolicina.Text = "1";

            if (barcode != null)
            {
                tbBarkod.Text = barcode;
                ProcessBarcode(barcode);
            }
            else
            {
                tbBarkod.Text = String.Empty;
            }

            tbKolicina.Focus();
            if (tbKolicina.Text.Length > 0)
            {
                tbKolicina.SelectionStart = 0;
                tbKolicina.SelectionLength = tbKolicina.Text.Length;
            }
        }

        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            int index = e.Index;

            e.DrawBackground(index%2 == 0 ? SystemColors.Control : Color.White);

            string text = String.Empty;
            switch (index)
            {
                case 0:
                    text = string.Format("{0}: {1}", "Šifra", _selectedLine.ItemNo);
                    break;
                case 1:
                    text = string.Format("{0}: {1}", "Naziv", _selectedLine.ItemDescription);
                    break;
                case 2:
                    text = string.Format("{0}: {1}", "Regal", _selectedLine.BinCode);
                    break;
                case 3:
                    text = string.Format("{0}: {1}", "Jedinica mere za prijem", _selectedLine.UnitOfMeasureCode);
                    break;
                case 4:
                    text = string.Format("{0}: {1}", "Količina za prijem", _selectedLine.QuantityOutstanding);
                    break;
                case 5:
                    text = string.Format("{0}: {1}", "Zaprimljena količina", _selectedLine.QuantityToReceive);
                    break;
                case 6:
                    e.DrawBackground(PrijemLinije.GetLineStatusColor(_selectedLine.QuantityOutstanding, _selectedLine.QuantityToReceive));
                    text = string.Format("{0}: {1}", "Preostalo za prijem", GetRemainingQuantity());
                    break;
            }

            var brush = new SolidBrush(Color.Black);

            e.Graphics.DrawString(text,
                new Font(FontFamily.GenericSansSerif, 9F, FontStyle.Regular), brush, e.Bounds.Left + 3, e.Bounds.Top,
                new StringFormat {FormatFlags = StringFormatFlags.NoWrap});
        }

        private string GetRemainingQuantity()
        {
            CultureInfo culture = Utils.GetLocalCulture();
            try
            {
                decimal toReceiveQuantity = decimal.Parse(_selectedLine.QuantityToReceive, culture);
                decimal outstandingQuantity = decimal.Parse(_selectedLine.QuantityOutstanding, culture);
                return (outstandingQuantity - toReceiveQuantity).ToString("N0", culture.NumberFormat);
            }
            catch (Exception)
            {
                return Decimal.Zero.ToString(culture.NumberFormat);
            }
        }

        private void tbBarkod_KeyUp(object sender, KeyEventArgs e)
        {
            string barcode = tbBarkod.Text.Trim();
            if (e.KeyCode != Keys.Enter || barcode.Length < 3)
            {
                _dbItem = null;
                return;
            }

            ProcessBarcode(barcode);
        }

        private void ProcessBarcode(string barcode)
        {
            tbJedinicaKolicina.Text = String.Empty;
            List<object[]> query = SQLiteHelper.multiRowQuery(DbStatements.FindItemsStatementBarcode, new object[] {barcode});
            if (query.Count == 1)
            {
                _dbItem = query[0];
                lJedinica.Text = _dbItem[DatabaseModel.ItemDbModel.ItemUnitOfMeasure].ToString();
                tbJedinicaKolicina.Text = "1";
            }
            else
            {
                MessageBox.Show(Resources.NijePronadjenArtikal, Resources.Greska);
            }
        }

        private void tbJedinicaKolicina_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (_dbItem == null) return;

                int coefficient = IsLineInPrimaryUnitOfMeasure(_selectedLine.ItemNo, _dbItem[DatabaseModel.ItemDbModel.ItemUnitOfMeasure].ToString());

                int scannedItemQuantity = int.Parse(_dbItem[DatabaseModel.ItemDbModel.ItemQuantity].ToString());
                int unitQuantity = int.Parse(tbJedinicaKolicina.Text);

                tbKolicina.Text = coefficient > 1
                    ? ((scannedItemQuantity*unitQuantity)/coefficient).ToString(CultureInfo.InvariantCulture)
                    : (scannedItemQuantity*unitQuantity).ToString(CultureInfo.InvariantCulture);
            }
            catch (Exception)
            {
                tbKolicina.Text = "0";
            }
        }

        private int IsLineInPrimaryUnitOfMeasure(string itemNo, string scannedItemUnitOfMeasure)
        {
            try
            {
                object query = SQLiteHelper.simpleQuery(DbStatements.FindItemBaseUnitOfMeasure, new object[] {itemNo});
                if (query != null && !string.Equals(scannedItemUnitOfMeasure, query.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    object query2 = SQLiteHelper.simpleQuery(DbStatements.FindItemUnitOfMeasureQuantity, new object[] {itemNo, _selectedLine.UnitOfMeasureCode});
                    return int.Parse(query2.ToString());
                }
            }
            catch (Exception)
            {
                return 1;
            }
            return 1;
        }

        private void bDodaj_Click(object sender, EventArgs e)
        {
            UpdateLine(1);
        }

        private void bZameni_Click(object sender, EventArgs e)
        {
            UpdateLine(0);
        }

        private void UpdateLine(int isUpdate)
        {
            
            if (loginData.SkeniranjeBarkodaNaPrijemu == 1) {
                if (tbRegal.Text.Trim().Length == 0 || tbRegal.Text.Trim()!=_selectedLine.BinCode) {
                    MessageBox.Show("Potrebno je skenirati šifru regala.");
                    return;
                }
            }
            string quantity = tbKolicina.Text;
            if (quantity.Trim().Length == 0) return;

            string lines = "";
            string normativeLines = "";
            try
            {
                Convert.ToInt16(quantity);

                if (Convert.ToInt16(_selectedLine.TrackingType) != 0)
                {
                    var pracenje = new Pracenje(_selectedLine.ItemNo, Convert.ToInt16(quantity), Convert.ToInt16(_selectedLine.TrackingType));
                    DialogResult result = pracenje.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        var engine = new FileHelperEngine(typeof(SendTrackingModel));
                        lines = engine.WriteString(pracenje._lines);
                    }
                }

                if (Convert.ToInt16(_selectedLine.NormUomType) != 0)
                {
                    var varijabilniNormativ = new VarijabilniNormativDijalog(_selectedLine, Convert.ToDecimal(quantity));
                    DialogResult result = varijabilniNormativ.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        var engine = new FileHelperEngine(typeof(SendNormativeModel));
                        normativeLines = engine.WriteString(varijabilniNormativ._normativeLines);
                    }
                    
                }
                Cursor.Current = Cursors.WaitCursor;
                _ws.UpdateWarehouseReceiptLineQty(RegistryUtils.GetLastUsername(), _receiptNo, Convert.ToInt16(_selectedLine.LineNo), quantity,
                    isUpdate, lines, normativeLines, lJedinica.Text, quantity);

                int index = WarehouseReceiptLines.IndexOf(_selectedLine);
                if (isUpdate == 1)
                {
                    CultureInfo culture = Utils.GetLocalCulture();
                    decimal newQty = decimal.Parse(_selectedLine.QuantityToReceive, culture) + decimal.Parse(tbKolicina.Text);
                    _selectedLine.QuantityToReceive = newQty.ToString("N0", culture);
                }
                else
                {
                    _selectedLine.QuantityToReceive = tbKolicina.Text;
                }
                WarehouseReceiptLines[index] = _selectedLine;

                DisplayData(null);
            }
            catch (FormatException)
            {
                MessageBox.Show("Proverite format unetih podataka", Resources.Greska);
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

        private void bArtikalPoRegalima_Click(object sender, EventArgs e)
        {
            new ArtikliPoRegalimaDijalog(_selectedLine.BinCode, _selectedLine.ItemNo, _selectedLine.ItemVariant)
                .ShowDialog();
        }

        private void bPodeliRed_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                int newLineNo = 0;
                _ws.SplitDocumentLine(RegistryUtils.GetLastUsername(), Utils.DocumentTypePrijem, _receiptNo, Convert.ToInt16(_selectedLine.LineNo), ref newLineNo);

                _lineSplit = true;

//                new Thread(() => GetData(newLineNo)).Start();
                GetData(newLineNo);
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

        private void GetData(int lineNo)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                string warehouseReceiptsCsv = String.Empty;

                var loginData = RegistryUtils.GetLoginData();
                _ws.GetWarehouseReceiptLines(RegistryUtils.GetLastUsername(), loginData.Magacin, loginData.Podmagacin, _receiptNo, ref warehouseReceiptsCsv);

                var engine = new FileHelperEngine(typeof(WarehouseReceiptLineModel));
                WarehouseReceiptLines = ((WarehouseReceiptLineModel[])engine.ReadString(warehouseReceiptsCsv)).ToList();

                _selectedLine = WarehouseReceiptLines.Find(x => x.LineNo == Convert.ToString(lineNo));

//                Invoke(new EventHandler((e, args) => DisplayData(null)));
                DisplayData(null);
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

        private void bZameniRegal_Click(object sender, EventArgs e)
        {
            string newBinCode = tbRegal.Text.Trim();
            if (newBinCode.Length == 0 || newBinCode == _selectedLine.BinCode) return;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                _ws.ChangeBinOnDocumentLine(RegistryUtils.GetLastUsername(), Utils.DocumentTypePrijem, _receiptNo, Convert.ToInt16(_selectedLine.LineNo), newBinCode);

                tbRegal.Text = newBinCode;
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

        private void bOsteceno_Click(object sender, EventArgs e)
        {
            new OstecenoNekompletnoDijalog(_selectedLine).ShowDialog();
        }

        private void bNazad_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            listBox1.Dispose();
            Close();
        }
    }
}