using System.Collections.Generic;

namespace KIPS_WMS.Model
{
    public class PrintHeaderModel
    {
        public string PrinterName { get; set; }

        public int PrintType { get; set; }

        public string DocumentNo { get; set; }

        public string DocumentDate { get; set; }

        public string CustomerCode { get; set; }

        public string CustomerName { get; set; }

        public string Total { get; set; }

        public List<PrintLineModel> Lines { get; set; }
    }
}