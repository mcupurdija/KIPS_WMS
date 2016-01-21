using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Windows.Forms;
using KIPS_WMS.Model;
using Microsoft.Win32;
using KIPS_WMS.Properties;

namespace KIPS_WMS
{
    public static class RegistryUtils
    {
        public const string PrinterRegistryKey = "printer";
        public const string SavedQuoteHeaderKey = "quote_header";
        public const string SavedQuoteLinesKey = "quote_lines";

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
                RegistryKey key = Registry.LocalMachine.OpenSubKey("Software", true).OpenSubKey(GetAppName(), false);
                var lines = (string) key.GetValue(SavedQuoteHeaderKey);
                return JsonHelper.Deserialize<QuoteHeaderHelper>(lines);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static void SaveQuoteHeader(QuoteHeaderHelper quoteHeader)
        {
            try
            {
                RegistryKey key = Registry.LocalMachine.OpenSubKey("Software", true);
                key.CreateSubKey(GetAppName());
                key = key.OpenSubKey(GetAppName(), true);
                key.SetValue(SavedQuoteHeaderKey, JsonHelper.Serialize(quoteHeader));
            }
            catch (Exception)
            {
            }
        }

        public static List<ItemQuoteModel> GetQuoteLines()
        {
            try
            {
                RegistryKey key = Registry.LocalMachine.OpenSubKey("Software", true).OpenSubKey(GetAppName(), false);
                var lines = (string) key.GetValue(SavedQuoteLinesKey);
                return JsonHelper.Deserialize<List<ItemQuoteModel>>(lines);
            }
            catch (Exception)
            {
                return new List<ItemQuoteModel>();
            }
        }

        public static void SaveQuoteLines(List<ItemQuoteModel> quoteLines)
        {
            try
            {
                RegistryKey key = Registry.LocalMachine.OpenSubKey("Software", true);
                key.CreateSubKey(GetAppName());
                key = key.OpenSubKey(GetAppName(), true);
                key.SetValue(SavedQuoteLinesKey, JsonHelper.Serialize(quoteLines));
            }
            catch (Exception)
            {
            }
        }

        public static void DeleteSavedQuoteData()
        {
            try
            {
                Registry.LocalMachine.OpenSubKey("Software", true)
                    .OpenSubKey(GetAppName(), true)
                    .DeleteValue(SavedQuoteHeaderKey, false);
                Registry.LocalMachine.OpenSubKey("Software", true)
                    .OpenSubKey(GetAppName(), true)
                    .DeleteValue(SavedQuoteLinesKey, false);
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