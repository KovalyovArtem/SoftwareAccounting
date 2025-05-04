using Refit;
using SoftwareAccounting.Common.Models.IntegrationModels;

namespace SoftwareAccounting.Service.Services.ApiClientServices
{
    public interface IAccountingApiClient
    {
        [Get("/SoftwareAccounting/GetDeviceInfo")]
        Task<ApiResponse<DeviceInfoModel>> GetDeviceInfo();
    }
}
