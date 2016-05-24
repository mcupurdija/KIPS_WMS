using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using KIPS_WMS.Model;
using KIPS_WMS.Properties;
using KIPS_WMS.Data;
using KIPS_WMS.Web;
using KIPS_WMS.NAV_WS;
using System.Drawing;
using FileHelpers;
using System.IO;
using System.Text;

namespace KIPS_WMS.UI.Popis
{
    public partial class NoviPopis : Form
    {
        private readonly MobileWMSSync _ws = WebServiceFactory.GetWebService();
        private readonly CultureInfo _culture = Utils.GetLocalCulture();
        public List<ItemInventoryModel> _inventory;
        private string _barcode = "";
        private string _code = "";
        private string _itemUom = "";
        private string _trackingType = "";

        public NoviPopis(List<ItemInventoryModel> inventory)
        {
            InitializeComponent();
            _inventory = inventory;

            listView1.View = View.Details;
            listView1.Columns.Add("Artikal", 140, HorizontalAlignment.Left);
            listView1.Columns.Add("Regal", 140, HorizontalAlignment.Left);
            listView1.Columns.Add("Količina", 80, HorizontalAlignment.Left);
            listView1.Columns.Add("Praćenje", 120, HorizontalAlignment.Left);
            listView1.Columns.Add("Rok", 140, HorizontalAlignment.Left);

            for (int i = 0; i < _inventory.Count; i++)
            {
                var lvi = new ListViewItem(new[]
                {
                    _inventory[i].ItemCode, _inventory[i].BinCode, _inventory[i].ItemQuantity, _inventory[i].ItemTrackingCode, _inventory[i].ItemDueDate
                });

                listView1.Items.Add(lvi);
            }
            tbRegal.Focus();
        }

        private void bDodaj_Click(object sender, EventArgs e)
        {
            LoginModel login = RegistryUtils.GetLoginData();
            if (login.ObavezanRegal == 1 && tbRegal.Text.Trim().Length == 0)
            {
                MessageBox.Show("Nije unet regal.", Resources.Greska);
                return;
            }
            if (_barcode.Length == 0 || _code.Length == 0 || tbPronadji.Text.Trim().Length == 0)
            {
                MessageBox.Show("Nije unet artikal.", Resources.Greska);
                return;
            }
            if (tbKolicina.Text.Trim().Length == 0)
            {
                MessageBox.Show("Nije uneta količina.", Resources.Greska);
                return;
            }
            if (_trackingType.Length > 0 && _trackingType != "0") {
                if (tbPracenje.Text.Trim().Length == 0) {
                    MessageBox.Show("Nije uneto praćenje.", Resources.Greska);
                    return;
                }
            }
            ItemInventoryModel item = new ItemInventoryModel();
            item.BinCode = tbRegal.Text.Trim();
            item.ItemBarcode = _barcode;
            item.ItemCode = _code;
            item.ItemDueDate = dtDatum.Text.Trim();
            item.ItemQuantity = tbKolicina.Text.Trim();
            item.ItemTrackingCode = tbPracenje.Text.Trim();
            item.ItemUom = _itemUom;
            item.LocationCode = login.Magacin;
            item.UserCode = RegistryUtils.GetLastUsername();
            item.CurrentDate = DateTime.Now.ToString("dd.MM.yyyy");
            item.CurrentTime = DateTime.Now.ToString("HH:mm");

            if (tbPracenje.Text.Trim().Length == 0)
            {
                item.ItemDueDate = "";
            }
            var lvi = new ListViewItem(new[]
                {
                    item.ItemCode, item.BinCode,item.ItemQuantity,item.ItemTrackingCode, item.ItemDueDate
                });

            listView1.Items.Add(lvi);
            _inventory.Add(item);
            tbPronadji.Text = "";
            tbKolicina.Text = "";
            tbPracenje.Text = "";
            tbJM.Text = "";
            if (tbRegal.Text.Trim().Length != 0)
            {
                tbPronadji.Focus();
            }
            else
            {
                tbRegal.Focus();
            }
        }

