using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KIPS_WMS.UI.Prijem
{
    public partial class PrekoracenaVrednostYesNoDijalog : NonFullscreenForm
    {
        private readonly string _normCoeff;
        private readonly string _normDeviation;
        private readonly string _factor;

        public PrekoracenaVrednostYesNoDijalog(string normCoeff, string normDeviation, string factor)
        {
            InitializeComponent();

            _normCoeff = normCoeff;
            _normDeviation = normDeviation;
            _factor = factor;

            label1.Text += "\nFaktor: " + normCoeff + "\nOdstupanje: " + normDeviation + "\nIzracunat faktor: " + Convert.ToDecimal(factor);

            var myAutoScaleFactor = new SizeF(
                AutoScaleDimensions.Width / 96F,
                AutoScaleDimensions.Height / 96F);

            Height = (int)(myAutoScaleFactor.Height * 100);
        }

        private void bDa_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
        }

        private void bNe_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }
    }
}