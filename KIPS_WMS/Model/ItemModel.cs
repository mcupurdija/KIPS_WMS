using FileHelpers;

namespace KIPS_WMS.Model
{
    [DelimitedRecord(";")]
    [IgnoreFirst(1)]
    internal class ItemModel
    {
        public string ItemBarcode { get; set; }

        public string ItemNo { get; set; }

        public string ItemVariant { get; set; }

        public string ItemDescription { get; set; }

        public string ItemUnitOfMeasure { get; set; }
    }
}
