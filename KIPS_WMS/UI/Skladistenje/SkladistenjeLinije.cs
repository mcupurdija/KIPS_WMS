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
using KIPS_WMS.Web;
using OpenNETCF.Windows.Forms;

namespace KIPS_WMS.UI.Skladistenje
{
    public partial class SkladistenjeLinije : Form
    {
        private readonly LoginModel _loginData = RegistryUtils.GetLoginData();
        private readonly string _putAwayNo;
        private readonly MobileWMSSync _ws = WebServiceFactory.GetWebService();
        private string _barcode;
        private List<WarehousePutAwayLineModel> _filteredPutAwayLines;
        private WarehousePutAwayLineModel _selectedLine;
        private List<WarehousePutAwayLineModel> _warehousePutAwayLines;

        public SkladistenjeLinije(string putAwayNo)
        {
            InitializeComponent();

            _putAwayNo = putAwayNo;
            listBox1.DrawMode = DrawMode.OwnerDrawFixed;

            GetData();
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);

            _barcode = null;
            Text = _putAwayNo;
        }

        private void GetData()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                string warehousePutAwaysCsv = String.Empty;


                _ws.GetWarehousePutAwayLines(RegistryUtils.GetLastUsername(), _loginData.Magacin, _loginData.Podmagacin,
                    _putAwayNo, ref warehousePutAwaysCsv);

                var engine = new FileHelperEngine(typeof(WarehousePutAwayLineModel));
                _warehousePutAwayLines =
                    ((WarehousePutAwayLineModel[])engine.ReadString(warehousePutAwaysCsv)).ToList();

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
            if (_warehousePutAwayLines == null)
            {
                return;
            }

            listBox1.Items.Clear();
            listBox1.ItemHeight = 40;

            _selectedLine = null;
            listBox1.SelectedIndex = -1;
            if (fromScanner)
            {
                _filteredPutAwayLines = filterText != null
                        ? _warehousePutAwayLines.FindAll(x => x.ItemNo.Equals(filterText))
                        : _warehousePutAwayLines;
            }
            else
            {
                _filteredPutAwayLines = filterText != null
                    ? _warehousePutAwayLines.FindAll(
                        x => x.ItemNo.Contains(filterText) || x.ItemDescription.Contains(filterText))
                    : _warehousePutAwayLines;                
            }
            
            var listItem = new ListItem();
            for (int i = 0; i < _filteredPutAwayLines.Count; i++)
            {
                listBox1.Items.Add(listItem);
            }
            if (listBox1.Items.Count > 5)
            {
                listBox1.Items.Add(new ListItem { Tag = 0 });
            }

            tbPronadji.Focus();
            tbPronadji.SelectionStart = 0;
            tbPronadji.SelectionLength = tbPronadji.Text.Length;

            if (fromScanner && _filteredPutAwayLines.Count == 1)
            {
                _selectedLine = _filteredPutAwayLines[0];
                ShowLineDetailsForm(_barcode);
            }
            if (_filteredPutAwayLines.Count == 0)
            {
                MessageBox.Show("Nije pronađen artikal.", Resources.Greska);
                DisplayData(null, false);
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
            else
            {
                DisplayData(tbPronadji.Text.Trim(), true);
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
            var skladistenjeDetalji = new SkladistenjeDetalji(_putAwayNo, barcode, _selectedLine, _warehousePutAwayLines);
            DialogResult result = skladistenjeDetalji.ShowDialog();

            if (result == DialogResult.Yes)
            {
                _warehousePutAwayLines = skladistenjeDetalji.WarehousePutAwayLines;
                DisplayData(null, false);
                tbPronadji.Text = "";
                tbPronadji.Focus();
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

            _selectedLine = _filteredPutAwayLines[index];
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
                e.DrawBackground(index % 2 == 0 ? SystemColors.Control : Color.White);
                brush = new SolidBrush(Color.Black);
            }

            WarehousePutAwayLineModel line = _filteredPutAwayLines[index];

            var rectangle = new Rectangle(e.Bounds.Left, e.Bounds.Top, 7, e.Bounds.Height);
            e.Graphics.FillRectangle(
                new SolidBrush(GetLineStatusColor(line.QuantityOutstanding, line.QuantityToReceive)), rectangle);
            e.Graphics.DrawRectangle(new Pen(Color.White), rectangle);

            string firstLine = string.Format("{0} {1}", line.ItemNo, line.ItemDescription);
            string secondLine = string.Format("{0} - {1} / {2}", line.SerialNo, line.QuantityToReceive,
                line.QuantityOutstanding);

            e.Graphics.DrawString(firstLine,
                new Font(FontFamily.GenericSansSerif, 8F, FontStyle.Bold), brush, e.Bounds.Left + 10, e.Bounds.Top,
                new StringFormat { FormatFlags = StringFormatFlags.NoWrap });
            e.Graphics.DrawString(secondLine,
                new Font(FontFamily.GenericSansSerif, 8F, FontStyle.Regular), brush, e.Bounds.Left + 10,
                e.Bounds.Top + 20, new StringFormat { FormatFlags = StringFormatFlags.NoWrap });
        }

        public static Color GetLineStatusColor(string outstanding, string toReceive)
        {
            try
            {
                CultureInfo culture = Utils.GetLocalCulture();
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
                int status = -1;

                _ws.RegisterWhsDocument(RegistryUtils.GetLastUsername(), _loginData.Magacin, _loginData.Podmagacin,
                    Utils.DocumentTypeSkladistenje
                    , _putAwayNo, ref status);

                if (status == 1)
                {
                    MessageBox.Show("Skladištenje je uspešno registrovano");
                    listBox1.Dispose();
                    Close();
                }
                else
                {
                    MessageBox.Show("Došlo je do greške");
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

        private void toolBar1_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            switch (toolBar1.Buttons.IndexOf(e.Button))
            {
                case 0:
                    listBox1.Dispose();
                    Close();
                    break;
                case 1:
                    try
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        int status = -1;

                        _ws.RegisterWhsDocument(RegistryUtils.GetLastUsername(), _loginData.Magacin,
                            _loginData.Podmagacin,
                            Utils.DocumentTypeSkladistenje
                            , _putAwayNo, ref status);

                        if (status == 1)
                        {
                            MessageBox.Show("Skladištenje je uspešno registrovano");
                            listBox1.Dispose();
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("Došlo je do greške");
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
                    break;
                case 2:
                    if (_selectedLine != null)
                    {
                        ShowLineDetailsForm(null);
                    }
                    else
                    {
                        MessageBox.Show(Resources.OdaberiteLiniju, Resources.Greska);
                    }
                    break;
            }
        }
    }
}