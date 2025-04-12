using Refit;
using SoftwareAccounting.Common.Models.RequestModels;

namespace SoftwareAccounting.Library.Services.ApiClients
{
    public interface ISoftwareAccountingApiClient
    {
        [Post("/DeviceInfo/SetDeviceActivateStatus")]
        Task<bool> SetDeviceActivateStatus([Body]DeviceRequestModel model);
    }
}
