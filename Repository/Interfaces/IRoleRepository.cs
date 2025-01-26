using Domain.DTO.Roles;
using Domain.Entities.Global;
using Domain.Entities.Roles;

namespace Repository.Interfaces
{
    public interface IRoleRepository
    {
        public Task<Result<List<Permission>>> GetPermissionsByRoleAsync(Guid roleId);
        public Task<Result<List<RoleWithPermissions>>> GetRolesAndPermissionsByUserIdAsync(Guid userId);
        public Task<Result<AppRole?>> GetByIdAsync(Guid roleId);
        public Task<Result<List<Permission>>> UpdateRolePermissionsAsync(Guid roleId, IEnumerable<Guid> permissionIds, Guid updatedBy);
        public Task<Result<RoleWithPermissions?>> GetRoleWithPermissionsByIdAsync(Guid roleId);
        public Task<Result<RoleWithPermissions?>> CreateRoleWithPermissionsAsync(AppRole role, IEnumerable<Guid> permissionIds);
        public Task<Result> DeleteRoleAsync(Guid roleId);
        public Task<Result<List<RoleDTO>>> GetAllRolesAsync();
        public Task<Result<RoleDTO>> UpdateRoleAsync(Guid roleId, UpdateRoleDTO request, Guid updatedBy);

    }
}
