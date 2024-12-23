using Domain.DTO.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        [Authorize(Policy = "createUser")]
        public async Task<IActionResult> Register([FromBody]RegisterDTO request)
        {
            var result = await _authService.Register(request);

            return StatusCode(result.Status, result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO request)
        {
            var result = await _authService.Login(request);

            return StatusCode(result.Status, result);
        }

    }
}
