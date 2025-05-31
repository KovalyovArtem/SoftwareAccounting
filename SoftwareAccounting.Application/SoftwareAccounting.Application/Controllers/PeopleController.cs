using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SoftwareAccounting.Common.Models;
using SoftwareAccounting.Service.Services.Interfaces;

namespace SoftwareAccounting.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class PeopleController : ControllerBase
    {
        private readonly ILogger<PeopleController> _logger;
        private readonly IOptions<AppSettings> _settings;

        private readonly IPeopleService _peopleService;

        public PeopleController(
            ILogger<PeopleController> logger,
            IOptions<AppSettings> settings,
            IPeopleService peopleService)
        {
            _logger = logger;
            _settings = settings;

            _peopleService = peopleService;
        }

        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var res = await _peopleService.GetUsers();
            return Ok(res);
        }

        [HttpGet("GetAllEmployers")]
        public async Task<IActionResult> GetAllEmployers()
        {
            var res = await _peopleService.GetEmployers();
            return Ok(res);
        }
    }
}
