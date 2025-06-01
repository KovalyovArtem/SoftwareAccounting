using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SoftwareAccounting.Common.Models;

namespace SoftwareAccounting.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class SettingsController : ControllerBase
    {
        private readonly ILogger<SettingsController> _logger;
        private readonly IOptions<AppSettings> _settings;

        public SettingsController(
            ILogger<SettingsController> logger,
            IOptions<AppSettings> settings)
        {
            _logger = logger;
            _settings = settings;
        }

        [HttpGet("GetWebUIUrlForQr")]
        public IActionResult GetWebUIUrlForQr([FromQuery] string deviceId)
        {
            var res = Path.Combine(_settings.Value.WebUIHostUrl, "device", deviceId); 
            return Ok(res);
        }
    }
}
