using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using KIPS_WMS.Model;

namespace KIPS_WMS.UI.Ponude
{
    public partial class PonudaKorpa : Form
    {
        private readonly string _quoteNo;
        private readonly string _customerCode;
        private readonly string _customerName;
        public ItemQuoteModel[] QuoteItems;

        private readonly CultureInfo _culture = CultureInfo.CreateSpecificCulture("sr");

        public PonudaKorpa()
        {
            InitializeComponent();
        }

        public PonudaKorpa(string quoteNo, string customerCode, string customerName, ItemQuoteModel[] quoteItems)
        {
            InitializeComponent();

            _quoteNo = quoteNo;
            _customerName = customerName;
            _customerCode = customerCode;
            QuoteItems = quoteItems;
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);

            Text = _quoteNo;
            lKupac.Text = string.Format("{0} - {1}", _customerCode, _customerName);
            lUkupno.Text = string.Format("Ukupno: {0}", SumPrices());
        }

        private decimal SumPrices()
        {
            try
            {
                return QuoteItems.Sum(item => decimal.Parse(item.UnitPrice, _culture));
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}