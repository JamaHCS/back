using Domain.DTO.Roles;
using Domain.Entities.Global;
using Domain.Entities.Roles;
using Repository.Interfaces;
using Service.Interfaces;

namespace Service.Implementations
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUserContextService _userContextService;

        public RoleService(IRoleRepository roleRepository, IUserRepository userRepository, IUserContextService userContextService)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _userContextService = userContextService;
        }

        public async Task<Result<List<RoleWithPermissions>>> GetRolesAndPermissions(Guid userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);

            if (user == null) return Result.Failure("Usuario no encontrado.", new List<RoleWithPermissions> {}, 404);

            var rolesWithPermissions = await _roleRepository.GetRolesAndPermissionsByUserIdAsync(userId);

            return Result.Ok(rolesWithPermissions, 200);
        }
        public async Task<Result<List<PermissionDTO>>> UpdateRolePermissionsAsync(Guid roleId, IEnumerable<Guid> permissionIds)
        {
            var role = await _roleRepository.GetByIdAsync(roleId);

            if (role is null) return Result.Failure<List<PermissionDTO>>("Rol no encontrado.", 404);

            var permissions = await _roleRepository.UpdateRolePermissionsAsync(roleId, permissionIds);

            return Result.Ok(permissions.Select(permission => new PermissionDTO
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
        public async Task<Result<RoleWithPermissions?>> CreateRoleAsync(CreateRoleDTO createRoleDto)
        {
            var user = await _userContextService.GetAuthenticatedUserId();

            var role = new AppRole
            {
                Id = Guid.NewGuid(),
                Name = createRoleDto.Name,
                NormalizedName = createRoleDto.Name.ToUpper(),
                Description = createRoleDto.Description,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = user.Id
            };

            var roleSaved = await _roleRepository.CreateRoleWithPermissionsAsync(role, createRoleDto.PermissionIds);

            if (roleSaved is null) return Result.Failure<RoleWithPermissions?>("Hubo un problema al crear el rol.", 400);

            return Result.Ok<RoleWithPermissions?>(roleSaved, "Rol creado correctamente.", 201);
        }
        public async Task<Result> DeleteRoleAsync(Guid roleId) => await _roleRepository.DeleteRoleAsync(roleId);
    }
}
