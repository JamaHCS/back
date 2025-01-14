using AutoMapper;
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

        public UserRepository(UserManager<AppUser> userManager, AppDbContext context, IMapper mapper)
        {
            _userManager = userManager;
        }

        public async Task<AppUser?> GetByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<AppUser?> GetByIdAsync(Guid userId)
        {
            return await _userManager.Users.FirstOrDefaultAsync(u => u.Id == userId);
        }
    }
}
