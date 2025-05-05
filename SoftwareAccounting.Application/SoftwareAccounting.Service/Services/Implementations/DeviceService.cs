using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SoftwareAccounting.Common.Models;
using SoftwareAccounting.Common.Models.IntegrationModels;
using SoftwareAccounting.Domain.Models;
using SoftwareAccounting.Domain.Repositories.Interfaces;
using SoftwareAccounting.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareAccounting.Service.Services.Implementations
{
    public class DeviceService : IDeviceService
    {
        private readonly ILogger<DeviceService> _logger;
        private readonly IOptions<AppSettings> _settings;

        private readonly IDevicesRepository _devicesRepository;

        public DeviceService(
            ILogger<DeviceService> logger,
            IOptions<AppSettings> settings,
            IDevicesRepository devicesRepository)
        {
            _logger = logger;
            _settings = settings;
            _devicesRepository = devicesRepository;
        }

        public async Task<List<DeviceSettingsInfoModel>> GetDevicesInfo()
        {
            var devices = await _devicesRepository.GetDevicesAsync();
            return devices;
        }

        public async Task<List<SoftwareInfoModel>> GetSoftwareDeviceInfo(string deviceId)
        {
            var deviceSoftware = await _devicesRepository.GetSoftwareDeviceInfoAsync(Guid.Parse(deviceId));
            return deviceSoftware;
        }
    }
}
