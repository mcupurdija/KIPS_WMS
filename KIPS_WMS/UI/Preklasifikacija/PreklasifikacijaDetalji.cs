using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using FileHelpers;
using KIPS_WMS.Data;
using KIPS_WMS.Model;
using KIPS_WMS.NAV_WS;
using KIPS_WMS.Properties;
using KIPS_WMS.UI.Ostalo;
using KIPS_WMS.Web;

namespace KIPS_WMS.UI.Preklasifikacija
{
    public partial class PreklasifikacijaDetalji : Form
    {
        private readonly List<int> _lineNumbers = new List<int>();
        private readonly MobileWMSSync _ws = WebServiceFactory.GetWebService();

        private string _itemName;
        private string _itemNo;
        private string _itemQuantity;
        private string _itemTrackingType;
        private string _itemUnitOfMeasure;
        private string _itemVariant;

        public PreklasifikacijaDetalji()
        {
            InitializeComponent();
            //TODO
            //            tbSaRegala.Text = "99-99-9";
            //            tbNaRegal.Text = "01-01-1";
            listView1.View = View.Details;
            listView1.Columns.Add(Resources.Sifra, 60, HorizontalAlignment.Left);
            listView1.Columns.Add(Resources.Naziv, 60, HorizontalAlignment.Left);
            listView1.Columns.Add(Resources.Kolicina, 60, HorizontalAlignment.Left);
            listView1.Columns.Add(Resources.JM, 60, HorizontalAlignment.Left);
            listView1.Columns.Add(Resources.SaRegala, 60, HorizontalAlignment.Left);
            listView1.Columns.Add(Resources.NaRegal, 60, HorizontalAlignment.Left);
        }

        private void bPronadji_Click(object sender, EventArgs e)
        {
            var odabirArtikla = new OdabirArtiklaDijalog(tbPronadji.Text.Trim());
            DialogResult result = odabirArtikla.ShowDialog();

            if (result == DialogResult.OK)
            {
                _itemName = odabirArtikla.SelectedItem[DatabaseModel.ItemDbModel.ItemDescription].ToString();
                _itemUnitOfMeasure = odabirArtikla.SelectedItem[DatabaseModel.ItemDbModel.ItemUnitOfMeasure].ToString();
                _itemNo = odabirArtikla.SelectedItem[DatabaseModel.ItemDbModel.ItemCode].ToString();
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
                decimal kolicina = decimal.Parse(tbKolicina.Text, Utils.GetLocalCulture())*decimal.Parse(_itemQuantity);
                string lines = "";
                int numOfLine = 0;


                if (Int32.Parse(_itemTrackingType) != 0)
                {
                    var pracenje = new Pracenje(_itemNo + "", kolicina, Int32.Parse(_itemTrackingType));
                    DialogResult result = pracenje.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        var engine = new FileHelperEngine(typeof (SendTrackingModel));
                        lines = engine.WriteString(pracenje.Lines);
                    }
                }
                Cursor.Current = Cursors.WaitCursor;
                LoginModel loginData = RegistryUtils.GetLoginData();
                _ws.BinToBinMovement(_itemNo, tbKolicina.Text.Trim(), _itemUnitOfMeasure, loginData.Magacin,
                    loginData.Podmagacin, tbSaRegala.Text,
                    tbNaRegal.Text, RegistryUtils.GetLastUsername(), lines, ref numOfLine);
                _lineNumbers.Add(numOfLine);

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
                tbPronadji.Focus();
            }
        }

        private void bPonisti_Click(object sender, EventArgs e)
        {
            tbPronadji.Text = "";
            tbSaRegala.Text = "";
            tbNaRegal.Text = "";
            tbKolicina.Text = "";
            lbJM.Text = Resources.JM + ": ";
            lbNaziv.Text = Resources.NazivArtika + ": ";
            tbPronadji.Focus();
        }

