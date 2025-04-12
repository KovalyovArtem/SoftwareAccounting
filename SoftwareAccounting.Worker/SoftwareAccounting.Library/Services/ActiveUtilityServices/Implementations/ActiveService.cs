using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SoftwareAccounting.Common.Models;
using SoftwareAccounting.Common.Models.DeviceInfo;
using SoftwareAccounting.Common.Models.RequestModels;
using SoftwareAccounting.Library.Services.ActiveUtilityServices.Interfaces;
using SoftwareAccounting.Library.Services.ApiClients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareAccounting.Library.Services.ActiveUtilityServices.Implementations
{
    public class ActiveService : IActiveService
    {
        private readonly ILogger<ActiveService> _logger;
        private readonly IOptions<AppSettings> _appSettings;

        private readonly ISoftwareAccountingApiClient _apiClient;

        public ActiveService(ILogger<ActiveService> logger,
                             IOptions<AppSettings> appSettings,
                             ISoftwareAccountingApiClient apiClient)
        {
            logger = _logger;
            _appSettings = appSettings;
            _apiClient = apiClient;
        }

        public async Task<bool> SendInfoAboutDeviceIsActive(DeviceSettingsModel settings)
        {
            DeviceRequestModel request = new DeviceRequestModel()
            {
                DeviceOS = settings.DeviceOS,
                DevicLicense = settings.DevicLicense,
                DeviceDNS = settings.DeviceDNS,
                DeviceMacAddress = settings.DeviceMacAddress,
                DeviceName = settings.DeviceName,
                DeviceOSArchitecture = settings.DeviceOSArchitecture
            };

            var result = await _apiClient.SetDeviceActivateStatus(request);

            return result;
        }
    }
}