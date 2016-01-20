using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using FileHelpers;
using KIPS_WMS.Data;
using KIPS_WMS.Model;
using KIPS_WMS.NAV_WS;
using KIPS_WMS.Web;

namespace KIPS_WMS.UI
{
    public partial class NoviArtikliDijalog : NonFullscreenForm
    {
        public delegate void CloseDelagate();

        private readonly KIPS_wms _ws = WebServiceFactory.GetWebService();

        public NoviArtikliDijalog()
        {
            InitializeComponent();

            var myAutoScaleFactor = new SizeF(
                AutoScaleDimensions.Width/96F,
                AutoScaleDimensions.Height/96F);

            Height = (int) (myAutoScaleFactor.Height*50);

            var thread = new Thread(GetData);
            thread.Start();
        }

        public void GetData()
        {
            List<Object> date = SQLiteHelper.oneRowQuery(DbStatements.GetSyncDateItems, new object[] {});
            DateTime dt = Convert.ToDateTime(date[0]);

            string csvItems = string.Empty;

            _ws.GetItems(ref csvItems, String.Empty, dt);

            var engine = new FileHelperEngine(typeof (ItemModel));
            var items = (ItemModel[]) engine.ReadString(csvItems);

            foreach (ItemModel item in items)
            {
                List<Object> foundItem = SQLiteHelper.oneRowQuery(DbStatements.FindItemsStatementComplete,
                    new object[] {item.ItemBarcode});

                if (foundItem.Count > 0)
                {
                    SQLiteHelper.nonQuery(DbStatements.UpdateItemsStatement,
                        new object[]
                        {item.ItemBarcode, item.ItemNo, item.ItemDescription, item.ItemVariant, item.ItemUnitOfMeasure});
                }
                else
                {
                    SQLiteHelper.insertQuery(DbStatements.InsertItemsStatement,
                        new object[]
                        {item.ItemBarcode, item.ItemNo, item.ItemDescription, item.ItemVariant, item.ItemUnitOfMeasure});
                }
            }

            Invoke((CloseDelagate)delegate
            {
                DialogResult = DialogResult.OK;
                Close();
            });
        }
    }
}