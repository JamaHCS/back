using Domain.Entities.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Interfaces;

namespace Repository.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly AppDbContext _context;

        public UserRepository(UserManager<AppUser> userManager, AppDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<AppUser?> GetByEmailAsync(string email) => await _userManager.FindByEmailAsync(email);
        public async Task<AppUser?> GetByIdAsync(Guid userId) => await _userManager.Users.FirstOrDefaultAsync(u => u.Id == userId);
        public async Task UpdateUserAsync(AppUser user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateLastLoginAsync(Guid userId)
        {
            var user = await GetByIdAsync(userId);
            user.LastLoginAt = DateTime.UtcNow;
            await UpdateUserAsync(user);
        }
    }
}
