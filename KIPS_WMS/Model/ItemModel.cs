using FileHelpers;

namespace KIPS_WMS.Model
{
    [DelimitedRecord(";")]
    [IgnoreFirst(1)]
    public class ItemModel
    {
        [FieldQuoted('"', QuoteMode.AlwaysQuoted, MultilineMode.NotAllow)]
        public string ItemBarcode;

        [FieldQuoted('"', QuoteMode.AlwaysQuoted, MultilineMode.NotAllow)] 
        public string ItemNo;

        [FieldQuoted('"', QuoteMode.AlwaysQuoted, MultilineMode.NotAllow)] 
        public string ItemVariant;

        [FieldQuoted('"', QuoteMode.AlwaysQuoted, MultilineMode.NotAllow)] 
        public string ItemDescription;

        [FieldQuoted('"', QuoteMode.AlwaysQuoted, MultilineMode.NotAllow)] 
        public string ItemUnitOfMeasure;
    }
}
