using Domain.Entities.Roles;

namespace Repository.Interfaces
{
    public interface IRolePermissionRepository
    {
        public Task<List<RolePermission>> AssignPermissionToRole(Guid roleId, Guid permissionId);
        public Task<List<RolePermission>> RemovePermissionFromRole(Guid roleId, Guid permissionId);
        public Task<List<RolePermission>> AssignPermissionsToRole(Guid roleId, IEnumerable<Guid> permissionIds);
        public Task<List<RolePermission>> RemovePermissionsFromRole(Guid roleId, IEnumerable<Guid> permissionIds);
        public Task<List<RolePermission>> GetPermissions(Guid roleId);
    }
}
