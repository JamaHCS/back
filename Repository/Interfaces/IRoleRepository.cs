using Domain.DTO.Roles;
using Domain.Entities.Roles;

namespace Repository.Interfaces
{
    public interface IRoleRepository
    {
        public Task<List<Permission>> GetPermissionsByRoleAsync(Guid roleId);
        public Task<List<RoleWithPermissions>> GetRolesAndPermissionsByUserIdAsync(Guid userId);
        public Task<AppRole?> GetByIdAsync(Guid roleId);
        public Task<List<Permission>> UpdateRolePermissionsAsync(Guid roleId, IEnumerable<Guid> permissionIds);
        public Task<RoleWithPermissions?> GetRoleWithPermissionsByIdAsync(Guid roleId);
    }
}
