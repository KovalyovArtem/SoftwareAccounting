using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SoftwareAccounting.Common.Models;
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

        public SoftwareAccountingController(ILogger<SoftwareAccountingController> logger,
                                            IOptions<AppSettings> appSettings)
        {
            _logger = logger;
            _appSettings = appSettings;
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

            return Ok();
        }
    }
}
