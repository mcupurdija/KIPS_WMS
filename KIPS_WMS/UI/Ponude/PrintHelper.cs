using System;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using KIPS_WMS.Model;

namespace KIPS_WMS.UI.Ponude
{
    public static class PrintHelper
    {
        public static void Print(PrintHeaderModel model)
        {
            if (model.PrinterName.Length == 0)
            {
                MessageBox.Show("Potrebno je da u okviru podešavanja odaberete štampač.", "Greška");
                return;
            }

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                WebRequest request = WebRequest.Create(Utils.PrintServerApiPath);
                request.Method = "POST";

                string testData = JsonHelper.Serialize(model);
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
                MessageBox.Show(ex.Message, "Greška");
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
    }
}
