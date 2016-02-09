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
using KIPS_WMS.UI.Prijem;

namespace KIPS_WMS.UI.Isporuka
{
    public partial class IsporukaDetalji : Form
    {
        private readonly string _shipmentNo;
        private WarehouseShipmentLineModel _selectedLine;
        private readonly MobileWMSSync _ws = WebServiceFactory.GetWebService();
        private Object[] _dbItem;
        private bool _lineSplit;
        private readonly LoginModel _loginData = RegistryUtils.GetLoginData();
        decimal coefficient = 0;

        public List<WarehouseShipmentLineModel> WarehouseShipmentLines;

        public IsporukaDetalji(string shipmentNo, string barcode, WarehouseShipmentLineModel selectedLine, List<WarehouseShipmentLineModel> warehouseShipmentLines)
        {
            InitializeComponent();

            listBox1.DrawMode = DrawMode.OwnerDrawFixed;

            _shipmentNo = shipmentNo;
            _selectedLine = selectedLine;
            WarehouseShipmentLines = warehouseShipmentLines;

            if (_loginData.SkeniranjeBarkodaNaPrijemu == 0)
            {
                tbRegal.Visible = false;
                label1.Visible = false;
            }

            //            _selectedLine.UnitOfMeasureCode = "PAK";

            DisplayData(barcode);
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);

            Text = _shipmentNo;
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
                lJedinica.Text = "";
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

            e.DrawBackground(index % 2 == 0 ? SystemColors.Control : Color.White);

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
                new StringFormat { FormatFlags = StringFormatFlags.NoWrap });
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
            List<object[]> query = SQLiteHelper.multiRowQuery(DbStatements.FindItemsStatementBarcode, new object[] { barcode });
            
