using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using KIPS_WMS.Data;
using KIPS_WMS.Model;
using KIPS_WMS.NAV_WS;
using KIPS_WMS.Properties;
using KIPS_WMS.Web;
using OpenNETCF.Windows.Forms;

namespace KIPS_WMS.UI.Prijem
{
    public partial class PrijemDetalji : Form
    {
        private readonly string _receiptNo;
        private readonly WarehouseReceiptLineModel _selectedLine;
        private readonly KIPS_wms _ws = WebServiceFactory.GetWebService();

        private Object[] _dbItem;

        public PrijemDetalji(string receiptNo, WarehouseReceiptLineModel selectedLine)
        {
            InitializeComponent();

            listBox1.DrawMode = DrawMode.OwnerDrawFixed;

            _receiptNo = receiptNo;
            _selectedLine = selectedLine;

            listBox1.Items.Clear();
            var listItem = new ListItem();
            for (int i = 0; i < 7; i++)
            {
                listBox1.Items.Add(listItem);
            }
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);

            Text = _receiptNo;
        }

        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            int index = e.Index;

            e.DrawBackground(index%2 == 0 ? SystemColors.Control : Color.White);

            string text = String.Empty;
            switch (index)
            {
                case 0:
                    text = string.Format("{0} {1}", "Šifra:", _selectedLine.ItemNo);
                    break;
                case 1:
                    text = string.Format("{0} {1}", "Naziv:", _selectedLine.ItemDescription);
                    break;
                case 2:
                    text = string.Format("{0} {1} {2}", "Regal:", _selectedLine.BinCode, String.Empty);
                    break;
                case 3:
                    text = string.Format("{0} {1}", "Jedinica mere za prijem:", _selectedLine.UnitOfMeasureCode);
                    break;
                case 4:
                    text = string.Format("{0} {1}", "Količina za prijem:", _selectedLine.QuantityOutstanding);
                    break;
                case 5:
                    text = string.Format("{0} {1}", "Zaprimljena količina:", _selectedLine.QuantityToReceive);
                    break;
                case 6:
                    e.DrawBackground(PrijemLinije.GetLineStatusColor(_selectedLine.QuantityOutstanding,
                        _selectedLine.QuantityToReceive));
                    text = string.Format("{0} {1}", "Preostalo za prijem:", GetRemainingQuantity());
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
            if (e.KeyCode != Keys.Enter || tbBarkod.Text.Length < 3)
            {
                _dbItem = null;
                return;
            }

            List<object[]> query = SQLiteHelper.multiRowQuery(DbStatements.FindItemsStatementBarcode,
                new object[] {tbBarkod.Text});
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
                if (_dbItem != null)
                {
                    int itemQuantity = int.Parse(_dbItem[DatabaseModel.ItemDbModel.ItemQuantity].ToString());
                    int unitQuantity = int.Parse(tbJedinicaKolicina.Text);

                    tbKolicina.Text = (itemQuantity * unitQuantity).ToString(CultureInfo.InvariantCulture);
                }
            }
            catch (Exception)
            {
                tbKolicina.Text = "0";
            }
        }

        private bool IsLineInPrimaryUnitOfMeasure()
        {



            return false;
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
            string quantity = tbKolicina.Text;
            if (quantity.Trim().Length == 0) return;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                _ws.UpdateWarehouseReceiptLineQty("1", _receiptNo, Convert.ToInt16(_selectedLine.LineNo), quantity, isUpdate, "", "", "", "");

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