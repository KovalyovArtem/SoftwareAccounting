using SoftwareAccounting.Domain.Models;

namespace SoftwareAccounting.Domain.Repositories.Interfaces
{
    public interface IDevicesRepository
    {
        Task<List<DeviceInfoModel>> GetDevicesAsync();

        Task<DeviceExtensionInfoModel> GetDeviceInfoAsync(Guid id);
    }
}
