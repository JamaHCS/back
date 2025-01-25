using Domain.DTO.Roles;
using Domain.Entities.Global;

namespace Service.Interfaces
{
    public interface IRoleService
    {
        public Task<Result<List<RoleWithPermissions>>> GetRolesAndPermissions(Guid userId);
        public Task<Result<List<PermissionDto>>> UpdateRolePermissionsAsync(Guid roleId, IEnumerable<Guid> permissionIds);
        public Task<Result<RoleWithPermissions?>> GetRoleAndPermissionsById(Guid roleId);
    }
}
