using System;
using System.Threading;
using System.Windows.Forms;
using FileHelpers;
using KIPS_WMS.Model;
using KIPS_WMS.NAV_WS;
using KIPS_WMS.Web;
using KIPS_WMS.Properties;

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

                _ws.GetItemLagerList(itemNo, string.Empty, string.Empty, RegistryUtils.GetLoginData().Magacin, ref csvLagerList);

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
            lvLagerLista.Columns.Add(Resources.Sifra, 80, HorizontalAlignment.Left);
            lvLagerLista.Columns.Add(Resources.Naziv, 160, HorizontalAlignment.Left);
            lvLagerLista.Columns.Add(Resources.Jedinica, 80, HorizontalAlignment.Center);
            lvLagerLista.Columns.Add(Resources.Ukupno, 100, HorizontalAlignment.Right);
            lvLagerLista.Columns.Add(Resources.Raspolozivo, 100, HorizontalAlignment.Right);

            foreach (ItemLagerListModel item in _items)
            {
                var lvi = new ListViewItem(new[]
                {
                    item.WarehouseCode, item.WarehouseName, item.UnitOfMeasure, item.TotalQuantity,
                    item.AvailableQuantity
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
            //Ucitavanje bar-koda TO DO
            //if (e.KeyCode == Keys.Enter)
            //{
            //    var code = SQLiteHelper.oneRowQuery(DbStatements.FindItemsStatementBarcode, new object[] { tbSifra.Text });

            //    string csvLagerList = string.Empty;
            //    _ws.GetItemLagerList(code[1].ToString(), string.Empty, string.Empty, string.Empty, ref csvLagerList);
            //    ItemLagerListModel[] lagerList;
            //    var engine = new FileHelperEngine(typeof(ItemLagerListModel));
            //    lagerList = (ItemLagerListModel[])engine.ReadString(csvLagerList);

            //    lvLagerLista.Clear();
            //    lvLagerLista.View = View.Details;
            //    lvLagerLista.Columns.Add("Šifra", 60, HorizontalAlignment.Center);
            //    lvLagerLista.Columns.Add("Naziv", 195, HorizontalAlignment.Center);
            //    lvLagerLista.Columns.Add("JM", 60, HorizontalAlignment.Center);
            //    lvLagerLista.Columns.Add("Ukupno", 80, HorizontalAlignment.Center);
            //    lvLagerLista.Columns.Add("Raspoloživo", 80, HorizontalAlignment.Center);

            //    foreach (ItemLagerListModel item in lagerList)
            //    {
            //        ListViewItem lvi;

            //        lvi =
            //            new ListViewItem(new[]
            //            {
            //                item.WarehouseCode, item.WarehouseName, item.UnitOfMeasure, item.TotalQuantity.ToString(), item.AvailableQuantity.ToString()
            //            });

            //        lvLagerLista.Items.Add(lvi);
            //    }
            //}
        }
    }
}