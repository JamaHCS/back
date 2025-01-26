using Domain.DTO.Roles;
using Domain.Entities.Global;
using Domain.Entities.Roles;

namespace Service.Interfaces
{
    public interface IRoleService
    {
        public Task<Result<List<RoleWithPermissions>>> GetRolesAndPermissions(Guid userId);
        public Task<Result<List<PermissionDTO>>> UpdateRolePermissionsAsync(Guid roleId, IEnumerable<Guid> permissionIds);
        public Task<Result<RoleWithPermissions?>> GetRoleAndPermissionsById(Guid roleId);
        public Task<Result<RoleWithPermissions?>> CreateRoleAsync(CreateRoleDTO createRoleDto);
        public Task<Result> DeleteRoleAsync(Guid roleId);
        public Task<Result<List<RoleDTO>>> GetAllRolesAsync();
        public Task<Result<RoleDTO>> UpdateRoleAsync(Guid roleId, UpdateRoleDTO request);
    }
}
