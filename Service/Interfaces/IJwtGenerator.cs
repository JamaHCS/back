using Domain.Entities.Auth;

namespace Service.Interfaces
{
    public interface IJwtGenerator
    {
        string GenerateToken(AppUser user);
    }
}
