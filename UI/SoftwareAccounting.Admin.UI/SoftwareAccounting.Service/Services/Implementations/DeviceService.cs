using SoftwareAccounting.Common.Models;
using SoftwareAccounting.Service.Services.ApiClient;
using SoftwareAccounting.Service.Services.Interfaces;
using System.Net;

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

        public async Task<bool> StartDeviceScan()
        {
            var response = await _apiClient.StartDevicesScan();
            if (response.IsSuccessStatusCode)
            {
                return response.Content;
            }

            return false;
        }

        public async Task<bool> StartDeviceScan(string ipAddress)
        {
            var response = await _apiClient.StartDeviceScan(ipAddress);
            if (response.IsSuccessStatusCode)
            {
                return response.Content;
            }

            return false;
        }

        public async Task<string> GetWebUrlForQrCode(string deviceId)
        {
            var response = await _apiClient.GetWebUIUrlForQr(deviceId);
            if (response.IsSuccessStatusCode)
            {
                return response.Content;
            }

            return "";
        }
    }
}
