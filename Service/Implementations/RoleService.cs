using Domain.DTO.Roles;
using Domain.Entities.Auth;
using Domain.Entities.Global;
using Microsoft.AspNetCore.Identity;
using Repository.Interfaces;
using Service.Interfaces;

namespace Service.Implementations
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRepository _userRepository;
        private readonly UserManager<AppUser> _userManager;

        public RoleService(IRoleRepository roleRepository, IUserRepository userRepository, UserManager<AppUser> userManager)
        {
            _userRepository = userRepository;
            _userManager = userManager;
            _roleRepository = roleRepository;
        }

        public async Task<Result<List<RoleWithPermissions>>> GetRolesAndPermissions(Guid userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);

            if (user == null) return Result.Failure("Usuario no encontrado.", new List<RoleWithPermissions> {}, 404);

            var rolesWithPermissions = await _roleRepository.GetRolesAndPermissionsByUserIdAsync(userId);

            return Result.Ok(rolesWithPermissions, 200);
        }

        public async Task AssignRoleToUser(AppUser user, string roleName) => await _userManager.AddToRoleAsync(user, roleName);
        
        public async Task RemoveRoleFromUser(AppUser user, string roleName) => await _userManager.RemoveFromRoleAsync(user, roleName);
        
    }
}
