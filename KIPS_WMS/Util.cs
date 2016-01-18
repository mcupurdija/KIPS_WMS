using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Reflection;
using System.Web.Services.Protocols;
using System.Windows.Forms;

namespace KIPS_WMS
{
    public static class Util
    {
        public const int CsvImportCustomers = 1;
        public const int CsvImportItems = 2;
        public static NetworkCredential GoProCredentials = new NetworkCredential("wurthtest", "remote", "gopro");
        public static NetworkCredential KipsCredentials = new NetworkCredential("wurthtest", "remote", "gopro");


        public static string GetCurrentDirectory()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
        }

        public static string GetDbConnectionString()
        {
            return @"Data Source=" + GetCurrentDirectory() + "\\Data\\database.s3db;Version=3;FailIfMissing=True;";
        }

        public static CultureInfo GetLocalCulture()
        {
            return CultureInfo.CreateSpecificCulture("sr");
        }

        public static void GeneralExceptionProcessing(Exception ex)
        {
            if (ex is SoapException)
            {
                MessageBox.Show(ex.Message, "Greška");
            }
            else if (ex is WebException)
            {
                MessageBox.Show(ex.Message, "Greška");
            }
            else
            {
                MessageBox.Show(ex.Message, "Greška");
            }
        }
    }
}