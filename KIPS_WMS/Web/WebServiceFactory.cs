using KIPS_WMS.NAV_WS;

namespace KIPS_WMS.Web
{
    static class WebServiceFactory
    {
        public static KIPS_wms WebService;

        static WebServiceFactory()
        {
            WebService = new KIPS_wms { Credentials = Utils.GoProCredentials, PreAuthenticate = true };
        }

        public static KIPS_wms GetWebService()
        {
            return WebService;
        }
    }
}