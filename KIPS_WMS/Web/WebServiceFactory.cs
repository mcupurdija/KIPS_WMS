using KIPS_WMS.NAV_WS;
using System.Net;
using System.IO;
using System;

namespace KIPS_WMS.Web
{
    static class WebServiceFactory
    {
        public static MobileWMSSync WebService;

        static WebServiceFactory()
        {
            string file = Utils.GetCurrentDirectory() + "\\DATA\\config.txt";
            if (File.Exists(file))
            {
                try
                {
                    StreamReader sr = new StreamReader(file);
                    string text = sr.ReadToEnd();
                    string[] lines = text.Split(new Char[] { '\n', '\r' });

                    string _username = "";
                    string _password = "";
                    string _domain = "";
                    foreach (string line in lines)
                    {
                        if (line.StartsWith("username"))
                        {
                            _username = line.Substring(line.IndexOf('=') + 1);
                        }
                        if (line.StartsWith("password"))
                        {
                            _password = line.Substring(line.IndexOf('=') + 1);
                        }
                        if (line.StartsWith("domain"))
                        {
                            _domain = line.Substring(line.IndexOf('=') + 1);
                        }
                    }

                    NetworkCredential KipsCredentials = new NetworkCredential(_username, _password, _domain);

                    WebService = new MobileWMSSync { Url = Utils.KipsNavWsUrlTest2016, Credentials = KipsCredentials, PreAuthenticate = true };
                }
                catch (Exception e)
                {
                    Utils.GeneralExceptionProcessing(e);
                }
            }
            else
            {
                Utils.GeneralExceptionProcessing(new Exception("Nije pronađen konfiguracioni fajl."));
            }
        }

        public static MobileWMSSync GetWebService()
        {
            return WebService;
        }
    }
}