        private void tbKolicina_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                tbJM.Text += ",";
                tbJM.SelectionStart = tbJM.Text.Length;
                tbJM.SelectionLength = 0;
                e.Handled = true;
            }
        }

        private void toolBar1_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            switch (toolBar1.Buttons.IndexOf(e.Button))
            {
                case 0:
                    DialogResult = DialogResult.OK;
                    Close();

                    break;
                case 1:
                    contextMenu1.Show(toolBar1, new Point(10, 10));
                    break;
                case 2:
                    contextMenu2.Show(toolBar1, new Point(10, 10));
                    break;
            }
        }

        private void tbKolicina_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbPracenje.Focus();
            }
        }

        private void tbRegal_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbPronadji.Focus();
            }
        }

        private void tbPronadji_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                List<object[]> query = SQLiteHelper.multiRowQuery(DbStatements.FindItemsStatementBarcode,
                                            new object[] { tbPronadji.Text.Trim() });

                if (query.Count > 0)
                {
                    _barcode = query[0][DatabaseModel.ItemDbModel.ItemBarcode].ToString();
                    _code = query[0][DatabaseModel.ItemDbModel.ItemCode].ToString();
                    _itemUom = query[0][DatabaseModel.ItemDbModel.ItemUnitOfMeasure].ToString();
                    _trackingType = query[0][DatabaseModel.ItemDbModel.ItemTracking].ToString();

                    tbJM.Text = _itemUom;

                    tbKolicina.Focus();
                }
                else
                {
                    query = SQLiteHelper.multiRowQuery(DbStatements.FindItemsStatementCode,
                                             new object[] { tbPronadji.Text.Trim() });
                    if (query.Count > 0)
                    {
                        _barcode = query[0][DatabaseModel.ItemDbModel.ItemBarcode].ToString();
                        _code = query[0][DatabaseModel.ItemDbModel.ItemCode].ToString();
                        _itemUom = query[0][DatabaseModel.ItemDbModel.ItemUnitOfMeasure].ToString();
                        _trackingType = query[0][DatabaseModel.ItemDbModel.ItemTracking].ToString();

                        tbJM.Text = _itemUom;

                        tbKolicina.Focus();
                    }
                    else
                    {
                        MessageBox.Show(Resources.NijePronadjenArtikal, Resources.Greska);
                    }
                }
            }
        }

        private void tbPracenje_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bDodaj_Click(sender, e);
            }
        }

        private void bTrazi_Click(object sender, EventArgs e)
        {
            List<object[]> query = SQLiteHelper.multiRowQuery(DbStatements.FindItemsStatementBarcode,
                                            new object[] { tbPronadji.Text.Trim() });

            if (query.Count > 0)
            {
                _barcode = query[0][DatabaseModel.ItemDbModel.ItemBarcode].ToString();
                _code = query[0][DatabaseModel.ItemDbModel.ItemCode].ToString();
                _itemUom = query[0][DatabaseModel.ItemDbModel.ItemUnitOfMeasure].ToString();

                tbJM.Text = _itemUom;

                tbKolicina.Focus();
            }
            else
            {
                query = SQLiteHelper.multiRowQuery(DbStatements.FindItemsStatementCode,
                                         new object[] { tbPronadji.Text.Trim() });
                if (query.Count > 0)
                {
                    _barcode = query[0][DatabaseModel.ItemDbModel.ItemBarcode].ToString();
                    _code = query[0][DatabaseModel.ItemDbModel.ItemCode].ToString();
                    _itemUom = query[0][DatabaseModel.ItemDbModel.ItemUnitOfMeasure].ToString();

                    tbJM.Text = _itemUom;

                    tbKolicina.Focus();
                }
                else
                {
                    MessageBox.Show(Resources.NijePronadjenArtikal, Resources.Greska);
                }
            }
        }

        private void cObrisiRed_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count != 1) return;

            int index = listView1.SelectedIndices[0];
            listView1.Items.RemoveAt(index);
            _inventory.RemoveAt(index);
        }

        private void cObrisiSve_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            _inventory = new List<ItemInventoryModel>(); ;
        }

        private void cSacuvajCSV_Click(object sender, EventArgs e)
        {
            try
            {
                if (_inventory.Count > 0)
                {
                    var engine = new FileHelperEngine(typeof(ItemInventoryModel));
                    string lines = engine.WriteString(_inventory);

                    string filename = "\\My Documents\\inventory_" + DateTime.Now.ToString("dd.MM.yyyy_HH.mm.ss") + ".txt";
                    using (var swFile = new StreamWriter(new FileStream(filename, FileMode.Append), Encoding.ASCII))
                    {
                        var sb = new StringBuilder();
                        sb.Append("\"").Append(lines);
                        swFile.WriteLine(sb.ToString());
                    }

                    tbPronadji.Text = "";
                    tbKolicina.Text = "";
                    tbPracenje.Text = "";
                    tbJM.Text = "";
                    _inventory = new List<ItemInventoryModel>();

                    MessageBox.Show("Fajl je sačuvan. " + Environment.NewLine + filename);

                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("Ne postoji nijedan artikal na popisu.", Resources.Greska);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Neuspelo čuvanje fajla.", Resources.Greska);
            }
        }

        private void cPosalji_Click(object sender, EventArgs e)
        {
            try
            {
                if (_inventory.Count > 0)
                {
                    var engine = new FileHelperEngine(typeof(ItemInventoryModel));
                    string lines = engine.WriteString(_inventory);
                    _ws.InsertInventoryCSV(lines);

                    tbPronadji.Text = "";
                    tbKolicina.Text = "";
                    tbPracenje.Text = "";
                    tbJM.Text = "";
                    _inventory = new List<ItemInventoryModel>();

                    MessageBox.Show("Popisna lista uspešno poslata.");

                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("Ne postoji nijedan artikal na popisu.", Resources.Greska);
                }
            }
            catch (Exception ex)
            {
                Utils.GeneralExceptionProcessing(ex);
            }

        }

    }
}