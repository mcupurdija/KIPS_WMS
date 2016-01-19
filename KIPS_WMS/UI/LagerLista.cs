using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KIPS_WMS.Data;
using KIPS_WMS.NAV_WS;
using KIPS_WMS.Web;
using KIPS_WMS.Model;
using FileHelpers;

namespace KIPS_WMS.UI
{
    public partial class LagerLista : Form
    {
        private readonly KIPS_wms _ws = WebServiceFactory.GetWebService();
        private string _itemNo;

        public LagerLista()
        {
            InitializeComponent();
        }

        public LagerLista(string itemNo)
        {
            InitializeComponent();

            _itemNo = itemNo;
            if (_itemNo != null)
            {
                tbSifra.Text = _itemNo;
                GetData();
            }
        }

        private void GetData()
        {
            var code = SQLiteHelper.oneRowQuery(DbStatements.FindItemsStatementCode, new object[] { _itemNo });
            
            string csvLagerList = string.Empty;
            _ws.GetItemLagerList(code[1].ToString(), string.Empty, string.Empty, string.Empty,ref csvLagerList);
            ItemLagerListModel[] lagerList;
            var engine = new FileHelperEngine(typeof(ItemLagerListModel));
            lagerList = (ItemLagerListModel[])engine.ReadString(csvLagerList);

            lvLagerLista.Clear();
            lvLagerLista.View = View.Details;
            lvLagerLista.Columns.Add("Šifra", 60, HorizontalAlignment.Center);
            lvLagerLista.Columns.Add("Naziv", 195, HorizontalAlignment.Center);
            lvLagerLista.Columns.Add("JM", 60, HorizontalAlignment.Center);
            lvLagerLista.Columns.Add("Ukupno", 80, HorizontalAlignment.Center);
            lvLagerLista.Columns.Add("Raspoloživo", 80, HorizontalAlignment.Center);

            foreach (ItemLagerListModel item in lagerList)
            {
                ListViewItem lvi;

                lvi =
                    new ListViewItem(new[]
                        {
                            item.WarehouseCode, item.WarehouseName, item.UnitOfMeasure, item.TotalQuantity.ToString(), item.AvailableQuantity.ToString()
                        });

                lvLagerLista.Items.Add(lvi);
            }
        }

        private void bPronadji_Click(object sender, EventArgs e)
        {
           
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