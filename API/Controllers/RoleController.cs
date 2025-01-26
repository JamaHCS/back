using Domain.DTO.Roles;
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

        [HttpGet("")]
        [Authorize(Policy = "getRoles")]
        public async Task<IActionResult> GetAllRoles()
        {
            var result = await _roleService.GetAllRolesAsync();

            return StatusCode(result.Status, result);
        }

        [HttpPut("{roleId}")]
        [Authorize(Policy = "putRoles")]
        public async Task<IActionResult> UpdateRole(Guid roleId, [FromBody] UpdateRoleDTO updateRoleDto)
        {
            var result = await _roleService.UpdateRoleAsync(roleId, updateRoleDto);

            return StatusCode(result.Status, result);
        }

        [HttpGet("by-user/{userId}")]
        [Authorize(Policy = "getRoles")]
        public async Task<IActionResult> GetRolesByUser(Guid userId)
        {
            var result = await _roleService.GetRolesAndPermissions(userId);

            return StatusCode(result.Status, result);
        }

        [HttpPost("")]
        [Authorize(Policy = "postRoles")]
        public async Task<IActionResult> CreateRole(CreateRoleDTO role)
        {
            var result = await _roleService.CreateRoleAsync(role);

            return StatusCode(result.Status, result);
        }

        [HttpPut("{roleId}/permissions")]
        [Authorize(Policy = "putRoles")]
        public async Task<IActionResult> UpdateRolePermissions(Guid roleId, [FromBody] UpdatePermissionsOnRoleDTO permissionIds)
        {
            var result = await _roleService.UpdateRolePermissionsAsync(roleId, permissionIds.Permissions);

            return StatusCode(result.Status, result);
        }

        [HttpDelete("{roleId}")]
        [Authorize(Policy = "deleteRoles")]
        public async Task<IActionResult> DeleteRole(Guid roleId)
        {
            var result = await _roleService.DeleteRoleAsync(roleId);

            return StatusCode(result.Status, result);
        }
    }
}