            if (query.Count == 1)
            {
                _dbItem = query[0];
                lJedinica.Text = _dbItem[DatabaseModel.ItemDbModel.ItemUnitOfMeasure].ToString();
                
                coefficient = GetCoefficient(_selectedLine.ItemNo, _dbItem[DatabaseModel.ItemDbModel.ItemUnitOfMeasure].ToString());
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

               
                decimal scannedItemQuantity = int.Parse(_dbItem[DatabaseModel.ItemDbModel.ItemQuantity].ToString());
                decimal unitQuantity = decimal.Parse(tbJedinicaKolicina.Text, Utils.GetLocalCulture());

                tbKolicina.Text = (scannedItemQuantity / coefficient) != 1
                    ? ((scannedItemQuantity / coefficient) * unitQuantity).ToString("N3", Utils.GetLocalCulture())
                    : (unitQuantity).ToString("N3", Utils.GetLocalCulture());
            }
            catch (Exception)
            {
                tbKolicina.Text = "0";
            }
        }

        private decimal GetCoefficient(string itemNo, string scannedItemUnitOfMeasure)
        {
            try
            {
                //object query = SQLiteHelper.simpleQuery(DbStatements.FindItemBaseUnitOfMeasure, new object[] {itemNo});
                //if (query != null && !string.Equals(scannedItemUnitOfMeasure, query.ToString(), StringComparison.OrdinalIgnoreCase))
                //{
                //    object query2 = SQLiteHelper.simpleQuery(DbStatements.FindItemUnitOfMeasureQuantity, new object[] {itemNo, _selectedLine.UnitOfMeasureCode});
                //    return int.Parse(query2.ToString());
                //}
                object query = SQLiteHelper.simpleQuery(DbStatements.FindItemUnitOfMeasureQuantity, new object[] { itemNo, _selectedLine.UnitOfMeasureCode });
                if (query != null)
                {
                    return decimal.Parse(query.ToString());
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
            if (_loginData.SkeniranjeBarkodaNaIsporuci == 1 && (tbRegal.Text.Trim() != _selectedLine.BinCode))
            {
                MessageBox.Show("Potrebno je skenirati šifru regala.");
                return;
            }

            string quantity = tbKolicina.Text;
            string uomQuantity = tbJedinicaKolicina.Text;
            if (uomQuantity.Trim().Length == 0) {
                uomQuantity = "0";
            }
            if (quantity.Trim().Length == 0) return;

            string lines = "";
            string normativeLines = "";
            try
            {
                if (decimal.Parse(quantity) < 0) return;
                if (decimal.Parse(uomQuantity) < 0) return;

                if (Convert.ToInt16(_selectedLine.TrackingType) != 0)
                {
                    var pracenje = new Pracenje(_selectedLine.ItemNo, decimal.Parse(quantity), Convert.ToInt16(_selectedLine.TrackingType));
                    DialogResult result = pracenje.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        var engine = new FileHelperEngine(typeof(SendTrackingModel));
                        lines = engine.WriteString(pracenje.Lines);
                    }
                }

                if (Convert.ToInt16(_selectedLine.NormUomType) != 0)
                {
                    var varijabilniNormativ = new IsporukaVarijabilniNormativDijalog(_selectedLine, decimal.Parse(quantity));
                    DialogResult result = varijabilniNormativ.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        var engine = new FileHelperEngine(typeof(SendNormativeModel));
                        normativeLines = engine.WriteString(varijabilniNormativ._normativeLines);
                    }

                }
                Cursor.Current = Cursors.WaitCursor;
                _ws.UpdateWarehouseShipmentLineQty(RegistryUtils.GetLastUsername(), _shipmentNo, Convert.ToInt16(_selectedLine.LineNo), 
                    quantity, isUpdate, lines, normativeLines, lJedinica.Text, uomQuantity);

                int index = WarehouseShipmentLines.IndexOf(_selectedLine);
                if (isUpdate == 1)
                {
                    CultureInfo culture = Utils.GetLocalCulture();
                    decimal newQty = decimal.Parse(_selectedLine.QuantityToReceive, culture) + decimal.Parse(tbKolicina.Text, culture);
                    _selectedLine.QuantityToReceive = newQty.ToString("N0", culture);
                }
                else
                {
                    _selectedLine.QuantityToReceive = tbKolicina.Text;
                }
                WarehouseShipmentLines[index] = _selectedLine;

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
                _ws.SplitDocumentLine(RegistryUtils.GetLastUsername(), Utils.DocumentTypeIsporuka, _shipmentNo, Convert.ToInt16(_selectedLine.LineNo), ref newLineNo);

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

                string warehouseShipmentsCsv = String.Empty;

                var loginData = RegistryUtils.GetLoginData();
                _ws.GetWarehouseReceiptLines(RegistryUtils.GetLastUsername(), loginData.Magacin, loginData.Podmagacin, _shipmentNo, ref warehouseShipmentsCsv);

                var engine = new FileHelperEngine(typeof(WarehouseShipmentLineModel));
                WarehouseShipmentLines = ((WarehouseShipmentLineModel[])engine.ReadString(warehouseShipmentsCsv)).ToList();

                _selectedLine = WarehouseShipmentLines.Find(x => x.LineNo == Convert.ToString(lineNo));

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

                _ws.ChangeBinOnDocumentLine(RegistryUtils.GetLastUsername(), Utils.DocumentTypeIsporuka, _shipmentNo, Convert.ToInt16(_selectedLine.LineNo), newBinCode);

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

        private void bNazad_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            listBox1.Dispose();
            Close();
        }

        private void tbBarkod_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbJedinicaKolicina_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                tbJedinicaKolicina.Text += ",";
                tbJedinicaKolicina.SelectionStart = tbJedinicaKolicina.Text.Length;
                tbJedinicaKolicina.SelectionLength = 0;
                e.Handled = true;
            }
        }

        private void tbKolicina_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                tbKolicina.Text += ",";
                tbKolicina.SelectionStart = tbKolicina.Text.Length;
                tbKolicina.SelectionLength = 0;
                e.Handled = true;
            }
        }
    }
}