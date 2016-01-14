using FileHelpers;

namespace KIPS_WMS.Model
{
    [DelimitedRecord(";")]
    internal class ItemInformationModel
    {
        public string ItemCode { get; set; }

        public string ItemDescription { get; set; }

        public string VariantCode { get; set; }

        public string UnitOfMeasureCode { get; set; }

        public string BaseQuantityForSale { get; set; }

        public string UnitOfMeasureForConversion { get; set; }

        public double ConversionCoeficient { get; set; }

        public double UnitPrice { get; set; }

        public double UnitPriceWithDiscount { get; set; }

        public double TotalWarehouseQuantity { get; set; }

        public double AvailableWarehouseQuantity { get; set; }

        public double TotalLinkedWarehouseQuantity { get; set; }

        public double AvailableLinkedWarehouseQuantity { get; set; }
    }
}
