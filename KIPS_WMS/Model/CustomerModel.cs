using FileHelpers;

namespace KIPS_WMS.Model
{
    [DelimitedRecord(";")]
    [IgnoreFirst(1)]
    public class CustomerModel
    {
        [FieldQuoted('"', QuoteMode.AlwaysQuoted, MultilineMode.NotAllow)]
        public string CustomerBarcode;

        [FieldQuoted('"', QuoteMode.AlwaysQuoted, MultilineMode.NotAllow)]
        public string CustomerCode;

        [FieldQuoted('"', QuoteMode.AlwaysQuoted, MultilineMode.NotAllow)]
        public string CustomerName;

    }
}
