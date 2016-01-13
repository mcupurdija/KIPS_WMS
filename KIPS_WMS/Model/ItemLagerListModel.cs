using FileHelpers;

namespace KIPS_WMS.Model
{
    [DelimitedRecord(";")]
    internal class ItemLagerListModel
    {
        public string WarehouseCode { get; set; }

        public string WarehouseName { get; set; }

        public string UnitOfMeasure { get; set; }

        public double TotalQuantity { get; set; }

        public double AvailableQuantity { get; set; }
    }
}
