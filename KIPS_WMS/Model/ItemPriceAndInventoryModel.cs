using FileHelpers;

namespace KIPS_WMS.Model
{
    [DelimitedRecord(";")]
    class ItemPriceAndInventoryModel
    {
        public double UnitPrice { get; set; }

        public double UnitPriceWithDiscount { get; set; }

        public double TotalWarehouseQuantity { get; set; }

        public double AvailableWarehouseQuantity { get; set; }

        public double TotalLinkedWarehouseQuantity { get; set; }

        public double AvailableLinkedWarehouseQuantity { get; set; }
    }
}
