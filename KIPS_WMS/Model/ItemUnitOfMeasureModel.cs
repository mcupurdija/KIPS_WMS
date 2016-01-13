using FileHelpers;

namespace KIPS_WMS.Model
{
    [DelimitedRecord(";")]
    internal class ItemUnitOfMeasureModel
    {
        public string UnitOfMeasureCode { get; set; }

        public string UnitOfMeasureForConversion { get; set; }

        public double ConversionCoeficient { get; set; }

        public double TotalQuantity { get; set; }

        public double AvailableQuantity { get; set; }

        public double TotalQuantityConnected { get; set; }

        public double AvailableQuantityConnected { get; set; }
    }
}
