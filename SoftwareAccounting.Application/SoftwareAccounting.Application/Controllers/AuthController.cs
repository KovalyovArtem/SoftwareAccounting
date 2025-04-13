using Microsoft.AspNetCore.Mvc;
using SoftwareAccounting.Application.Models.Requests;

namespace SoftwareAccounting.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpPost("regster")]
        public IActionResult Register([FromBody] RegisterUserRequest request)
        {
            return NoContent();
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] string userName, string password)
        {
            return Ok();
        }
    }
}
