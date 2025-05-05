using SoftwareAccounting.Common.Models;
using SoftwareAccounting.Service.Services.ApiClient;
using SoftwareAccounting.Service.Services.Interfaces;

namespace SoftwareAccounting.Service.Services.Implementations
{
    public class DeviceService : IDeviceService
    {
        private readonly ISoftwareAccountingApiClient _apiClient;

        public DeviceService(
            ISoftwareAccountingApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<List<DeviceInfoModel>> GetDevices()
        {
            var response = await _apiClient.GetAllDevices();
            if (response.IsSuccessStatusCode)
            {
                return response.Content;
            }

            return null;
        }

        public async Task<List<SoftwareInfoModel>> GetDeviceSoftwareInfo(string deviceId)
        {
            var response = await _apiClient.GetSoftwareInfo(deviceId);
            if (response.IsSuccessStatusCode)
            {
                return response.Content;
            }

            return null;
        }
    }
}
