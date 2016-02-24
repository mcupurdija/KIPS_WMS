using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
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
    public partial class SkladistenjePretragaPoArtiklu : Form
    {
        private readonly MobileWMSSync _ws = WebServiceFactory.GetWebService();

        private List<Object[]> _searchedItems;
        private Object[] _selectedItem;
        private WarehousePutAwayModel _selectedPutAway;
        private bool _tableItems = true;
        private List<WarehousePutAwayModel> _warehousePutAways;

        public SkladistenjePretragaPoArtiklu()
        {
            InitializeComponent();

            listBox1.DrawMode = DrawMode.OwnerDrawFixed;

            tbPronadji.Focus();
        }

        private void bPronadji_Click(object sender, EventArgs e)
        {
            string searchQuery = tbPronadji.Text;
            if (searchQuery.Trim().Length == 0) return;

            SearchItems(searchQuery);
        }

        private void SearchItems(string searchQuery)
        {
            _searchedItems = SQLiteHelper.multiRowQuery(DbStatements.FindItemsStatementComplete,
                new object[] {searchQuery});

            DisplaySearchResults(_searchedItems);
        }

        private void DisplaySearchResults(IEnumerable<object[]> data)
        {
            _tableItems = true;
            _selectedItem = null;

            listBox1.Items.Clear();

            var listItem = new ListItem();
            foreach (var item in data)
            {
                listBox1.Items.Add(listItem);
            }
            if (listBox1.Items.Count > 5)
            {
                listBox1.Items.Add(new ListItem {Tag = 0});
            }

            tbPronadji.Focus();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            if (index == -1 || index >= listBox1.Items.Count || listBox1.Items[index].Tag != null)
            {
                if (_tableItems)
                {
                    _selectedItem = null;
                }
                else
                {
                    _selectedPutAway = null;
                }
                return;
            }

            if (_tableItems)
            {
                _selectedItem = _searchedItems[index];
            }
            else
            {
                _selectedPutAway = _warehousePutAways[index];
            }
        }

        private void bNazad_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bDalje_Click(object sender, EventArgs e)
        {
            if (_tableItems)
            {
                if (_selectedItem != null)
                {
                    new Thread(() => GetData(_selectedItem[DatabaseModel.ItemDbModel.ItemCode].ToString())).Start();
                }
                else
                {
                    MessageBox.Show(Resources.OdaberiteArtikal, Resources.Greska);
                }
            }
            else
            {
                if (_selectedPutAway != null)
                {
                    new SkladistenjeLinije(_selectedPutAway.PutAwayCode).Show();
                }
                else
                {
                    MessageBox.Show(Resources.OdaberiteDokument, Resources.Greska);
                }
            }
        }

        private void GetData(string itemNo)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                string warehousePutAwaysCsv = String.Empty;

                var loginData = RegistryUtils.GetLoginData();
                _ws.GetWarehousePutAways(RegistryUtils.GetLastUsername(), loginData.Magacin, loginData.Podmagacin, itemNo, ref warehousePutAwaysCsv);

                var engine = new FileHelperEngine(typeof (WarehousePutAwayModel));
                _warehousePutAways = ((WarehousePutAwayModel[]) engine.ReadString(warehousePutAwaysCsv)).ToList();
                _warehousePutAways.Sort(
                    (x, y) => String.Compare(x.SourceDescription, y.SourceDescription, StringComparison.Ordinal));

                Invoke(new EventHandler((sender, e) => DisplayData()));
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

        private void DisplayData()
        {
            _tableItems = false;
            _selectedPutAway = null;

            listBox1.Items.Clear();
            listBox1.SelectedIndex = -1;

            var listItem = new ListItem();
            for (int i = 0; i < _warehousePutAways.Count; i++)
            {
                listBox1.Items.Add(listItem);
            }
            if (listBox1.Items.Count > 5)
            {
                listBox1.Items.Add(new ListItem {Tag = 0});
            }

            tbPronadji.Focus();
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

            if (_tableItems)
            {
                object[] line = _searchedItems[index];

                string firstLine = line[DatabaseModel.ItemDbModel.ItemCode].ToString();
                string secondLine = line[DatabaseModel.ItemDbModel.ItemDescription].ToString();

                e.Graphics.DrawString(firstLine,
                    new Font(FontFamily.GenericSansSerif, 8F, FontStyle.Bold), brush, e.Bounds.Left + 3, e.Bounds.Top,
                    new StringFormat {FormatFlags = StringFormatFlags.NoWrap});
                e.Graphics.DrawString(secondLine,
                    new Font(FontFamily.GenericSansSerif, 8F, FontStyle.Regular), brush, e.Bounds.Left + 3,
                    e.Bounds.Top + 20, new StringFormat {FormatFlags = StringFormatFlags.NoWrap});
            }
            else
            {
                WarehousePutAwayModel line = _warehousePutAways[index];

                string firstLine = line.SourceDescription;
                string secondLine = string.Format("{0} - {1}", line.PutAwayCode, line.PostingDate);

                e.Graphics.DrawString(firstLine,
                    new Font(FontFamily.GenericSansSerif, 8F, FontStyle.Bold), brush, e.Bounds.Left + 3, e.Bounds.Top,
                    new StringFormat {FormatFlags = StringFormatFlags.NoWrap});
                e.Graphics.DrawString(secondLine,
                    new Font(FontFamily.GenericSansSerif, 8F, FontStyle.Regular), brush, e.Bounds.Left + 3,
                    e.Bounds.Top + 20, new StringFormat {FormatFlags = StringFormatFlags.NoWrap});
            }
        }

        private void tbPronadji_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;

                    var items = SQLiteHelper.multiRowQuery(DbStatements.FindItemsStatementBarcode,
                        new object[] { tbPronadji.Text });
                    if (items.Count == 0)
                    {
                        items = SQLiteHelper.multiRowQuery(DbStatements.FindItemsStatementCode,
                        new object[] { tbPronadji.Text });
                    }
                    if (items.Count == 0)
                    {
                        MessageBox.Show("Nije pronađen artikal.", Resources.Greska);
                    }
                    else
                    {
                        _selectedItem = items[0];
                        if (_selectedItem != null)
                        {
                            new Thread(() => GetData(_selectedItem[DatabaseModel.ItemDbModel.ItemCode].ToString())).Start();
                        }
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
                    if (_tableItems)
                    {
                        if (_selectedItem != null)
                        {
                            new Thread(() => GetData(_selectedItem[DatabaseModel.ItemDbModel.ItemCode].ToString())).Start();
                        }
                        else
                        {
                            MessageBox.Show(Resources.OdaberiteArtikal, Resources.Greska);
                        }
                    }
                    else
                    {
                        if (_selectedPutAway != null)
                        {
                            new SkladistenjeLinije(_selectedPutAway.PutAwayCode).Show();
                        }
                        else
                        {
                            MessageBox.Show(Resources.OdaberiteDokument, Resources.Greska);
                        }
                    }
                    break;
            }
        }

        private void SkladistenjePretragaPoArtiklu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                listBox1.Dispose();
                Close();
            }
        }
    }
}