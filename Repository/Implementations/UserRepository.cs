using Domain.Entities.Auth;
using Domain.Entities.Global;
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

        public async Task<Result<AppUser?>> GetByIdAsync(Guid userId)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == userId);

            return user is not null
                ? Result.Ok<AppUser?>(user, 200)
                : Result.Failure<AppUser?>("El usuario no fue encontrado.", 404);
        }

        public async Task<Result> UpdateUserAsync(AppUser user)
        {
            _context.Users.Update(user);
            var changes = await _context.SaveChangesAsync();

            return changes > 0
                ? Result.Ok(204)
                : Result.Failure("No se pudo actualizar el usuario.", 400);
        }

        public async Task<Result> UpdateLastLoginAsync(Guid userId)
        {
            var userResult = await GetByIdAsync(userId);

            if (!userResult.Success)
                return Result.Failure(userResult.Errors?.ToString(), userResult.Status);

            var user = userResult.Value!;
            user.LastLoginAt = DateTime.UtcNow;

            return await UpdateUserAsync(user);
        }
    }
}
