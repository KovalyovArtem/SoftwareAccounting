using Refit;
using SoftwareAccounting.Common.Models;

namespace SoftwareAccounting.Service.Services.ApiClient
{
    public interface ISoftwareAccountingApiClient
    {
        [Get("/Device/GetAllDevices")]
        Task<ApiResponse<List<DeviceInfoModel>>> GetAllDevices();

        [Get("/Device/GetSoftwareInfo")]
        Task<ApiResponse<List<SoftwareInfoModel>>> GetSoftwareInfo(string deviceId);
    }
}
