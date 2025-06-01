using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SoftwareAccounting.Application.Models.Requests;
using SoftwareAccounting.Common.Models;
using SoftwareAccounting.Service.Services.Interfaces;
using System.Threading.Tasks;

namespace SoftwareAccounting.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IOptions<AppSettings> _settings;

        private readonly IAccountService _accountService;

        public AuthController(ILogger<AuthController> logger,
                              IOptions<AppSettings> settings,
                              IAccountService accountService)
        {
            _logger = logger;
            _settings = settings;
            _accountService = accountService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserRequest request)
        {
            var res = await _accountService.Register(request.UserName, request.Password);

            return Ok(res);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] RegisterUserRequest request)
        {
            var token = await _accountService.Login(request.UserName, request.Password);

            HttpContext.Response.Cookies.Append("tasty-cookies", token);

            return Ok(token);
        }
    }
}
