using FileHelpers;

namespace KIPS_WMS.Model
{
    [DelimitedRecord(";")]
    [IgnoreFirst(1)]
    class WarehouseReceiptModel
    {
        [FieldQuoted('"', QuoteMode.AlwaysQuoted, MultilineMode.NotAllow)]
        public string ReceiptCode;

        [FieldQuoted('"', QuoteMode.AlwaysQuoted, MultilineMode.NotAllow)]
        public string ReceiptDate;

        [FieldQuoted('"', QuoteMode.AlwaysQuoted, MultilineMode.NotAllow)]
        public string SourceCode;

        [FieldQuoted('"', QuoteMode.AlwaysQuoted, MultilineMode.NotAllow)]
        public string SourceDescription;
    }
}
