using System.Security.Claims;
using Domain.Entities.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repository.Context;

namespace API.Authorization
{
    public class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public PermissionAuthorizationHandler(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        {
            var userIdClaim = context.User.FindFirst(ClaimTypes.NameIdentifier);

            if (userIdClaim == null) return;

            var userId = Guid.Parse(userIdClaim.Value);
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null) return;

            var roles = await _userManager.GetRolesAsync(user);
            var roleIds = new List<Guid>();

            foreach (var roleName in roles)
            {
                var role = await _context.Roles.FirstOrDefaultAsync(r => r.Name == roleName);
                
                if (role != null) roleIds.Add(role.Id);
                
            }

            var hasPermission = false;

            foreach (var roleId in roleIds)
            {
                hasPermission = await _context.RolePermissions
                    .Include(rp => rp.Permission)
                    .AnyAsync(rp => rp.RoleId == roleId && rp.Permission.Name == requirement.PermissionName);

                if (hasPermission) break;
            }

            if (hasPermission) context.Succeed(requirement);
        }
    }
}
