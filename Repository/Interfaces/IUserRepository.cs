
using Domain.Entities.Auth;
using Domain.Entities.Global;

namespace Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<Result<AppUser?>> GetByIdAsync(Guid userId);
        Task<Result> UpdateUserAsync(AppUser user);
        Task<Result> UpdateLastLoginAsync(Guid userId);
    }
}
