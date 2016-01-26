using System;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using KIPS_WMS.Properties;

namespace KIPS_WMS.UI.Ostalo
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();

            tbSavedPrinter.Text = RegistryUtils.GetPrinterName();
            GetAvailablePrinters();
        }

        public void GetAvailablePrinters()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                WebRequest request = WebRequest.Create(Utils.PrintServerApiPath);

                string[] printers;
                using (WebResponse response = request.GetResponse())
                {
                    printers = JsonHelper.Deserialize<string[]>(response.GetResponseStream());
                }

                foreach (string printer in printers)
                {
                    cbPrinters.Items.Add(printer);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Resources.Greska);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void cbPrinters_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbSavedPrinter.Text = cbPrinters.SelectedItem.ToString();
        }

        

        public void TestPrinter()
        {
            if (tbSavedPrinter.Text.Length == 0)
            {
                MessageBox.Show(Resources.OdaberiteStampac, Resources.Greska);
                return;
            }

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                WebRequest request = WebRequest.Create(Utils.PrintServerApiTestPath);
                request.Method = "POST";

                string testData = JsonHelper.Serialize(new TestData(tbSavedPrinter.Text, tbTest.Text));
                byte[] byteArray = Encoding.UTF8.GetBytes(testData);

                request.ContentType = "application/json";
                request.ContentLength = byteArray.Length;

                using (Stream dataStream = request.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                }

                request.GetResponse();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Resources.Greska);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void bShort_Click(object sender, EventArgs e)
        {
            TestPrinter();
        }

        private void bSacuvaj_Click(object sender, EventArgs e)
        {
            if (tbSavedPrinter.Text.Length > 0)
            {
                RegistryUtils.SavePrinterName(tbSavedPrinter.Text);
            }
            Close();
        }

//        public void TestPrint()
//        {
//            WebRequest request = WebRequest.Create("http://192.168.1.164/PrintingSrv/api/print");
//            request.Method = "POST";
//            string postData = "{name:'BUS PLUS'}";
//            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
//            request.ContentType = "application/json";
//            request.ContentLength = byteArray.Length;
//            Stream dataStream = request.GetRequestStream();
//            dataStream.Write(byteArray, 0, byteArray.Length);
//            dataStream.Close();
//            WebResponse response = request.GetResponse();
//            dataStream = response.GetResponseStream();
//            var reader = new StreamReader(dataStream);
//            string responseFromServer = reader.ReadToEnd();
//
//            reader.Close();
//            dataStream.Close();
//            response.Close();
//        }
    }

    public class TestData
    {
        public TestData(string printerName, string text)
        {
            PrinterName = printerName;
            Text = text;
        }

        public string PrinterName { get; set; }
        public string Text { get; set; }
    }
}