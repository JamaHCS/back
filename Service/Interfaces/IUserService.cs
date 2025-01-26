using Domain.DTO.Roles;
using Domain.DTO.Users;
using Domain.Entities.Global;

namespace Service.Interfaces
{
    public interface IUserService
    {
        Task<Result<GetUserDTO?>> GetById(Guid id);
        Task<Result<List<RoleDTO>>> UpdateUserRolesAsync(Guid userId, IEnumerable<Guid> roleIds);
        Task<Result<List<GetUserDTO>>> GetAllUsersAsync();
    }
}
