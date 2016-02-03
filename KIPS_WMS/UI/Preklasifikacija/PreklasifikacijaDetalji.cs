﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FileHelpers;
using KIPS_WMS.Model;
using KIPS_WMS.NAV_WS;
using KIPS_WMS.Properties;
using KIPS_WMS.Web;
using KIPS_WMS.UI.Ostalo;

namespace KIPS_WMS.UI.Preklasifikacija
{
    public partial class PreklasifikacijaDetalji : Form
    {
        private readonly KIPS_wms _ws = WebServiceFactory.GetWebService();
        private readonly List<int> lineNumbers = new List<int>();

        private string _itemName;
        private string _itemNo;
        private string _itemQuantity;
        private string _itemTrackingType;
        private string _itemUnitOfMeasure;
        private string _itemVariant;

        public PreklasifikacijaDetalji()
        {
            InitializeComponent();
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
                _itemVariant = odabirArtikla.SelectedItem[DatabaseModel.ItemDbModel.ItemVariant] == null ? "" : odabirArtikla.SelectedItem[DatabaseModel.ItemDbModel.ItemVariant].ToString();
                lbNaziv.Text = Resources.NazivArtika + ": " + _itemName;
                lbJM.Text = Resources.JM + ": " + _itemUnitOfMeasure;
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

                if (Int32.Parse(_itemTrackingType) != 0)
                {
                    var pracenje = new Pracenje(_itemNo + "", Int32.Parse(tbKolicina.Text), Int32.Parse(_itemTrackingType));
                    DialogResult result = pracenje.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        Cursor.Current = Cursors.WaitCursor;

                        int numOfLine = 0;
                        var engine = new FileHelperEngine(typeof(SendTrackingModel));
                        string lines = engine.WriteString(pracenje._lines);

                        _ws.BinToBinMovement(_itemNo, _itemQuantity, _itemUnitOfMeasure, "001", "1", tbSaRegala.Text,
                            tbNaRegal.Text, "1", lines, ref numOfLine);
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
                }
                else
                {
                    Cursor.Current = Cursors.WaitCursor;

                    int numOfLine = 0;

                    _ws.BinToBinMovement(_itemNo, _itemQuantity, _itemUnitOfMeasure, "001", "1", tbSaRegala.Text,
                        tbNaRegal.Text, "1", "", ref numOfLine);
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
                _ws.DeleteReclassificationLines(lineNumbers[index], "1", "001", "1", 0);
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

                _ws.DeleteReclassificationLines(0, "1", "001", "1", 1);
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

                _ws.PostReclassification("1", "001", "1", ref status);
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
                bPronadji_Click(sender, e);
            }
        }

        private void bNazad_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bStanje_Click(object sender, EventArgs e)
        {
            new ArtikliPoRegalimaDijalog(tbSaRegala.Text, _itemNo, _itemVariant)
                .ShowDialog();
        }
    }
}