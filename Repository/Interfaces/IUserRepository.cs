
using Domain.DTO.Roles;
using Domain.DTO.Users;
using Domain.Entities.Auth;
using Domain.Entities.Global;

namespace Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<Result<AppUser?>> GetByIdAsync(Guid userId);
        Task<Result> UpdateUserAsync(AppUser user);
        Task<Result> UpdateLastLoginAsync(Guid userId);
        Task<Result<List<RoleDTO>>> UpdateUserRolesAsync(Guid userId, IEnumerable<Guid> roleIds, Guid? updatedByUserId = null);
        Task<Result<GetUserDTO?>> GetByIdWithRolesAsync(Guid userId);
        Task<Result<List<GetUserDTO>>> GetAllUsersAsync();
    }
}
