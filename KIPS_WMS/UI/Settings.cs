using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Xml;
using System.IO;
using Microsoft.Win32;

namespace KIPS_WMS.UI
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();

            tbPrint.Text = GetPrinterFromRegistry();

            string printers = GetAvailablePrinters();
            printers = printers.Substring(1, printers.Length - 2);
            printers = printers.Replace("\"", "");
            string[] niz = printers.Split(',');
            cbPrinters.Items.Clear();
            foreach (string a in niz)
            {
                cbPrinters.Items.Add(a);
            }

        }

        private void cbPrinters_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbPrint.Text = cbPrinters.SelectedItem.ToString();
        }

        private void bStampac_Click(object sender, EventArgs e)
        {
            if (!tbPrint.Text.Equals(""))
            {
                SetPrinterInRegistry(tbPrint.Text);
            }
        }

        public string GetAvailablePrinters()
        {
            WebRequest request = WebRequest.Create("http://192.168.1.164/PrintingSrv/api/print");
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            reader.Close();
            response.Close();
            return responseFromServer;
        }

        public void SetPrinterInRegistry(string printerName)
        {
            RegistryKey key = Registry.LocalMachine.OpenSubKey("Software", true);
            key.CreateSubKey("KIPS");
            key = key.OpenSubKey("KIPS", true);
            key.CreateSubKey("0.5");
            key = key.OpenSubKey("0.5", true);
            key.SetValue("stampac", printerName);
        }

        public string GetPrinterFromRegistry()
        {
            try
            {
                RegistryKey key =
                    Registry.LocalMachine.OpenSubKey("Software", true)
                        .OpenSubKey("KIPS", false)
                        .OpenSubKey("0.5", false);
                return (string)key.GetValue("stampac");
            }
            catch (Exception)
            {
                return "";
            }
        }

        public void TestPrint()
        {
            WebRequest request = WebRequest.Create("http://192.168.1.164/PrintingSrv/api/print");
            request.Method = "POST";
            string postData = "{name:'BUS PLUS'}";
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            request.ContentType = "application/json";
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            WebResponse response = request.GetResponse();
            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();

            reader.Close();
            dataStream.Close();
            response.Close();
        }
        public void TestShort()
        {
            WebRequest request = WebRequest.Create("http://192.168.1.164/PrintingSrv/api/print");
            request.Method = "POST";
            string postData = "{name:'short'}";
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            request.ContentType = "application/json";
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            WebResponse response = request.GetResponse();
            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();

            reader.Close();
            dataStream.Close();
            response.Close();
        }
        public void TestLong()
        {
            WebRequest request = WebRequest.Create("http://192.168.1.164/PrintingSrv/api/print");
            request.Method = "POST";
            string postData = "{name:'long'}";
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            request.ContentType = "application/json";
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            WebResponse response = request.GetResponse();
            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();

            reader.Close();
            dataStream.Close();
            response.Close();
        }

        private void bShort_Click(object sender, EventArgs e)
        {
            TestShort();
        }

        private void bLong_Click(object sender, EventArgs e)
        {
            TestLong();
        }


    }
}