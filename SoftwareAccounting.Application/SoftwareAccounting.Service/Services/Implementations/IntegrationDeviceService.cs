using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SoftwareAccounting.Common.Models;
using SoftwareAccounting.Common.Models.IntegrationModels;
using SoftwareAccounting.Domain.Repositories.Interfaces;
using SoftwareAccounting.Service.Services.ApiClientServices;
using SoftwareAccounting.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareAccounting.Service.Services.Implementations
{
    public class IntegrationDeviceService : IIntegrationDeviceService
    {
        private readonly ILogger<IntegrationDeviceService> _logger;
        private readonly IOptions<AppSettings> _settings;

        private readonly IIntegrationDeviceRepository _integrationDeviceRepository;
        private readonly IDevicesRepository _devicesRepository;

        private readonly IAccountingApiClientFactory _clientFactory;

        public IntegrationDeviceService(
            ILogger<IntegrationDeviceService> logger,
            IOptions<AppSettings> settings,
            IIntegrationDeviceRepository integrationDeviceRepository,
            IDevicesRepository devicesRepository,
            IAccountingApiClientFactory clientFactory)
        {
            _logger = logger;
            _settings = settings;

            _integrationDeviceRepository = integrationDeviceRepository;
            _devicesRepository = devicesRepository;
            
            _clientFactory = clientFactory;
        }

        public async Task<bool> CheckRequestDeviceInfo(DeviceSettingsModel model)
        {
            if(string.IsNullOrEmpty(model.DeviceIpAddress))
                return false;

            var res = await _integrationDeviceRepository.RegisterDevice(model);
            return res;
        }

        public async Task<bool> SetDeviceDeactivateStatus(string ipAddress, string macAddress, string synonym)
        {
            if (string.IsNullOrEmpty(ipAddress))
                return false;

            var res = await _integrationDeviceRepository.SetDeviceStatus(ipAddress, macAddress, synonym, false);
            return res;
        }

        public async Task<bool> StartDeviceScan()
        {
            var hostUrls = await _integrationDeviceRepository.GetAllActiveDeviceIp();

            var deviceInfoList = new Dictionary<string, DeviceInfoModel>();

            bool result = false;

            CancellationToken ct = default;
            await Parallel.ForEachAsync(hostUrls, new ParallelOptions
            {
                MaxDegreeOfParallelism = _settings.Value.MaxScanningPool,
                CancellationToken = ct
            }, async (hostUrl, cancellationToken) =>
            {
                try
                {
                    var client = _clientFactory.CreateClient("http://" + hostUrl + ":15080");
                    var result = await client.GetDeviceInfo();
                    if (result.IsSuccessful && result.Content != null)
                    {
                        deviceInfoList.Add(hostUrl, result.Content);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Ошибка при запросе к {Host}", hostUrl);
                }
            });

            foreach (var device in deviceInfoList)
            {
                var deviceId = await _integrationDeviceRepository.GetDeviceIdByIpAddress(device.Key);

                await _integrationDeviceRepository.ClearDeviceInfotables(deviceId);

                foreach (var software in device.Value.SoftwareInfoList)
                {
                    result = await _integrationDeviceRepository.InsertSoftwareDeviceInfo(deviceId, software);
                    if (result == false)
                    {
                        _logger.LogError($"Failed to insert software {deviceId}, {software}");
                        continue;
                    }
                }

                foreach (var hardware in device.Value.HarwareInfoList)
                {
                    result = await _integrationDeviceRepository.InsertHardwareDeviceInfo(deviceId, hardware);
                    if (result == false)
                    {
                        _logger.LogError($"Failed to insert software {deviceId}, {hardware}");
                        continue;
                    }
                }
            }

            return result;
        }

        public async Task<bool> StartDeviceScan(string ipAddress)
        {
            var deviceInfo = new DeviceInfoModel();
            bool result = false;

            try
            {
                var client = _clientFactory.CreateClient("http://" + ipAddress + ":15080");
                var response = await client.GetDeviceInfo();
                if (response.IsSuccessful && response.Content != null)
                {
                    deviceInfo = response.Content;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при запросе к {Host}", ipAddress);
            }

            var deviceId = await _integrationDeviceRepository.GetDeviceIdByIpAddress(ipAddress);

            await _integrationDeviceRepository.ClearDeviceInfotables(deviceId);

            foreach (var software in deviceInfo.SoftwareInfoList)
            {
                result = await _integrationDeviceRepository.InsertSoftwareDeviceInfo(deviceId, software);
                if (result == false)
                {
                    _logger.LogError($"Failed to insert software {deviceId}, {software}");
                    continue;
                }
            }

            foreach (var hardware in deviceInfo.HarwareInfoList)
            {
                result = await _integrationDeviceRepository.InsertHardwareDeviceInfo(deviceId, hardware);
                if (result == false)
                {
                    _logger.LogError($"Failed to insert software {deviceId}, {hardware}");
                    continue;
                }
            }

            return result;
        }

        public async Task<bool> StartDeviceScanById(Guid deviceId)
        {
            var deviceInfo = new DeviceInfoModel();
            bool result = false;

            var ipAddress = await _devicesRepository.GetDeviceIpAddressByIdAsync(deviceId);
            if(string.IsNullOrEmpty(ipAddress))
            {
                _logger.LogError("Не удалось найти id устройста {0}", deviceId);
                return false;
            }

            try
            {
                var client = _clientFactory.CreateClient("http://" + ipAddress + ":15080");
                var response = await client.GetDeviceInfo();
                if (response.IsSuccessful && response.Content != null)
                {
                    deviceInfo = response.Content;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при запросе к {Host}", ipAddress);
            }

            if(deviceInfo == null)
                return false;

            await _integrationDeviceRepository.ClearDeviceInfotables(deviceId);

            foreach (var software in deviceInfo.SoftwareInfoList)
            {
                result = await _integrationDeviceRepository.InsertSoftwareDeviceInfo(deviceId, software);
                if (result == false)
                {
                    _logger.LogError($"Failed to insert software {deviceId}, {software}");
                    continue;
                }
            }

            foreach (var hardware in deviceInfo.HarwareInfoList)
            {
                result = await _integrationDeviceRepository.InsertHardwareDeviceInfo(deviceId, hardware);
                if (result == false)
                {
                    _logger.LogError($"Failed to insert software {deviceId}, {hardware}");
                    continue;
                }
            }

            return result;
        }
    }
}
