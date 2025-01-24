using Domain.DTO.Roles;
using Domain.Entities.Auth;
using Domain.Entities.Global;
using Domain.Entities.Log;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Repository.Interfaces;
using Service.Interfaces;

namespace Service.Implementations
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRepository _userRepository;
        private readonly UserManager<AppUser> _userManager;
        private readonly ILogger<RoleService> _logger;

        public RoleService(IRoleRepository roleRepository, IUserRepository userRepository, UserManager<AppUser> userManager, ILogger<RoleService> logger)
        {
            _userRepository = userRepository;
            _userManager = userManager;
            _roleRepository = roleRepository;
            _logger = logger;
        }

        public async Task<Result<List<RoleWithPermissions>>> GetRolesAndPermissions(Guid userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);

            if (user == null) return Result.Failure("Usuario no encontrado.", new List<RoleWithPermissions> {}, 404);

            var rolesWithPermissions = await _roleRepository.GetRolesAndPermissionsByUserIdAsync(userId);

            using (_logger.BeginScope(LogContextManager.ToDictionary(user.Id))) _logger.LogInformation("Permisos de usuario consultados.");

            return Result.Ok(rolesWithPermissions, 200);
        }

        public async Task AssignRoleToUser(AppUser user, string roleName) => await _userManager.AddToRoleAsync(user, roleName);
        
        public async Task RemoveRoleFromUser(AppUser user, string roleName) => await _userManager.RemoveFromRoleAsync(user, roleName);
        
    }
}
