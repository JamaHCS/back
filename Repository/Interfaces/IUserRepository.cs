
using Domain.Entities.Auth;

namespace Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<AppUser?> GetByIdAsync(Guid userId);
        Task UpdateUserAsync(AppUser user);
        Task UpdateLastLoginAsync(Guid userId);
    }
}
