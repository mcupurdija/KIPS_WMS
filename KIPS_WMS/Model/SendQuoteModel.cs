using FileHelpers;

namespace KIPS_WMS.Model
{
    [DelimitedRecord(";")]
    internal class SendQuoteModel
    {
        [FieldQuoted('"', QuoteMode.AlwaysQuoted, MultilineMode.NotAllow)]
        public string ItemCode;

        [FieldQuoted('"', QuoteMode.AlwaysQuoted, MultilineMode.NotAllow)]
        public string VariantCode;

        [FieldQuoted('"', QuoteMode.AlwaysQuoted, MultilineMode.NotAllow)]
        public string UnitOfMeasureCode;

        [FieldQuoted('"', QuoteMode.AlwaysQuoted, MultilineMode.NotAllow)]
        public string WarehouseCode;

        [FieldQuoted('"', QuoteMode.AlwaysQuoted, MultilineMode.NotAllow)]
        public string ItemQuantity;

        public SendQuoteModel()
        {
        }

        public SendQuoteModel(string itemCode, string variantCode, string unitOfMeasureCode, string warehouseCode, string itemQuantity)
        {
            ItemCode = itemCode;
            VariantCode = variantCode;
            UnitOfMeasureCode = unitOfMeasureCode;
            WarehouseCode = warehouseCode;
            ItemQuantity = itemQuantity;
        }
    }
}
