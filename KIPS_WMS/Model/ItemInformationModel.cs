using FileHelpers;

namespace KIPS_WMS.Model
{
    [DelimitedRecord(";")]
    [IgnoreFirst(1)]
    internal class ItemInformationModel
    {
        [FieldQuoted('"', QuoteMode.AlwaysQuoted, MultilineMode.NotAllow)] 
        public string ItemCode;

        [FieldQuoted('"', QuoteMode.AlwaysQuoted, MultilineMode.NotAllow)] 
        public string ItemDescription;

        [FieldQuoted('"', QuoteMode.AlwaysQuoted, MultilineMode.NotAllow)] 
        public string VariantCode;

        [FieldQuoted('"', QuoteMode.AlwaysQuoted, MultilineMode.NotAllow)] 
        public string UnitOfMeasureCode;

        [FieldQuoted('"', QuoteMode.AlwaysQuoted, MultilineMode.NotAllow)] 
        public string BaseQuantityForSale;

        [FieldQuoted('"', QuoteMode.AlwaysQuoted, MultilineMode.NotAllow)] 
        public string UnitOfMeasureForConversion;

        [FieldQuoted('"', QuoteMode.AlwaysQuoted, MultilineMode.NotAllow)]
        public string ConversionCoeficient;

        [FieldQuoted('"', QuoteMode.AlwaysQuoted, MultilineMode.NotAllow)]
        public string UnitPrice;

        [FieldQuoted('"', QuoteMode.AlwaysQuoted, MultilineMode.NotAllow)]
        public string UnitPriceWithDiscount;

        [FieldQuoted('"', QuoteMode.AlwaysQuoted, MultilineMode.NotAllow)]
        public string TotalWarehouseQuantity;

        [FieldQuoted('"', QuoteMode.AlwaysQuoted, MultilineMode.NotAllow)]
        public string AvailableWarehouseQuantity;

        [FieldQuoted('"', QuoteMode.AlwaysQuoted, MultilineMode.NotAllow)]
        public string TotalLinkedWarehouseQuantity;

        [FieldQuoted('"', QuoteMode.AlwaysQuoted, MultilineMode.NotAllow)]
        public string AvailableLinkedWarehouseQuantity;

        [FieldQuoted('"', QuoteMode.AlwaysQuoted, MultilineMode.NotAllow)]
        public string LocationCode;

    }
}
