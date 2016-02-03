using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using FileHelpers;

namespace KIPS_WMS.Model
{
    [DelimitedRecord(";")]
    public class SendNormativeModel
    {
        [FieldQuoted('"', QuoteMode.AlwaysQuoted, MultilineMode.NotAllow)]
        public string NormativeType;

        [FieldQuoted('"', QuoteMode.AlwaysQuoted, MultilineMode.NotAllow)]
        public string TrackingCode;

        [FieldQuoted('"', QuoteMode.AlwaysQuoted, MultilineMode.NotAllow)]
        public string ExpirationDate;

        [FieldQuoted('"', QuoteMode.AlwaysQuoted, MultilineMode.NotAllow)]
        public string Quantity;


        public SendNormativeModel()
        {
        }

        public SendNormativeModel(string normativeType, string trackingCode, string expirationDate, string quantity)
        {
            NormativeType = normativeType;
            TrackingCode = trackingCode;
            ExpirationDate = expirationDate;
            Quantity = quantity;
        }

    }
}
