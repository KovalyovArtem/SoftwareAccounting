using SoftwareAccounting.Common.Models.IntegrationModels;
using SoftwareAccounting.Domain.Models;

namespace SoftwareAccounting.Service.Services.Interfaces
{
    public interface IDeviceService
    {
        Task<List<DeviceSettingsInfoModel>> GetDevicesInfo();

        Task<List<SoftwareInfoModel>> GetSoftwareDeviceInfo(string deviceId);
    }
}
