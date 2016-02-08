using FileHelpers;

namespace KIPS_WMS.Model
{
    [DelimitedRecord(";")]
    [IgnoreFirst(1)]
    public class WarehousePutAwayLineModel
    {
        [FieldQuoted('"', QuoteMode.AlwaysQuoted, MultilineMode.NotAllow)]
        public string DocumentNo;

        [FieldQuoted('"', QuoteMode.AlwaysQuoted, MultilineMode.NotAllow)]
        public string LineNo;

        [FieldQuoted('"', QuoteMode.AlwaysQuoted, MultilineMode.NotAllow)]
        public string ItemNo;

        [FieldQuoted('"', QuoteMode.AlwaysQuoted, MultilineMode.NotAllow)]
        public string ItemDescription;

        [FieldQuoted('"', QuoteMode.AlwaysQuoted, MultilineMode.NotAllow)]
        public string ItemVariant;

        [FieldQuoted('"', QuoteMode.AlwaysQuoted, MultilineMode.NotAllow)]
        public string BinCode;

        [FieldQuoted('"', QuoteMode.AlwaysQuoted, MultilineMode.NotAllow)]
        public string UnitOfMeasureCode;

        [FieldQuoted('"', QuoteMode.AlwaysQuoted, MultilineMode.NotAllow)]
        public string QuantityOutstanding; // ZA PRIJEM 

        [FieldQuoted('"', QuoteMode.AlwaysQuoted, MultilineMode.NotAllow)]
        public string QuantityToReceive; // ZAPREMLJENA

        [FieldQuoted('"', QuoteMode.AlwaysQuoted, MultilineMode.NotAllow)]
        public string SerialNo;

        [FieldQuoted('"', QuoteMode.AlwaysQuoted, MultilineMode.NotAllow)]
        public string LotNo;

        [FieldQuoted('"', QuoteMode.AlwaysQuoted, MultilineMode.NotAllow)]
        public string ExpirationDate;
    }
}