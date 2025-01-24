using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace API.Controllers
{
    [Route("api/roles")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet("by-user/{userId}")]
        [Authorize(Policy = "getRolesByUser")]
        public async Task<IActionResult> GetRolesByUser(Guid userId)
        {
            var result = await _roleService.GetRolesAndPermissions(userId);

            return StatusCode(result.Status, result);
        }
    }
}
