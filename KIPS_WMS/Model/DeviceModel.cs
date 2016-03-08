namespace KIPS_WMS.Model
{
    public class DeviceModel
    {
        public string Serial { get; set; }

        public DeviceModel()
        {
        }

        public DeviceModel(string serial)
        {
            Serial = serial;
        }
    }
}