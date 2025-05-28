using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SoftwareAccounting.Application.Models.Requests;
using SoftwareAccounting.Common.Models;
using SoftwareAccounting.Service.Services.Interfaces;

namespace SoftwareAccounting.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class DeviceController : ControllerBase
    {
        private readonly ILogger<DeviceController> _logger;
        private readonly IOptions<AppSettings> _settings;

        private readonly IDeviceService _deviceService;

        public DeviceController(
            ILogger<DeviceController> logger,
            IOptions<AppSettings> settings,
            IDeviceService deviceService)
        {
            _logger = logger;
            _settings = settings;

            _deviceService = deviceService;
        }

        [HttpGet("GetAllDevices")]
        public async Task<IActionResult> GetAllDevices()
        {
            try
            {
                var devices = await _deviceService.GetDevicesInfo();
                return Ok(devices);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetSoftwareInfo")]
        public async Task<IActionResult> GetSoftwareInfo([FromQuery] string deviceId)
        {
            try
            {
                var devices = await _deviceService.GetSoftwareDeviceInfo(deviceId);
                return Ok(devices);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
