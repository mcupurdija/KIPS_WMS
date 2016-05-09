using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Web.Services.Protocols;
using System.Windows.Forms;
using KIPS_WMS.Model;
using KIPS_WMS.Properties;
using OpenNETCF.Windows.Forms;

namespace KIPS_WMS
{
    public static class Utils
    {
        public const string UnknownCustomerCode = "FL00001";

        public const int CsvImportCustomers = 1;
        public const int CsvImportItems = 2;

        public const int PrintTypeShort = 1;
        public const int PrintTypeLong = 2;
        public const int PrintTypeIgnore = 3;

        public const string GoProNavWsUrl = "http://sqlserver:7047/Wurth/ws/Wurth/Codeunit/MobileWMSSync";
        public const string KipsNavWsUrlTest = "http://192.168.10.72:5047/RAZVOJ/WS/KIPS%20d.o.o/Codeunit/MobileWMSSync";
        public const string KipsNavWsUrlProdukcija = "http://192.168.10.72:7397/NAVNasService/WS/KIPS%20d.o.o/Codeunit/MobileWMSSync";
        public const string KipsNavWsUrlProdukcija2016 = "http://192.168.10.20:7077/KIPS_NAV_90_PROD_WS/WS/KIPS%20d.o.o./Codeunit/MobileWMSSync";
        public static NetworkCredential GoProCredentials = new NetworkCredential("wurthtest", "remote", "gopro");
        public static NetworkCredential KipsCredentials = new NetworkCredential("gopro", "Sifra123", "KIPS");

        //private const string PrintServerAddress = "http://192.168.1.55/";
        private const string PrintServerAddress = "http://192.168.10.18/";
        public const string PrintServerApiPath = PrintServerAddress + "KIPSPrintServer/api/Print";
        public const string PrintServerApiTestPath = PrintServerAddress + "KIPSPrintServer/api/Test";
        public const string DateApiPath = PrintServerAddress + "KIPSPrintServer/api/App";
        public const string DeviceApiPath = PrintServerAddress + "KIPSPrintServer/api/Devices";

        public const int DocumentTypePrijem = 1;
        public const int DocumentTypeIsporuka = 2;
        public const int DocumentTypeSkladistenje = 3;
        public const int DocumentTypeIzdvajanje = 4;


        public const string AppVersion = "1.0.3";


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
            CultureInfo culture = CultureInfo.CreateSpecificCulture("sr");
            culture.NumberFormat.NumberDecimalSeparator = ",";
            culture.NumberFormat.NumberGroupSeparator = ".";
            return culture;
        }

        public static void GeneralExceptionProcessing(Exception ex)
        {
            if (ex is SoapException)
            {
                MessageBox.Show(Resources.GreskaWebServis + " " + ex.Message, Resources.Greska);
            }
            else if (ex is WebException)
            {
                MessageBox.Show(Resources.GreskaPovezivanje + " " + ex.Message, Resources.Greska);
            }
            else
            {
                MessageBox.Show(ex.Message, Resources.Greska);
            }
        }

        public static void DrawTwoLinesListBox(DrawItemEventArgs e, string firstLine, string secondLine)
        {
            int index = e.Index;
            SolidBrush brush;
            if (e.State == DrawItemState.Selected)
            {
                e.DrawBackground(Color.Blue);
                brush = new SolidBrush(Color.White);
            }
            else
            {
                e.DrawBackground(index % 2 == 0 ? SystemColors.Control : Color.White);
                brush = new SolidBrush(Color.Black);
            }

            e.Graphics.DrawString(firstLine,
                new Font(FontFamily.GenericSansSerif, 8F, FontStyle.Bold), brush, e.Bounds.Left + 3, e.Bounds.Top, new StringFormat { FormatFlags = StringFormatFlags.NoWrap });
            e.Graphics.DrawString(secondLine,
                new Font(FontFamily.GenericSansSerif, 8F, FontStyle.Regular), brush, e.Bounds.Left + 3, e.Bounds.Top + 20, new StringFormat { FormatFlags = StringFormatFlags.NoWrap });
        }

        public static bool CheckDate()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                WebRequest request = WebRequest.Create(DateApiPath);

                using (WebResponse response = request.GetResponse())
                {
                    if (((HttpWebResponse) response).StatusDescription == HttpStatusCode.OK.ToString())
                    {
                        var model = JsonHelper.Deserialize<DateTimeModel>(response.GetResponseStream());
                        return model.Allow;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }

            return false;
        }

        public static string CheckUserCount(DeviceModel model)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                WebRequest request = WebRequest.Create(DeviceApiPath);
                request.Method = "POST";

                string body = JsonHelper.Serialize(model);
                byte[] byteArray = Encoding.UTF8.GetBytes(body);

                request.ContentType = "application/json";
                request.ContentLength = byteArray.Length;

                using (Stream dataStream = request.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                }

                using (WebResponse response = request.GetResponse())
                {
                    if (((HttpWebResponse)response).StatusDescription == HttpStatusCode.OK.ToString())
                    {
                        var responseData = JsonHelper.Deserialize<DeviceModel>(response.GetResponseStream());
                        return responseData.Serial;
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }

            return null;
        }
    }
}