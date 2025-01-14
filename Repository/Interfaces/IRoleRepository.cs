using Domain.DTO.Roles;
using Domain.Entities.Roles;

namespace Repository.Interfaces
{
    public interface IRoleRepository
    {
        public Task<List<RolePermission>> AssignPermissionToRole(Guid roleId, Guid permissionId);
        public Task<List<RolePermission>> RemovePermissionFromRole(Guid roleId, Guid permissionId);
        public Task<List<RolePermission>> AssignPermissionsToRole(Guid roleId, IEnumerable<Guid> permissionIds);
        public Task<List<RolePermission>> RemovePermissionsFromRole(Guid roleId, IEnumerable<Guid> permissionIds);
        public Task<List<RolePermission>> GetPermissions(Guid roleId);
        Task<List<RoleWithPermissions>> GetRolesAndPermissionsByUserIdAsync(Guid userId);

    }
}
