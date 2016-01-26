using System;
using System.Collections.Generic;
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

namespace KIPS_WMS.UI.Prijem
{
    public partial class PrijemPretragaPoArtiklu : Form
    {
        private readonly KIPS_wms _ws = WebServiceFactory.GetWebService();

        private List<Object[]> _searchedItems;
        private Object[] _selectedItem;
        private WarehouseReceiptModel _selectedReceipt;
        private bool _tableItems = true;
        private List<WarehouseReceiptModel> _warehouseReceipts;

        public PrijemPretragaPoArtiklu()
        {
            InitializeComponent();

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

            foreach (var item in data)
            {
                listBox1.Items.Add(string.Format("{0}{1}{2}", item[DatabaseModel.ItemDbModel.ItemCode],
                    Environment.NewLine,
                    item[DatabaseModel.ItemDbModel.ItemDescription]));
            }

            tbPronadji.Focus();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            if (index == -1) return;

            if (_tableItems)
            {
                _selectedItem = _searchedItems[index];
            }
            else
            {
                _selectedReceipt = _warehouseReceipts[index];
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
                if (_selectedReceipt != null)
                {
                    new PrijemLinije(_selectedReceipt.ReceiptCode).ShowDialog();
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

                string warehouseReceiptsCsv = String.Empty;

                _ws.GetWarehouseReceipts("1", "001", "002", itemNo, ref warehouseReceiptsCsv);

                var engine = new FileHelperEngine(typeof (WarehouseReceiptModel));
                _warehouseReceipts = ((WarehouseReceiptModel[]) engine.ReadString(warehouseReceiptsCsv)).ToList();

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
            _selectedReceipt = null;

            listBox1.Items.Clear();
            listBox1.SelectedIndex = -1;

            foreach (WarehouseReceiptModel item in _warehouseReceipts)
            {
                var listItem =
                    new ListItem(string.Format("{0} - {1}{2}{3} - {4}", item.ReceiptCode, item.ReceiptDate,
                        Environment.NewLine, item.SourceCode, item.SourceDescription));
                listBox1.Items.Add(listItem);
            }

            tbPronadji.Focus();
        }
    }
}