using FileHelpers;

namespace KIPS_WMS.Model
{
    [DelimitedRecord(";")]
    [IgnoreFirst(1)]
    internal class ItemLagerListModel
    {
        [FieldQuoted('"', QuoteMode.AlwaysQuoted, MultilineMode.NotAllow)] 
        public string WarehouseCode;

        [FieldQuoted('"', QuoteMode.AlwaysQuoted, MultilineMode.NotAllow)] 
        public string WarehouseName;

        [FieldQuoted('"', QuoteMode.AlwaysQuoted, MultilineMode.NotAllow)] 
        public string UnitOfMeasure;

        [FieldQuoted('"', QuoteMode.AlwaysQuoted, MultilineMode.NotAllow)]
        public string TotalQuantity;

        [FieldQuoted('"', QuoteMode.AlwaysQuoted, MultilineMode.NotAllow)]
        public string AvailableQuantity;
    }
}