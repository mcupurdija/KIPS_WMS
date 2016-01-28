using System;
using System.Windows.Forms;
using KIPS_WMS.Model;

namespace KIPS_WMS.UI.Prijem
{
    public partial class PrijemDetalji : Form
    {
        private WarehouseReceiptLineModel _selectedLine;

        public PrijemDetalji()
        {
            InitializeComponent();
        }

        public PrijemDetalji(WarehouseReceiptLineModel selectedLine)
        {
            InitializeComponent();

            _selectedLine = selectedLine;

            listBox1.Items.Clear();
            listBox1.Items.Add(String.Format("{0} {1}", "Šifra:", _selectedLine.ItemNo));
            listBox1.Items.Add(String.Format("{0} {1}", "Naziv:", _selectedLine.ItemDescription));
            listBox1.Items.Add(String.Format("{0} {1}", "Regal:", _selectedLine.BinCode));
            listBox1.Items.Add(String.Format("{0} {1}", "Jedinica mere za prijem:", _selectedLine.UnitOfMeasureCode));

            var culture = Utils.GetLocalCulture();
            decimal toReceiveQuantity = decimal.Parse(_selectedLine.QuantityToReceive, culture);
            decimal outstandingQuantity = decimal.Parse(_selectedLine.QuantityOutstanding, culture);
            decimal remainingQuantity = outstandingQuantity - toReceiveQuantity;

            listBox1.Items.Add(String.Format("{0} {1}", "Količina za prijem:", _selectedLine.QuantityOutstanding));
            listBox1.Items.Add(String.Format("{0} {1}", "Zaprimljena količina:", _selectedLine.QuantityToReceive));
            listBox1.Items.Add(String.Format("{0} {1}", "Preostalo za prijem:", remainingQuantity.ToString("0,0", culture)));

            listBox1.SelectedIndex = listBox1.Items.Count - 1;
        }
    }
}