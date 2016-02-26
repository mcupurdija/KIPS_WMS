using System;
using System.Threading;
using System.Windows.Forms;
using FileHelpers;
using KIPS_WMS.Model;
using KIPS_WMS.NAV_WS;
using KIPS_WMS.Web;
using KIPS_WMS.Properties;
using KIPS_WMS.Data;

namespace KIPS_WMS.UI
{
    public partial class LagerLista : Form
    {
        private readonly MobileWMSSync _ws = WebServiceFactory.GetWebService();
        private ItemLagerListModel[] _items;

        public LagerLista()
        {
            InitializeComponent();
        }

        public LagerLista(string itemNo)
        {
            InitializeComponent();

            if (itemNo != null)
            {
                tbSifra.Text = itemNo;

                new Thread(() => GetData(itemNo)).Start();
            }
        }

        private void GetData(string itemNo)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                string csvLagerList = string.Empty;

                _ws.GetItemLagerList(itemNo, string.Empty, string.Empty, "", ref csvLagerList);

                var engine = new FileHelperEngine(typeof(ItemLagerListModel));
                _items = (ItemLagerListModel[])engine.ReadString(csvLagerList);

                Invoke(new EventHandler((sender, e) => DisplayLines()));
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

        private void DisplayLines()
        {
            lvLagerLista.Clear();
            lvLagerLista.View = View.Details;
            lvLagerLista.Columns.Add("Naziv", 195, HorizontalAlignment.Left);
            lvLagerLista.Columns.Add("Raspoloživo", 80, HorizontalAlignment.Left);
            lvLagerLista.Columns.Add("Ukupno", 80, HorizontalAlignment.Left); 
            lvLagerLista.Columns.Add("JM", 60, HorizontalAlignment.Left);
            lvLagerLista.Columns.Add("Šifra", 60, HorizontalAlignment.Left);           
                                    
            foreach (ItemLagerListModel item in _items)
            {
                var lvi = new ListViewItem(new[]
                {
                    item.WarehouseName, item.AvailableQuantity, item.TotalQuantity, item.UnitOfMeasure, item.WarehouseCode
                });
                lvLagerLista.Items.Add(lvi);
            }
        }

        private void bPronadji_Click(object sender, EventArgs e)
        {
            GetData(tbSifra.Text);
        }

        private void tbSifra_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var code = SQLiteHelper.oneRowQuery(DbStatements.FindItemsStatementBarcode, new object[] { tbSifra.Text });
                if (code.Count != 0)
                {
                    string csvLagerList = string.Empty;
                    _ws.GetItemLagerList(code[2].ToString(), string.Empty, string.Empty, string.Empty, ref csvLagerList);
                    ItemLagerListModel[] lagerList;
                    var engine = new FileHelperEngine(typeof(ItemLagerListModel));
                    lagerList = (ItemLagerListModel[])engine.ReadString(csvLagerList);

                    lvLagerLista.Clear();
                    lvLagerLista.View = View.Details;
                    lvLagerLista.Columns.Add("Naziv", 195, HorizontalAlignment.Left);
                    lvLagerLista.Columns.Add("Raspoloživo", 80, HorizontalAlignment.Left);
                    lvLagerLista.Columns.Add("Ukupno", 80, HorizontalAlignment.Left);
                    lvLagerLista.Columns.Add("JM", 60, HorizontalAlignment.Left);
                    lvLagerLista.Columns.Add("Šifra", 60, HorizontalAlignment.Left);  

                    foreach (ItemLagerListModel item in lagerList)
                    {
                        ListViewItem lvi;

                        lvi =
                            new ListViewItem(new[]
                        {
                            item.WarehouseName, item.AvailableQuantity, item.TotalQuantity, item.UnitOfMeasure, item.WarehouseCode
                        });

                        lvLagerLista.Items.Add(lvi);
                    }
                }
                else {
                    GetData(tbSifra.Text);
                }
            }
        }

        private void toolBar1_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            Close();
        }

        private void LagerLista_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                Close();
            }
        }
    }
}