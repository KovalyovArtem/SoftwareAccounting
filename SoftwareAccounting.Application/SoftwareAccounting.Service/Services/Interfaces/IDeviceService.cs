using SoftwareAccounting.Domain.Models;

namespace SoftwareAccounting.Service.Services.Interfaces
{
    public interface IDeviceService
    {
        Task<List<DeviceInfoModel>> GetDevicesInfo();

        Task<DeviceExtensionInfoModel> GetDeviceInfo(Guid deviceId);
    }
}
