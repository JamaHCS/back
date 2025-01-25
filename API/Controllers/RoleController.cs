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

        [HttpGet("{roleId}")]
        [Authorize(Policy = "getRoles")]
        public async Task<IActionResult> GetRole(Guid roleId)
        {
            var result = await _roleService.GetRoleAndPermissionsById(roleId);

            return StatusCode(result.Status, result);
        }

        [HttpGet("by-user/{userId}")]
        [Authorize(Policy = "getRoles")]
        public async Task<IActionResult> GetRolesByUser(Guid userId)
        {
            var result = await _roleService.GetRolesAndPermissions(userId);

            return StatusCode(result.Status, result);
        }

        [HttpPut("{roleId}/permissions")]
        [Authorize(Policy = "putRoles")]
        public async Task<IActionResult> UpdateRolePermissions(Guid roleId, [FromBody] IEnumerable<Guid> permissionIds)
        {
            var result = await _roleService.UpdateRolePermissionsAsync(roleId, permissionIds);

            return StatusCode(result.Status, result);
        }
    }
}
