using PKRTravelsWebApp.Models;

namespace PKRTravelsWebApp.Services
{
    public interface IBusInfoService
    {
        public List<BusInfo> GetBusInfoList();
        public string InsertBusInfo(BusInfo busInfo);
    }
}
