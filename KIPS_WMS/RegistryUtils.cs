using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Windows.Forms;
using KIPS_WMS.Data;
using KIPS_WMS.Model;
using KIPS_WMS.Properties;
using Microsoft.Win32;

namespace KIPS_WMS
{
    public static class RegistryUtils
    {
        public const string LastUsernameKey = "last_username";
        public const string LoginDataRegistryKey = "login_data";
        public const string PrinterRegistryKey = "printer";
        public const string SavedQuoteHeaderKey = "quote_header";
        public const string SavedQuoteLinesKey = "quote_lines";

        public static string GetLastUsername()
        {
            try
            {
                RegistryKey key = Registry.LocalMachine.OpenSubKey("Software", true).OpenSubKey(GetAppName(), false);
                return (string) key.GetValue(LastUsernameKey);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static void SaveLastUsername(string username)
        {
            try
            {
                RegistryKey key = Registry.LocalMachine.OpenSubKey("Software", true);
                key.CreateSubKey(GetAppName());
                key = key.OpenSubKey(GetAppName(), true);
                key.SetValue(LastUsernameKey, username);
            }
            catch (Exception)
            {
            }
        }

        public static LoginModel GetLoginData()
        {
            try
            {
                RegistryKey key = Registry.LocalMachine.OpenSubKey("Software", true).OpenSubKey(GetAppName(), false);
                var lines = (string) key.GetValue(LoginDataRegistryKey);
                return JsonHelper.Deserialize<LoginModel>(lines);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static void SaveLoginData(LoginModel loginModel)
        {
            try
            {
                RegistryKey key = Registry.LocalMachine.OpenSubKey("Software", true);
                key.CreateSubKey(GetAppName());
                key = key.OpenSubKey(GetAppName(), true);
                key.SetValue(LoginDataRegistryKey, JsonHelper.Serialize(loginModel));
            }
            catch (Exception)
            {
            }
        }

        public static void DeleteLoginData()
        {
            try
            {
                Registry.LocalMachine.OpenSubKey("Software", true)
                    .OpenSubKey(GetAppName(), true)
                    .DeleteValue(LoginDataRegistryKey, false);
            }
            catch (Exception)
            {
            }
        }

        public static string GetPrinterName()
        {
            try
            {
                RegistryKey key = Registry.LocalMachine.OpenSubKey("Software", true).OpenSubKey(GetAppName(), false);
                return (string) key.GetValue(PrinterRegistryKey);
            }
            catch (Exception)
            {
                return "";
            }
        }

        public static void SavePrinterName(string printerName)
        {
            try
            {
                RegistryKey key = Registry.LocalMachine.OpenSubKey("Software", true);
                key.CreateSubKey(GetAppName());
                key = key.OpenSubKey(GetAppName(), true);
                key.SetValue(PrinterRegistryKey, printerName);
            }
            catch (Exception)
            {
                MessageBox.Show(Resources.PodesavanjaNisuSacuvana, Resources.Greska);
            }
        }

        public static QuoteHeaderHelper GetQuoteHeader()
        {
            try
            {
                var quoteHeader =
                    (string) SQLiteHelper.simpleQuery(DbStatements.GetQuoteHeaderStatement, new object[] {});
                return JsonHelper.Deserialize<QuoteHeaderHelper>(quoteHeader);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static void SaveQuoteData(QuoteHeaderHelper quoteHeader, List<ItemQuoteModel> quoteLines)
        {
            try
            {
                SQLiteHelper.nonQuery(DbStatements.UpdateQuoteDataStatement,
                    new object[] {JsonHelper.Serialize(quoteHeader), JsonHelper.Serialize(quoteLines)});
            }
            catch (Exception)
            {
            }
        }

        public static List<ItemQuoteModel> GetQuoteLines()
        {
            try
            {
                var quoteLines = (string) SQLiteHelper.simpleQuery(DbStatements.GetQuoteLinesStatement, new object[] {});
                return JsonHelper.Deserialize<List<ItemQuoteModel>>(quoteLines);
            }
            catch (Exception)
            {
                return new List<ItemQuoteModel>();
            }
        }

        public static void DeleteSavedQuoteData()
        {
            try
            {
                SQLiteHelper.nonQuery(DbStatements.UpdateQuoteDataStatement,
                    new object[] {null, null});
            }
            catch (Exception)
            {
            }
        }

        public static string GetAppName()
        {
            return Assembly.GetExecutingAssembly().GetName().Name;
        }

        public static string GetAppVersion()
        {
            return Assembly.GetExecutingAssembly().GetName().Version.Revision.ToString(CultureInfo.InvariantCulture);
        }
    }

    public class QuoteHeaderHelper
    {
        public QuoteHeaderHelper(string documentNo, string customerCode, string customerName, int isAuthenticated)
        {
            DocumentNo = documentNo;
            CustomerCode = customerCode;
            CustomerName = customerName;
            IsAuthenticated = isAuthenticated;
        }

        public string DocumentNo { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public int IsAuthenticated { get; set; }
    }
}