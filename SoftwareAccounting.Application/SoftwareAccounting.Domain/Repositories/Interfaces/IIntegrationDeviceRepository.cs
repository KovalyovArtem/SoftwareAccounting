using SoftwareAccounting.Common.Models.IntegrationModels;

namespace SoftwareAccounting.Domain.Repositories.Interfaces
{
    public interface IIntegrationDeviceRepository
    {
        Task<bool> RegisterDevice(DeviceSettingsModel model);

        Task<bool> SetDeviceStatus(string ipAddress, string macAddress, string synonym, bool status);

        Task<List<string>> GetAllActiveDeviceIp();

        Task<Guid> GetDeviceIdByIpAddress(string ipAddress);

        Task<bool> InsertSoftwareDeviceInfo(Guid deviceId, SoftwareInfoModel model);

        Task<bool> InsertHardwareDeviceInfo(Guid deviceId, HarwareInfoModel model);

        Task<bool> ClearDeviceInfotables(Guid deviceId);
    }
}