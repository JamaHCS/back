
using Domain.Entities.Auth;

namespace Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<AppUser?> GetByEmail(string email);
    }
}
