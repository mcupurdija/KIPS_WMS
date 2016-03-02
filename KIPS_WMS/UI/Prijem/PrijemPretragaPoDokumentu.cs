using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
        private readonly MobileWMSSync _ws = WebServiceFactory.GetWebService();
        private List<WarehouseReceiptModel> _filteredList;
        private WarehouseReceiptModel _selectedReceipt;
        private List<WarehouseReceiptModel> _warehouseReceipts;

        public PrijemPretragaPoDokumentu()
        {
            InitializeComponent();

            listBox1.DrawMode = DrawMode.OwnerDrawFixed;

//            new Thread(GetData).Start();
            GetData();
        }

        private void GetData()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                string warehouseReceiptsCsv = String.Empty;

                LoginModel loginData = RegistryUtils.GetLoginData();
                _ws.GetWarehouseReceipts(RegistryUtils.GetLastUsername(), loginData.Magacin, loginData.Podmagacin, "",
                    ref warehouseReceiptsCsv, Utils.AppVersion);

                var engine = new FileHelperEngine(typeof (WarehouseReceiptModel));
                _warehouseReceipts = ((WarehouseReceiptModel[]) engine.ReadString(warehouseReceiptsCsv)).ToList();
                _warehouseReceipts.Sort(
                    (x, y) => String.Compare(x.SourceDescription, y.SourceDescription, StringComparison.Ordinal));
                _filteredList = _warehouseReceipts;

//                Invoke(new EventHandler((sender, e) => DisplayData(null)));
                DisplayData(null, false);
            }
            catch (Exception ex)
            {
                Utils.GeneralExceptionProcessing(ex);
                Cursor.Current = Cursors.Default;
                listBox1.Dispose();
                Close();
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void DisplayData(string documentNo, bool isSearch)
        {
            listBox1.Items.Clear();

            _selectedReceipt = null;
            _filteredList = documentNo != null
                ? _warehouseReceipts.FindAll(x => x.ReceiptCode.Contains(documentNo.ToUpper()))
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

            if (_filteredList.Count == 1)
            {
                listBox1.Focus();
                listBox1.SelectedIndex = 0;
                _selectedReceipt = _filteredList[0];

                if (isSearch)
                {
                    ResetListAndContinue();
                }
            }
            else
            {
                tbPronadji.Focus();
            }
        }

        private void bPronadji_Click(object sender, EventArgs e)
        {
            string searchQuery = tbPronadji.Text.Trim();
            if (searchQuery.Length == 0) return;

            DisplayData(searchQuery, true);
        }

        private void bReset_Click(object sender, EventArgs e)
        {
            DisplayData(null, false);
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
            listBox1.Dispose();
            Close();
        }

        private void bDalje_Click(object sender, EventArgs e)
        {
            if (_selectedReceipt != null)
            {
                ResetListAndContinue();
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

        private void toolBar1_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            switch (toolBar1.Buttons.IndexOf(e.Button))
            {
                case 0:
                    listBox1.Dispose();
                    Close();
                    break;
                case 1:
                    if (_selectedReceipt != null)
                    {
                        ResetListAndContinue();
                    }
                    else
                    {
                        MessageBox.Show(Resources.OdaberiteDokument, Resources.Greska);
                    }
                    break;
            }
        }

        private void tbPronadji_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DisplayData(tbPronadji.Text.Trim(), true);
            }
        }

        private void PrijemPretragaPoDokumentu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Escape)
            {
                listBox1.Dispose();
                Close();
            }
        }

        private void listBox1_KeyUp(object sender, KeyEventArgs e)
        {
            int index = listBox1.SelectedIndex;
            if (e.KeyCode == Keys.Enter && index != -1 && index < listBox1.Items.Count &&
                listBox1.Items[index].Tag == null)
            {
                ResetListAndContinue();
            }
        }

        private void ResetListAndContinue()
        {
            string code = _selectedReceipt.ReceiptCode;
            DisplayData(null, false);
            listBox1.SelectedIndex = -1;

            tbPronadji.Text = String.Empty;
            tbPronadji.Focus();

            new PrijemLinije(code).Show();
        }
    }
}