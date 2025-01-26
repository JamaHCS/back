using Domain.DTO.Users;
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

        [HttpGet("")]
        [Authorize(Policy = "getUser")]
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await _userService.GetAllUsersAsync();

            return StatusCode(result.Status, result);
        }

        [HttpGet("{userId}")]
        [Authorize(Policy = "getUser")]
        public async Task<IActionResult> Get(Guid userId)
        {
            var result = await _userService.GetById(userId);

            return StatusCode(result.Status, result);
        }

        [HttpPut("roles/{userId}")]
        [Authorize(Policy = "putUserRoles")]
        public async Task<IActionResult> PutUserRoles(Guid userId, PutUserRolesDTO roles)
        {
            var result = await _userService.UpdateUserRolesAsync(userId, roles.roles);

            return StatusCode(result.Status, result);
        }
    }
}
