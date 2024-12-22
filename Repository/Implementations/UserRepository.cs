using Domain.Entities.Auth;
using Microsoft.AspNetCore.Identity;
using Repository.Interfaces;

namespace Repository.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<AppUser> _userManager;

        public UserRepository(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<AppUser?> GetByEmail(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

    }
}
