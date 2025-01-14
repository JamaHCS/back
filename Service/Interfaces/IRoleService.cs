using Domain.DTO.Roles;
using Domain.Entities.Auth;
using Domain.Entities.Global;

namespace Service.Interfaces
{
    public interface IRoleService
    {
        public Task<Result<List<RoleWithPermissions>>> GetRolesAndPermissions(Guid userId);
        public Task AssignRoleToUser(AppUser user, string roleName);
        public Task RemoveRoleFromUser(AppUser user, string roleName);
    }
}
