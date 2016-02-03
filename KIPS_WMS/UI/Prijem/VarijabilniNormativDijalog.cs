using System;
using System.Drawing;
using System.Windows.Forms;
using KIPS_WMS.Model;
using KIPS_WMS.NAV_WS;
using KIPS_WMS.Web;
using KIPS_WMS.Properties;
using System.Collections.Generic;

namespace KIPS_WMS.UI.Prijem
{
    public partial class VarijabilniNormativDijalog : NonFullscreenForm
    {
        private readonly WarehouseReceiptLineModel _selectedLine;
        private readonly decimal _quantity;
        private readonly KIPS_wms _ws = WebServiceFactory.GetWebService();

        public List<SendNormativeModel> _normativeLines = new List<SendNormativeModel>();

        public VarijabilniNormativDijalog(WarehouseReceiptLineModel selectedLine, decimal quantity)
        {
            InitializeComponent();

            _selectedLine = selectedLine;
            _quantity = quantity;

            tbJedinicaMere.Text = _selectedLine.UnitOfMeasureCode;
            tbZaprimljenaKolicina.Text = _quantity.ToString();
            tbOsnovnaJedinicaMere.Text = _selectedLine.NormUom;
            tbKolicinaOsnovnaJedinicaMere.Focus();

            var myAutoScaleFactor = new SizeF(
                AutoScaleDimensions.Width / 96F,
                AutoScaleDimensions.Height / 96F);

            Height = (int)(myAutoScaleFactor.Height * 130) + 30;
        }

        private void bPosalji_Click(object sender, EventArgs e)
        {
            if (tbKolicinaOsnovnaJedinicaMere.Text.Contains(","))
            {
                if (tbKolicinaOsnovnaJedinicaMere.Text.Split(',')[1].Length > _selectedLine.NormRoundingPrecision.Split(',')[1].Length)
                {
                    MessageBox.Show("Nije dobro zaokruženo. Treba zaokružiti na " 
                        + _selectedLine.NormRoundingPrecision.Split(',')[1].Length + " decimale.", Resources.Greska);
                    return;
                }
                
            }
            decimal calculatedFactor = Decimal.Parse(tbFaktorKonverzije.Text);
            decimal normCoefficient = Decimal.Parse(_selectedLine.NormCoefficient);
            decimal percentage = Decimal.Parse(_selectedLine.NormDeviation);
            if (Math.Abs((normCoefficient - calculatedFactor)) > (percentage / 100))
            {
                var dijalog = new PrekoracenaVrednostYesNoDijalog(_selectedLine.NormCoefficient, _selectedLine.NormDeviation, tbFaktorKonverzije.Text);
                DialogResult result = dijalog.ShowDialog();
                if (result == DialogResult.Yes)
                {
                    _normativeLines.Add(new SendNormativeModel("1", "", "", tbKolicinaOsnovnaJedinicaMere.Text));
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    tbKolicinaOsnovnaJedinicaMere.Focus();
                }
            }

        }

        private void tbKolicinaOsnovnaJedinicaMere_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                decimal diff = Convert.ToDecimal(tbKolicinaOsnovnaJedinicaMere.Text) / _quantity;
                tbFaktorKonverzije.Text = diff + "";
            }
            catch (Exception ex)
            {
                tbFaktorKonverzije.Text = "/";
            }
        }

        private void tbKolicinaOsnovnaJedinicaMere_TextChanged(object sender, EventArgs e)
        {
            //tbKolicinaOsnovnaJedinicaMere.Text = tbKolicinaOsnovnaJedinicaMere.Text.Replace('.', ',');
        }

        private void tbKolicinaOsnovnaJedinicaMere_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                tbKolicinaOsnovnaJedinicaMere.Text += ",";
                tbKolicinaOsnovnaJedinicaMere.SelectionStart = tbKolicinaOsnovnaJedinicaMere.Text.Length;
                tbKolicinaOsnovnaJedinicaMere.SelectionLength = 0;
                e.Handled = true;
            }
        }

    }
}