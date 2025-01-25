using Domain.DTO.Roles;
using Domain.Entities.Global;
using Repository.Interfaces;
using Service.Interfaces;

namespace Service.Implementations
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRepository _userRepository;

        public RoleService(IRoleRepository roleRepository, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public async Task<Result<List<RoleWithPermissions>>> GetRolesAndPermissions(Guid userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);

            if (user == null) return Result.Failure("Usuario no encontrado.", new List<RoleWithPermissions> {}, 404);

            var rolesWithPermissions = await _roleRepository.GetRolesAndPermissionsByUserIdAsync(userId);

            return Result.Ok(rolesWithPermissions, 200);
        }

        public async Task<Result<List<PermissionDto>>> UpdateRolePermissionsAsync(Guid roleId, IEnumerable<Guid> permissionIds)
        {
            var role = await _roleRepository.GetByIdAsync(roleId);

            if (role is null) return Result.Failure<List<PermissionDto>>("Rol no encontrado.", 404);

            var permissions = await _roleRepository.UpdateRolePermissionsAsync(roleId, permissionIds);

            return Result.Ok(permissions.Select(permission => new PermissionDto
            {
                Id = permission.Id,
                Name = permission.Name,
                Description = permission.Description
            }).ToList(), 200);
        }

        public async Task<Result<RoleWithPermissions?>> GetRoleAndPermissionsById(Guid roleId)
        {
            var role = await _roleRepository.GetRoleWithPermissionsByIdAsync(roleId);

            if (role is null) return Result.Failure<RoleWithPermissions?>("Rol no encontrado.", 404);

            return Result.Ok<RoleWithPermissions?>(role, 200);
        }
    }
}
