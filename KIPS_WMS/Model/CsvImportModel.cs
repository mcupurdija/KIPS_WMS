using FileHelpers;

namespace KIPS_WMS.Model
{
    [DelimitedRecord(";")]
    internal class CsvImportModel
    {
        /// <summary>
        ///     Customers: 1; Items: 2
        /// </summary>
        [FieldQuoted('"', QuoteMode.AlwaysQuoted, MultilineMode.NotAllow)]
        public int TableNo;

        /// <summary>
        ///     Customers: Barcode; Items: Barcode
        /// </summary>
        [FieldQuoted('"', QuoteMode.AlwaysQuoted, MultilineMode.NotAllow)]
        public string Field1;

        /// <summary>
        ///     Customers: Customer code; Items: Item code
        /// </summary>
        [FieldQuoted('"', QuoteMode.AlwaysQuoted, MultilineMode.NotAllow)]
        public string Field2;

        /// <summary>
        ///     Customers: n/a; Items: Item variant
        /// </summary>
        [FieldQuoted('"', QuoteMode.AlwaysQuoted, MultilineMode.NotAllow)]
        public string Field3;

        /// <summary>
        ///     Customers: Customer name; Items: Item description
        /// </summary>
        [FieldQuoted('"', QuoteMode.AlwaysQuoted, MultilineMode.NotAllow)]
        public string Field4;

        /// <summary>
        ///     Customers: n/a; Items: Unit of measure
        /// </summary>
        [FieldQuoted('"', QuoteMode.AlwaysQuoted, MultilineMode.NotAllow)]
        public string Field5;

        /// <summary>
        ///     Customers: n/a; Items: Quantity coefficient
        /// </summary>
        [FieldQuoted('"', QuoteMode.AlwaysQuoted, MultilineMode.NotAllow)]
        public string Field6;

        /// <summary>
        ///     Customers: n/a; Items: Tracking code
        /// </summary>
        [FieldQuoted('"', QuoteMode.AlwaysQuoted, MultilineMode.NotAllow)]
        public string Field7;
    }
}