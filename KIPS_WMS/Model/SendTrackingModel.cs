using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using FileHelpers;

namespace KIPS_WMS.Model
{
    [DelimitedRecord(";")]
    public class SendTrackingModel
    {
        [FieldQuoted('"', QuoteMode.AlwaysQuoted, MultilineMode.NotAllow)]
        public string TrackingType;

        [FieldQuoted('"', QuoteMode.AlwaysQuoted, MultilineMode.NotAllow)]
        public string TrackingCode;

        [FieldQuoted('"', QuoteMode.AlwaysQuoted, MultilineMode.NotAllow)]
        public string Date;

        [FieldQuoted('"', QuoteMode.AlwaysQuoted, MultilineMode.NotAllow)]
        public string Quantity;


        public SendTrackingModel()
        {
        }

        public SendTrackingModel(string trackingType, string trackingCode, string date, string quantity)
        {
            TrackingType = trackingType;
            TrackingCode = trackingCode;
            Date = date;
            Quantity = quantity;
        }
    }
}
