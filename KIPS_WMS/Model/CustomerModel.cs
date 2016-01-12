using FileHelpers;

namespace KIPS_WMS.Model
{
    [DelimitedRecord(";")]
    internal class CustomerModel
    {
        public string CustomerBarcode { get; set; }

        public string CustomerCode { get; set; }

        public string CustomerName { get; set; }
    }
}
