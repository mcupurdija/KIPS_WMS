using KIPS_WMS.NAV_WS;

namespace KIPS_WMS.Web
{
    static class WebServiceFactory
    {
        public static MobileWMSSync WebService;

        static WebServiceFactory()
        {
            WebService = new MobileWMSSync { Url = Utils.KipsNavWsUrlTest, Credentials = Utils.KipsCredentials, PreAuthenticate = true };
        }

        public static MobileWMSSync GetWebService()
        {
            return WebService;
        }
    }
}