using SoftwareAccounting.Common.Models.IntegrationModels;
using SoftwareAccounting.Domain.Models;

namespace SoftwareAccounting.Domain.Repositories.Interfaces
{
    public interface IDevicesRepository
    {
        Task<List<DeviceSettingsInfoModel>> GetDevicesAsync();

        Task<List<SoftwareInfoModel>> GetSoftwareDeviceInfoAsync(Guid id);

        Task<string?> GetDeviceIpAddressByIdAsync(Guid deviceId);
    }
}
