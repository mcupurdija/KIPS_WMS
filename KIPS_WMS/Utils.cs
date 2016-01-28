﻿using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net;
using System.Reflection;
using System.Web.Services.Protocols;
using System.Windows.Forms;
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

        public const string NavWsUrl = "http://sqlserver:7047/Wurth/ws/Wurth/Codeunit/KIPS_wms";
        public static NetworkCredential GoProCredentials = new NetworkCredential("wurthtest", "remote", "gopro");
        public static NetworkCredential KipsCredentials = new NetworkCredential("wurthtest", "remote", "gopro");

        private const string PrintServerAddress = "http://192.168.1.106/";
        public const string PrintServerApiPath = PrintServerAddress + "WMSPrintServer/api/Print";
        public const string PrintServerApiTestPath = PrintServerAddress + "WMSPrintServer/api/Test";



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
    }
}