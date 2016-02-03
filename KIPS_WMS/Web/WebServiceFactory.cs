using KIPS_WMS.NAV_WS;

namespace KIPS_WMS.Web
{
    static class WebServiceFactory
    {
        public static MobileWMSSync WebService;

        static WebServiceFactory()
        {
            WebService = new MobileWMSSync { Url = Utils.GoProNavWsUrl, Credentials = Utils.GoProCredentials, PreAuthenticate = true };
        }

        public static MobileWMSSync GetWebService()
        {
            return WebService;
        }
    }
}