using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using KIPS_WMS.Model;
using KIPS_WMS.Properties;

namespace KIPS_WMS.UI.Preklasifikacija
{
    public partial class Pracenje : Form
    {
        private readonly CultureInfo _culture = Utils.GetLocalCulture();
        private readonly decimal _quantity;
        private readonly int _trackingType;

        public List<SendTrackingModel> Lines;
        private decimal _currQuantity;

        public Pracenje()
        {
            InitializeComponent();
        }

        public Pracenje(string itemNo, decimal quantity, int trackingType)
        {
            InitializeComponent();
            Lines = new List<SendTrackingModel>();
            string itemNo1 = itemNo;
            _quantity = quantity;
            _trackingType = trackingType;
            _currQuantity = 0;
            if (_trackingType == 1)
            {
                lTekst.Text = Resources.SN + ":";
                lSifra.Text += itemNo1;
                tbKolicina.Text = "1";
                tbKolicina.Enabled = false;
                dtDatum.Visible = false;

                lKolicina.Text = "0/" + _quantity.ToString("#,0.###", _culture);
                listView1.Clear();
                listView1.View = View.Details;
                listView1.Columns.Add(Resources.Kolicina, 100, HorizontalAlignment.Left);
                listView1.Columns.Add(Resources.SerijskiBroj, 180, HorizontalAlignment.Left);
            }
            else
            {
                lTekst.Text = Resources.BrSerije + ":";
                lSifra.Text += itemNo1;
                lKolicina.Text = "0/" + _quantity.ToString("#,0.###", _culture);
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
                Lines.Add(new SendTrackingModel(_trackingType + "", tbSN.Text, "", "1"));
                listView1.Items.Add(lvi);
                _currQuantity++;
                lKolicina.Text = _currQuantity.ToString("#,0.###", _culture) + "/" + _quantity.ToString("#,0.###", _culture);
                tbSN.Text = "";
                tbSN.Focus();
            }
            if (_trackingType == 2 || _trackingType == 3 && _currQuantity < _quantity)
            {
                try
                {
                    if ((decimal.Parse(tbKolicina.Text, _culture) + _currQuantity) <= _quantity)
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
                            Lines.Add(new SendTrackingModel(_trackingType + "", tbSN.Text, dtDatum.Text, tbKolicina.Text));
                        }
                        if (_trackingType == 3)
                        {
                            lvi = new ListViewItem(new[]
                            {
                                tbKolicina.Text, tbSN.Text
                            });
                            Lines.Add(new SendTrackingModel(_trackingType + "", tbSN.Text, "", tbKolicina.Text));
                        }
                        listView1.Items.Add(lvi);
                        _currQuantity += decimal.Parse(tbKolicina.Text, _culture);
                        lKolicina.Text = _currQuantity.ToString("#,0.###", _culture) + "/" +
                                         _quantity.ToString("#,0.###", _culture);
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
            if (_currQuantity.ToString("#,0.###", _culture) == _quantity.ToString("#,0.###", _culture))
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

            _currQuantity -= decimal.Parse(Lines[index].Quantity, _culture);
            Lines.RemoveAt(index);
            lKolicina.Text = _currQuantity.ToString("#,0.###", _culture) + "/" + _quantity.ToString("#,0.###", _culture);
        }

        private void tbSN_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbKolicina.Focus();
            }
            else
            {
                tbSN.Text = tbSN.Text.ToUpper();
                tbSN.SelectionStart = tbSN.Text.Length;
                tbSN.SelectionLength = 0;
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

        private void toolBar1_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            switch (toolBar1.Buttons.IndexOf(e.Button))
            {
                case 0:
                    if (listView1.SelectedIndices.Count != 1) return;

                    int index = listView1.SelectedIndices[0];
                    listView1.Items.RemoveAt(index);

                    _currQuantity -= decimal.Parse(Lines[index].Quantity, _culture);
                    Lines.RemoveAt(index);
                    lKolicina.Text = _currQuantity.ToString("#,0.###", _culture) + "/" + _quantity.ToString("#,0.###", _culture);
                    break;
                case 1:
                    if (_currQuantity == _quantity)
                    {
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                    else
                    {
                        MessageBox.Show(Resources.NedostignutaKolicina, Resources.Greska);
                    }
                    break;
            }
        }

        private void tbKolicina_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                bDodaj_Click(sender, e);
            }
        }
    }
}