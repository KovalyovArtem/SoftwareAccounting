using SoftwareAccounting.Common.Models.IntegrationModels;

namespace SoftwareAccounting.Service.Services.Interfaces
{
    public interface IIntegrationDeviceService
    {
        Task<bool> CheckRequestDeviceInfo(DeviceSettingsModel model);

        Task<bool> SetDeviceDeactivateStatus(string ipAddress, string macAddress, string synonym);

        Task<bool> StartDeviceScan();

        Task<bool> StartDeviceScan(string ipAddress);
    }
}
