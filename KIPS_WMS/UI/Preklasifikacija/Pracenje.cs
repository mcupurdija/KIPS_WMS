using System;
using System.Collections.Generic;
using System.Windows.Forms;
using KIPS_WMS.Model;
using KIPS_WMS.Properties;
using System.Globalization;

namespace KIPS_WMS.UI.Preklasifikacija
{
    public partial class Pracenje : Form
    {
        private readonly string _itemNo;
        private readonly decimal _quantity;
        private readonly int _trackingType;

        private readonly CultureInfo culture = Utils.GetLocalCulture();

        private decimal _currQuantity;
        public List<SendTrackingModel> _lines;

        public Pracenje()
        {
            InitializeComponent();
        }

        public Pracenje(string itemNo, decimal quantity, int trackingType)
        {
            InitializeComponent();
            _lines = new List<SendTrackingModel>();
            _itemNo = itemNo;
            _quantity = quantity;
            _trackingType = trackingType;
            _currQuantity = 0;
            if (_trackingType == 1)
            {
                lTekst.Text = Resources.SN + ":";
                lSifra.Text += _itemNo;
                tbKolicina.Text = "1";
                tbKolicina.Enabled = false;
                dtDatum.Visible = false;

                lKolicina.Text = "0/" + _quantity.ToString("N3",culture);
                listView1.Clear();
                listView1.View = View.Details;
                listView1.Columns.Add(Resources.Kolicina, 100, HorizontalAlignment.Left);
                listView1.Columns.Add(Resources.SerijskiBroj, 180, HorizontalAlignment.Left);
            }
            else
            {
                lTekst.Text = Resources.BrSerije + ":";
                lSifra.Text += _itemNo;
                lKolicina.Text = "0/" + _quantity.ToString("N3", culture);
                tbKolicina.Text = "";
                tbKolicina.Enabled = true;
                listView1.Clear();
                listView1.View = View.Details;

                if (_trackingType == 2)
                {
                    dtDatum.Visible = true;
                    listView1.Columns.Add(Resources.Kolicina, 80, HorizontalAlignment.Left);
                    listView1.Columns.Add(Resources.BrojSerije, 80, HorizontalAlignment.Left);
                    listView1.Columns.Add(Resources.DatumIsticanja, 140, HorizontalAlignment.Left);
                }
                if (_trackingType == 3)
                {
                    dtDatum.Visible = false;
                    listView1.Columns.Add(Resources.Kolicina, 80, HorizontalAlignment.Left);
                    listView1.Columns.Add(Resources.BrojSerije, 80, HorizontalAlignment.Left);
                }
            }
        }

        private void bDodaj_Click(object sender, EventArgs e)
        {
            if (_trackingType == 1 && _currQuantity < _quantity)
            {
                var lvi = new ListViewItem(new[]
                {
                    "1", tbSN.Text
                });
                _lines.Add(new SendTrackingModel(_trackingType + "", tbSN.Text, "", "1"));
                listView1.Items.Add(lvi);
                _currQuantity++;
                lKolicina.Text = _currQuantity.ToString("N3", culture) + "/" + _quantity.ToString("N3", culture);
                tbSN.Text = "";
                tbSN.Focus();
            }
            if (_trackingType == 2 || _trackingType == 3 && _currQuantity < _quantity)
            {
                try
                {
                    if ((decimal.Parse(tbKolicina.Text, culture) + _currQuantity) <= _quantity)
                    {
                        var lvi = new ListViewItem(new[]
                        {
                            "", ""
                        });

                        if (_trackingType == 2)
                        {
                            lvi = new ListViewItem(new[]
                            {
                                tbKolicina.Text, tbSN.Text, dtDatum.Text
                            });
                            _lines.Add(new SendTrackingModel(_trackingType + "", tbSN.Text, dtDatum.Text, tbKolicina.Text));
                        }
                        if (_trackingType == 3)
                        {
                            lvi = new ListViewItem(new[]
                            {
                                tbKolicina.Text, tbSN.Text
                            });
                            _lines.Add(new SendTrackingModel(_trackingType + "", tbSN.Text, "", tbKolicina.Text));
                        }
                        listView1.Items.Add(lvi);
                        _currQuantity += decimal.Parse(tbKolicina.Text,culture);
                        lKolicina.Text = _currQuantity.ToString("N3", culture) + "/" + _quantity.ToString("N3", culture);
                        tbSN.Text = "";
                        tbSN.Focus();
                        tbKolicina.Text = "";
                    }
                    else
                    {
                        MessageBox.Show(Resources.PrekoracenaKolicina, Resources.Greska);
                        tbKolicina.Text = "";
                        tbKolicina.Focus();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Resources.NeispravnaKolicina, Resources.Greska);
                }
            }
            if (_currQuantity.ToString("N3", culture) == _quantity.ToString("N3", culture))
            {
                MessageBox.Show(Resources.DostignutaKolicina, Resources.Kraj);
            }
        }

        private void bDalje_Click(object sender, EventArgs e)
        {
            if (_currQuantity == _quantity)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show(Resources.NedostignutaKolicina, Resources.Greska);
            }
        }

        private void bObrisi_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count != 1) return;

            int index = listView1.SelectedIndices[0];
            listView1.Items.RemoveAt(index);
            
            _currQuantity -= decimal.Parse(_lines[index].Quantity, culture);
            _lines.RemoveAt(index);
            lKolicina.Text = _currQuantity.ToString("N3", culture) + "/" + _quantity.ToString("N3", culture);
        }

        private void tbSN_KeyUp(object sender, KeyEventArgs e)
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
    }
}