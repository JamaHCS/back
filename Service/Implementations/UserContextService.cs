using System.Security.Claims;
using Domain.Entities.Auth;
using Microsoft.AspNetCore.Http;
using Repository.Interfaces;
using Service.Interfaces;

namespace Service.Implementations
{
    public class UserContextService : IUserContextService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserRepository _userRepository;

        public UserContextService(IHttpContextAccessor httpContextAccessor, IUserRepository userRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _userRepository = userRepository;
        }

        public async Task<AppUser?> GetAuthenticatedUserId()
        {
            var userIdClaim = _httpContextAccessor.HttpContext?.User.FindFirst("sub") ??
                              _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier);

            if (userIdClaim != null && Guid.TryParse(userIdClaim.Value, out var userId))
            {
                var user = await _userRepository.GetByIdAsync(userId);
                return user.Value;
            }
            else return null;
        }
    }
}
