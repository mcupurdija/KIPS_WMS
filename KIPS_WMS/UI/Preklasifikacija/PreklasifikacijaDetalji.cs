using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FileHelpers;
using KIPS_WMS.Model;
using KIPS_WMS.NAV_WS;
using KIPS_WMS.Properties;
using KIPS_WMS.UI.Ostalo;
using KIPS_WMS.Web;
using KIPS_WMS.Data;

namespace KIPS_WMS.UI.Preklasifikacija
{
    public partial class PreklasifikacijaDetalji : Form
    {
        private readonly MobileWMSSync _ws = WebServiceFactory.GetWebService();
        private readonly List<int> lineNumbers = new List<int>();

        private string _itemName;
        private string _itemVariant;
        private string _itemNo;
        private string _itemQuantity;
        private string _itemTrackingType;
        private string _itemUnitOfMeasure;

        public PreklasifikacijaDetalji()
        {
            InitializeComponent();
            //TODO
//            tbSaRegala.Text = "99-99-9";
//            tbNaRegal.Text = "01-01-1";
            listView1.View = View.Details;
            listView1.Columns.Add(Resources.Sifra, 100, HorizontalAlignment.Left);
            listView1.Columns.Add(Resources.Artikal, 200, HorizontalAlignment.Left);
            listView1.Columns.Add(Resources.Kolicina, 50, HorizontalAlignment.Left);
            listView1.Columns.Add(Resources.JM, 50, HorizontalAlignment.Left);
            listView1.Columns.Add(Resources.SaRegala, 100, HorizontalAlignment.Left);
            listView1.Columns.Add(Resources.NaRegal, 100, HorizontalAlignment.Left);
        }

        private void bPronadji_Click(object sender, EventArgs e)
        {
            var odabirArtikla = new OdabirArtiklaDijalog(tbPronadji.Text.Trim());
            DialogResult result = odabirArtikla.ShowDialog();

            if (result == DialogResult.OK)
            {
                _itemName = odabirArtikla.SelectedItem[DatabaseModel.ItemDbModel.ItemDescription].ToString();
                _itemUnitOfMeasure = odabirArtikla.SelectedItem[DatabaseModel.ItemDbModel.ItemUnitOfMeasure].ToString();
                _itemNo = odabirArtikla.SelectedItem[DatabaseModel.ItemDbModel.ItemBarcode].ToString();
                _itemQuantity = odabirArtikla.SelectedItem[DatabaseModel.ItemDbModel.ItemQuantity].ToString();
                _itemTrackingType = odabirArtikla.SelectedItem[DatabaseModel.ItemDbModel.ItemTracking].ToString();
                _itemVariant = odabirArtikla.SelectedItem[DatabaseModel.ItemDbModel.ItemVariant].ToString();
                lbNaziv.Text = Resources.NazivArtika + ": " + _itemName;
                lbJM.Text = _itemUnitOfMeasure;
                tbPronadji.Text = _itemNo;
                tbSaRegala.Focus();
            }
        }

        private void bDodaj_Click(object sender, EventArgs e)
        {
            try
            {
                //List<object> baseUnit = SQLiteHelper.oneRowQuery(DbStatements.FindItemBaseUnitOfMeasure,
                //            new object[] { _itemNo });
                int kolicina = Int32.Parse(tbKolicina.Text)*Int32.Parse(_itemQuantity);
                string lines = "";
                int numOfLine = 0;
                Cursor.Current = Cursors.WaitCursor;

                if (Int32.Parse(_itemTrackingType) != 0)
                {
                    var pracenje = new Pracenje(_itemNo + "", kolicina, Int32.Parse(_itemTrackingType));
                    DialogResult result = pracenje.ShowDialog();

                    if (result == DialogResult.OK)
                    {                      
                        var engine = new FileHelperEngine(typeof(SendTrackingModel));
                        lines = engine.WriteString(pracenje._lines);                        
                    }
                }

                var loginData = RegistryUtils.GetLoginData();
                _ws.BinToBinMovement(_itemNo, tbKolicina.Text.Trim(), _itemUnitOfMeasure, loginData.Magacin, loginData.Podmagacin, tbSaRegala.Text,
                    tbNaRegal.Text, RegistryUtils.GetLastUsername(), lines, ref numOfLine);
                lineNumbers.Add(numOfLine);

                var lvi = new ListViewItem(new[]
                    {
                        _itemNo, _itemName, tbKolicina.Text, _itemUnitOfMeasure, tbSaRegala.Text, tbNaRegal.Text
                    });
                listView1.Items.Add(lvi);

                tbKolicina.Text = "";
                tbPronadji.Text = "";
                lbNaziv.Text = Resources.NazivArtika + ": ";
                lbJM.Text = Resources.JM + ": ";
                tbNaRegal.Text = "";
                tbSaRegala.Text = "";

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

        private void bPonisti_Click(object sender, EventArgs e)
        {
            tbPronadji.Text = "";
        }

        private void bObrisi_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count != 1) return;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                int index = listView1.SelectedIndices[0];

                var loginData = RegistryUtils.GetLoginData();
                _ws.DeleteReclassificationLines(lineNumbers[index], RegistryUtils.GetLastUsername(), loginData.Magacin, loginData.Podmagacin, 0);
                lineNumbers.RemoveAt(index);
                listView1.Items.RemoveAt(index);
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

        private void bObrisiSve_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                var loginData = RegistryUtils.GetLoginData();
                _ws.DeleteReclassificationLines(0, RegistryUtils.GetLastUsername(), loginData.Magacin, loginData.Podmagacin, 1);
                listView1.Items.Clear();
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

        private void bKnjizi_Click(object sender, EventArgs e)
        {
            int status = 0;
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                var loginData = RegistryUtils.GetLoginData();
                _ws.PostReclassification(RegistryUtils.GetLastUsername(), loginData.Magacin, loginData.Podmagacin, ref status);
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

        private void tbPronadji_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //bPronadji_Click(sender, e);
                try
                {
                    Cursor.Current = Cursors.WaitCursor;

                    var _items = SQLiteHelper.multiRowQuery(DbStatements.FindItemsStatementBarcode,
                        new object[] { tbPronadji.Text });
                    if (_items.Count > 1 || _items.Count == 0) {
                        MessageBox.Show("Neispravan barkod.", Resources.Greska);
                    }
                    else
                    {

                        _itemName = _items[0][DatabaseModel.ItemDbModel.ItemDescription].ToString();
                        _itemUnitOfMeasure = _items[0][DatabaseModel.ItemDbModel.ItemUnitOfMeasure].ToString();
                        _itemNo = _items[0][DatabaseModel.ItemDbModel.ItemBarcode].ToString();
                        _itemQuantity = _items[0][DatabaseModel.ItemDbModel.ItemQuantity].ToString();
                        _itemTrackingType = _items[0][DatabaseModel.ItemDbModel.ItemTracking].ToString();
                        _itemVariant = _items[0][DatabaseModel.ItemDbModel.ItemVariant].ToString();

                        lbNaziv.Text = Resources.NazivArtika + ": " + _itemName;
                        lbJM.Text = _itemUnitOfMeasure;
                        tbPronadji.Text = _itemNo;
                        tbSaRegala.Focus();

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

        private void bNazad_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bStanje_Click(object sender, EventArgs e)
        {
            new ArtikliPoRegalimaDijalog(tbSaRegala.Text, _itemNo, _itemVariant).ShowDialog();
        }
    }
}