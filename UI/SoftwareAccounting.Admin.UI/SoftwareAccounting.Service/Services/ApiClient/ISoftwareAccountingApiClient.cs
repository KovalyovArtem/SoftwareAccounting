using Refit;
using SoftwareAccounting.Common.Models;
using SoftwareAccounting.Common.Models.AuthModel;

namespace SoftwareAccounting.Service.Services.ApiClient
{
    public interface ISoftwareAccountingApiClient
    {
        [Get("/Device/GetAllDevices")]
        Task<ApiResponse<List<DeviceInfoModel>>> GetAllDevices();

        [Get("/Device/GetSoftwareInfo")]
        Task<ApiResponse<List<SoftwareInfoModel>>> GetSoftwareInfo(string deviceId);

        [Get("/IntegrationDevice/ProcessingDevicesScan")]
        Task<ApiResponse<bool>> StartDevicesScan();

        [Get("/IntegrationDevice/ProcessingDeviceByIdScan")]
        Task<ApiResponse<bool>> StartDeviceScan(string deviceId);

        [Post("/Auth/Login")]
        Task<ApiResponse<string>> Login(RegisterUserRequest user);
    }
}
