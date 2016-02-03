using FileHelpers;

namespace KIPS_WMS.Model
{
    [DelimitedRecord(";")]
    [IgnoreFirst(1)]
    public class LoginModel
    {
        [FieldQuoted('"', QuoteMode.AlwaysQuoted, MultilineMode.NotAllow)]
        public string Magacin;

        [FieldQuoted('"', QuoteMode.AlwaysQuoted, MultilineMode.NotAllow)] 
        public string Podmagacin;

        [FieldQuoted('"', QuoteMode.AlwaysQuoted, MultilineMode.NotAllow)] 
        public int EvidentiranjeSnNaUlazu;

        [FieldQuoted('"', QuoteMode.AlwaysQuoted, MultilineMode.NotAllow)]
        public int SkeniranjeBarkodaNaPrijemu;

        [FieldQuoted('"', QuoteMode.AlwaysQuoted, MultilineMode.NotAllow)]
        public int SkeniranjeBarkodaNaIsporuci;

        [FieldQuoted('"', QuoteMode.AlwaysQuoted, MultilineMode.NotAllow)]
        public int RadiPrijem;

        [FieldQuoted('"', QuoteMode.AlwaysQuoted, MultilineMode.NotAllow)]
        public int RadiSkladistenje;

        [FieldQuoted('"', QuoteMode.AlwaysQuoted, MultilineMode.NotAllow)]
        public int RadiIsporuku;

        [FieldQuoted('"', QuoteMode.AlwaysQuoted, MultilineMode.NotAllow)]
        public int RadiIzdvajanje;

        [FieldQuoted('"', QuoteMode.AlwaysQuoted, MultilineMode.NotAllow)]
        public int RadiPonude;

        [FieldQuoted('"', QuoteMode.AlwaysQuoted, MultilineMode.NotAllow)]
        public int RadiPrenos;

        [FieldQuoted('"', QuoteMode.AlwaysQuoted, MultilineMode.NotAllow)]
        public int RadiPreklasifikaciju;

        [FieldQuoted('"', QuoteMode.AlwaysQuoted, MultilineMode.NotAllow)]
        public int RadiPopis;
    }
}