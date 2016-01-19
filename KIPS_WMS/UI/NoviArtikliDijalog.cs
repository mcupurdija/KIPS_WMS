using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KIPS_WMS.Model;
using KIPS_WMS.Data;
using KIPS_WMS.NAV_WS;
using KIPS_WMS.Web;
using FileHelpers;

namespace KIPS_WMS.UI
{
    public partial class NoviArtikliDijalog : NonFullscreenForm
    {
        public ItemModel[] Items;
        private readonly KIPS_wms _ws = WebServiceFactory.GetWebService();

        public NoviArtikliDijalog()
        {
            InitializeComponent();

            var myAutoScaleFactor = new SizeF(
                AutoScaleDimensions.Width / 96F,
                AutoScaleDimensions.Height / 96F);

            Height = (int)(myAutoScaleFactor.Height * 95 - SystemInformation.MenuHeight);
            getData();
        }

        private void NoviArtikliDijalog_Activated(object sender, EventArgs e)
        {

        }
        public void getData()
        {
            Cursor.Current = Cursors.WaitCursor;
            List<Object> date = SQLiteHelper.oneRowQuery(DbStatements.GetSyncDateItems, new object[] { });
            DateTime dt = Convert.ToDateTime(date[0]);

            string csvItems = string.Empty;
            _ws.GetItems(ref csvItems, String.Empty, new DateTime(2015, 11, 1));
            ItemModel[] items;
            var engine = new FileHelperEngine(typeof(ItemModel));
            items = (ItemModel[])engine.ReadString(csvItems);
            Items = items;

            foreach (ItemModel item in items)
            {
                List<Object> foundItem = SQLiteHelper.oneRowQuery(DbStatements.FindItemsStatementComplete, new object[] { item.ItemBarcode });

                if (foundItem.Count > 0)
                {
                    SQLiteHelper.nonQuery(DbStatements.UpdateItemsStatement,
                        new object[] { item.ItemBarcode, item.ItemNo, item.ItemDescription, item.ItemVariant, item.ItemUnitOfMeasure });
                }
                else
                {
                    SQLiteHelper.insertQuery(DbStatements.InsertItemsStatement,
                        new object[] { item.ItemBarcode, item.ItemNo, item.ItemDescription, item.ItemVariant, item.ItemUnitOfMeasure });
                }

            }
            Cursor.Current = Cursors.Default;
            DialogResult = DialogResult.OK;
            Cursor.Current = Cursors.Default;
            Close();

        }
    }
}