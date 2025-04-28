using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SoftwareAccounting.Common.Models;
using SoftwareAccounting.Common.Models.IntegrationModels;

namespace SoftwareAccounting.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IntegrationDeviceController : ControllerBase
    {
        private readonly ILogger<IntegrationDeviceController> _logger;
        private readonly IOptions<AppSettings> _settings;

        public IntegrationDeviceController(
            ILogger<IntegrationDeviceController> logger,
            IOptions<AppSettings> settings)
        {
            _logger = logger;
            _settings = settings;
        }

        [HttpPatch("SetDeviceActivateStatus")]
        public async Task<IActionResult> SetDeviceActivateStatus(DeviceSettingsModel model)
        {
            var p = model.DeviceDNS;
            return Ok(true);
        }

        [HttpPatch("SetDeviceDeactivateStatus")]
        public async Task<IActionResult> SetDeviceDeactivateStatus(DeviceDeactivateModel model)
        {
            return Ok();
        }
    }
}
