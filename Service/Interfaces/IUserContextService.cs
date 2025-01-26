using Domain.Entities.Auth;

namespace Service.Interfaces
{
    public interface IUserContextService
    {
        Task<AppUser?> GetAuthenticatedUser();
    }
}
