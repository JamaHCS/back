using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IUserService _userService;

        public UserController(IUserService userService) 
        {
            _userService = userService;
        }

        [HttpGet("{userId}")]
        [Authorize(Policy = "readUserById")]
        public async Task<IActionResult> Get(Guid userId)
        {
            var result = await _userService.GetById(userId);

            return StatusCode(result.Status, result);
        }
    }
}
