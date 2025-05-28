using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SoftwareAccounting.Common.Models;
using SoftwareAccounting.Common.Models.IntegrationModels;
using SoftwareAccounting.Domain.Repositories.Interfaces;
using SoftwareAccounting.Service.Services.Interfaces;

namespace SoftwareAccounting.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IntegrationDeviceController : ControllerBase
    {
        private readonly ILogger<IntegrationDeviceController> _logger;
        private readonly IOptions<AppSettings> _settings;
        
        private readonly IIntegrationDeviceService _integrationDeviceService;

        public IntegrationDeviceController(
            ILogger<IntegrationDeviceController> logger,
            IOptions<AppSettings> settings,
            IIntegrationDeviceService integrationDeviceService)
        {
            _logger = logger;
            _settings = settings;

            _integrationDeviceService = integrationDeviceService;
        }

        [HttpPatch("SetDeviceActivateStatus")]
        public async Task<IActionResult> SetDeviceActivateStatus(DeviceSettingsModel model)
        {
            var remoteIp = HttpContext.Connection.RemoteIpAddress;
            if (remoteIp?.IsIPv4MappedToIPv6 == true)
            {
                remoteIp = remoteIp.MapToIPv4();
            }
            model.DeviceIpAddress = remoteIp?.ToString();

            model.DeviceIpAddress = HttpContext.Connection.RemoteIpAddress?.ToString();// HttpContext.Request.Headers["X-Forwarded-For"].FirstOrDefault();

            var res = await _integrationDeviceService.CheckRequestDeviceInfo(model);
            return Ok(res);
        }

        [HttpPatch("SetDeviceDeactivateStatus")]
        public async Task<IActionResult> SetDeviceDeactivateStatus(DeviceDeactivateModel model)
        {
            var remoteIp = HttpContext.Connection.RemoteIpAddress;
            if (remoteIp?.IsIPv4MappedToIPv6 == true)
            {
                remoteIp = remoteIp.MapToIPv4();
            }
            model.DeviceIpAddress = remoteIp?.ToString();

            //model.DeviceIpAddress = HttpContext.Connection.RemoteIpAddress?.ToString();// HttpContext.Request.Headers["X-Forwarded-For"].FirstOrDefault();

            var res = await _integrationDeviceService.SetDeviceDeactivateStatus(model.DeviceIpAddress, model.MacAdress, model.Synonym);
            return Ok(res);
        }

        [HttpGet("ProcessingDevicesScan")]
        public async Task<IActionResult> ProcessingDeviceScan()
        {
            var res = await _integrationDeviceService.StartDeviceScan();
            return Ok(res);
        }

        [HttpGet("ProcessingDeviceScan")]
        public async Task<IActionResult> ProcessingDeviceScan([FromQuery]string ipAddress)
        {
            var res = await _integrationDeviceService.StartDeviceScan(ipAddress);
            return Ok(res);
        }

        [HttpGet("ProcessingDeviceByIdScan")]
        public async Task<IActionResult> ProcessingDeviceByIdScan([FromQuery] string deviceId)
        {
            var res = await _integrationDeviceService.StartDeviceScanById(Guid.Parse(deviceId));
            return Ok(res);
        }
    }
}
