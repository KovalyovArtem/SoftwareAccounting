using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SoftwareAccounting.Common.Models;
using SoftwareAccounting.Common.Models.DeviceInfo;
using SoftwareAccounting.Library.Services.DeviceScan.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareAccounting.Worker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SoftwareAccountingController : ControllerBase
    {
        private readonly ILogger<SoftwareAccountingController> _logger;
        private readonly IOptions<AppSettings> _appSettings;
        private readonly IDeviceScan _deviceScan;

        public SoftwareAccountingController(ILogger<SoftwareAccountingController> logger,
                                            IOptions<AppSettings> appSettings,
                                            IDeviceScan deviceScan)
        {
            _logger = logger;
            _appSettings = appSettings;
            _deviceScan = deviceScan;
        }

        [HttpGet]
        [Route("TestMethod")]
        public async Task<IActionResult> TestMethod(int number)
        {
            try
            {
                await Task.Delay(1000);

                if(number < 10)
                {
                    throw new ArgumentOutOfRangeException(nameof(number), number, "Число меньше десяти!!!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Запись была успешной");
        }

        [HttpGet]
        [Route("GetDeviceInfo")]
        public async Task<IActionResult> GetDeviceInfo()
        {
            var response = new DeviceInfoModel();

            try
            {
                var software = Task.Run(() => _deviceScan.DoScanSoftwareDevice());
                var hardware = Task.Run(() => _deviceScan.DoScanHarwareDevice());

                await Task.WhenAll(software, hardware);

                response = new DeviceInfoModel()
                {
                    SoftwareInfoList = software.Result,
                    HarwareInfoList = hardware.Result,
                };
            }
            catch (Exception ex)
            {
                return BadRequest(new DeviceInfoModel { ErrorMessage = ex.Message });
            }

            return Ok(response);
        }
    }
}
