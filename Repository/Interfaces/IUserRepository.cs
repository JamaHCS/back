
using Domain.DTO.Roles;
using Domain.Entities.Auth;

namespace Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<AppUser?> GetByEmailAsync(string email);
        Task<AppUser?> GetByIdAsync(Guid userId);
        Task UpdateUserAsync(AppUser user);
        Task UpdateLastLoginAsync(Guid userId);
    }
}
