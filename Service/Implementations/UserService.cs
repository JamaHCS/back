using Domain.Entities.Auth;
using Microsoft.AspNetCore.Identity;

namespace Service.Implementations
{
    public class UserService
    {
        private readonly UserManager<AppUser> _userManager;

        public UserService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task AssignRoleToUser(AppUser user, string roleName)
        {
            var result = await _userManager.AddToRoleAsync(user, roleName);
        }

        public async Task RemoveRoleFromUser(AppUser user, string roleName)
        {
            var result = await _userManager.RemoveFromRoleAsync(user, roleName);
        }
    }
}
