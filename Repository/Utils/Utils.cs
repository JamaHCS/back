using Domain.Entities.Auth;
using Microsoft.AspNetCore.Identity;

namespace Repository.Utils
{
    public static class Utils
    {
        public static string GetHashPassword(AppUser user, string password)
        {
            var passwordHasher = new PasswordHasher<AppUser>();
            
            return passwordHasher.HashPassword(user, password);
        }
    }
}
