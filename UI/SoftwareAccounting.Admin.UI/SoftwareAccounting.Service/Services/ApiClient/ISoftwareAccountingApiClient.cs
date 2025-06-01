using Refit;
using SoftwareAccounting.Common.Models;
using SoftwareAccounting.Common.Models.AuthModel;
using SoftwareAccounting.Common.Models.Poeple;

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

        [Get("/People/GetAllUsers")]
        Task<ApiResponse<List<User>>> GetAllUsers();

        [Get("/People/GetAllEmployers")]
        Task<ApiResponse<List<Employer>>> GetAllEmployers();

        [Get("/Settings/GetWebUIUrlForQr")]
        Task<ApiResponse<string>> GetWebUIUrlForQr(string deviceId);
    }
}
