using SoftwareAccounting.Common.Models;

namespace SoftwareAccounting.Service.Services.Interfaces
{
    public interface IDeviceService
    {
        Task<List<DeviceInfoModel>> GetDevices();

        Task<List<SoftwareInfoModel>> GetDeviceSoftwareInfo(string deviceId);
    }
}