        private void bObrisi_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count != 1) return;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                int index = listView1.SelectedIndices[0];

                LoginModel loginData = RegistryUtils.GetLoginData();
                _ws.DeleteReclassificationLines(_lineNumbers[index], RegistryUtils.GetLastUsername(), loginData.Magacin,
                    loginData.Podmagacin, 0);
                _lineNumbers.RemoveAt(index);
                listView1.Items.RemoveAt(index);
            }
            catch (Exception ex)
            {
                Utils.GeneralExceptionProcessing(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                tbPronadji.Focus();
            }
        }

        private void bObrisiSve_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                LoginModel loginData = RegistryUtils.GetLoginData();
                _ws.DeleteReclassificationLines(0, RegistryUtils.GetLastUsername(), loginData.Magacin,
                    loginData.Podmagacin, 1);
                listView1.Items.Clear();
            }
            catch (Exception ex)
            {
                Utils.GeneralExceptionProcessing(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                tbPronadji.Focus();
            }
        }

        private void bKnjizi_Click(object sender, EventArgs e)
        {
            int status = 0;
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                LoginModel loginData = RegistryUtils.GetLoginData();
                _ws.PostReclassification(RegistryUtils.GetLastUsername(), loginData.Magacin, loginData.Podmagacin,
                    ref status);
                listView1.Items.Clear();
                MessageBox.Show("Uspešno proknjiženo!");
            }
            catch (Exception ex)
            {
                Utils.GeneralExceptionProcessing(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                tbPronadji.Focus();
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

                    List<object[]> items = SQLiteHelper.multiRowQuery(DbStatements.FindItemsStatementBarcode,
                        new object[] {tbPronadji.Text});
                    if (items.Count == 0)
                    {
                        items = SQLiteHelper.multiRowQuery(DbStatements.FindItemsStatementCode,
                            new object[] {tbPronadji.Text});
                    }
                    if (items.Count == 0)
                    {
                        MessageBox.Show("Nije pronađen artikal.", Resources.Greska);
                        tbPronadji.Text = "";
                        tbSaRegala.Text = "";
                        tbNaRegal.Text = "";
                        tbPronadji.Focus();
                    }
                    else
                    {
                        _itemName = items[0][DatabaseModel.ItemDbModel.ItemDescription].ToString();
                        _itemUnitOfMeasure = items[0][DatabaseModel.ItemDbModel.ItemUnitOfMeasure].ToString();
                        _itemNo = items[0][DatabaseModel.ItemDbModel.ItemCode].ToString();
                        _itemQuantity = items[0][DatabaseModel.ItemDbModel.ItemQuantity].ToString();
                        _itemTrackingType = items[0][DatabaseModel.ItemDbModel.ItemTracking].ToString();
                        _itemVariant = items[0][DatabaseModel.ItemDbModel.ItemVariant].ToString();

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

        private void tbSaRegala_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbNaRegal.Focus();
            }
        }

        private void tbNaRegal_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbKolicina.Focus();
            }
        }

        private void tbKolicina_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                tbKolicina.Text += ",";
                tbKolicina.SelectionStart = tbKolicina.Text.Length;
                tbKolicina.SelectionLength = 0;
                e.Handled = true;
            }
        }

        private void cObrisi_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count != 1) return;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                int index = listView1.SelectedIndices[0];

                LoginModel loginData = RegistryUtils.GetLoginData();
                _ws.DeleteReclassificationLines(_lineNumbers[index], RegistryUtils.GetLastUsername(), loginData.Magacin,
                    loginData.Podmagacin, 0);
                _lineNumbers.RemoveAt(index);
                listView1.Items.RemoveAt(index);
            }
            catch (Exception ex)
            {
                Utils.GeneralExceptionProcessing(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                tbPronadji.Focus();
            }
        }

        private void cObrisiSve_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                LoginModel loginData = RegistryUtils.GetLoginData();
                _ws.DeleteReclassificationLines(0, RegistryUtils.GetLastUsername(), loginData.Magacin,
                    loginData.Podmagacin, 1);
                listView1.Items.Clear();
            }
            catch (Exception ex)
            {
                Utils.GeneralExceptionProcessing(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                tbPronadji.Focus();
            }
        }

        private void cKnjizi_Click(object sender, EventArgs e)
        {
            int status = 0;
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                LoginModel loginData = RegistryUtils.GetLoginData();
                _ws.PostReclassification(RegistryUtils.GetLastUsername(), loginData.Magacin, loginData.Podmagacin,
                    ref status);
                listView1.Items.Clear();
                MessageBox.Show("Uspešno proknjiženo!");
            }
            catch (Exception ex)
            {
                Utils.GeneralExceptionProcessing(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                tbPronadji.Focus();
            }
        }

        private void toolBar1_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            switch (toolBar1.Buttons.IndexOf(e.Button))
            {
                case 0:
                    cObrisiSve_Click(null, null);
                    Close();
                    break;
                case 1:
                    contextMenu1.Show(toolBar1, new Point(80, 10));
                    break;
            }
        }

        private void tbKolicina_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bDodaj_Click(sender, e);
            }
        }
    }
}