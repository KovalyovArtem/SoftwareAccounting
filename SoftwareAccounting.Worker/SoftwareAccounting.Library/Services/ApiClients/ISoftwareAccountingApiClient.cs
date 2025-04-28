using Refit;
using SoftwareAccounting.Common.Models.RequestModels;

namespace SoftwareAccounting.Library.Services.ApiClients
{
    public interface ISoftwareAccountingApiClient
    {
        [Patch("/IntegrationDevice/SetDeviceActivateStatus")]
        Task<bool> SetDeviceActivateStatus([Body]DeviceRequestModel model);

        [Patch("/IntegrationDevice/SetDeviceDeactivateStatus")]
        Task SetDeviceDeactivateStatus([Body] DeviceDeactivateModel model);
    }
}
