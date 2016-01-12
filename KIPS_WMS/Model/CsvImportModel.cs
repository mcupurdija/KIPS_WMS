using FileHelpers;

namespace KIPS_WMS.Model
{
    [DelimitedRecord(";")]
    internal class CsvImportModel
    {
        /// <summary>
        ///     Customers: 1; Items: 2
        /// </summary>
        public int TableNo { get; set; }

        /// <summary>
        ///     Customers: Barcode; Items: Barcode
        /// </summary>
        public string Field1 { get; set; }

        /// <summary>
        ///     Customers: Customer code; Items: Item code
        /// </summary>
        public string Field2 { get; set; }

        /// <summary>
        ///     Customers: n/a; Items: Item variant
        /// </summary>
        public string Field3 { get; set; }

        /// <summary>
        ///     Customers: Customer name; Items: Item description
        /// </summary>
        public string Field4 { get; set; }

        /// <summary>
        ///     Customers: n/a; Items: Unit of measure
        /// </summary>
        public string Field5 { get; set; }
    }
}