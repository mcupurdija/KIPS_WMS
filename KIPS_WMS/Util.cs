using System.IO;
using System.Net;
using System.Reflection;

namespace KIPS_WMS
{
    public static class Util
    {
        public static NetworkCredential GoProCredentials = new NetworkCredential("wurthtest", "remote", "gopro");
        public static NetworkCredential KipsCredentials = new NetworkCredential("wurthtest", "remote", "gopro");

        public const int CsvImportCustomers = 1;
        public const int CsvImportItems = 2;



        public static string GetCurrentDirectory()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
        }

        public static string GetDbConnectionString()
        {
            return @"Data Source=" + GetCurrentDirectory() + "\\Data\\database.s3db;Version=3;FailIfMissing=True;";
        }
    }
}