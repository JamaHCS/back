using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace API.Controllers
{
    [Route("api/permissions")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionService _permissionService;

        public PermissionController(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        [HttpGet("")]
        [Authorize(Policy = "readPermissions")]
        public async Task<IActionResult> Get()
        {
            var result = await _permissionService.GetAllPermissionsAsync();

            return StatusCode(result.Status, result);
        }
    }
}
