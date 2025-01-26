using AutoMapper;
using Domain.DTO.Roles;
using Domain.DTO.Users;
using Domain.Entities.Global;
using Domain.Entities.Log;
using Microsoft.Extensions.Logging;
using Repository.Interfaces;
using Service.Interfaces;

namespace Service.Implementations
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly ILogger<UserService> _logger;
        private readonly IUserRepository _userRepository;
        private readonly IUserContextService _userContextService;

        public UserService(IMapper mapper, IUserRepository userRepository, ILogger<UserService> logger, IUserContextService userContextService)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _logger = logger;
            _userContextService = userContextService;
        }

        public async Task<Result<GetUserDTO?>> GetById(Guid id)
        {
            var userResult = await _userRepository.GetByIdWithRolesAsync(id);

            if (!userResult.Success)
                return Result.Failure<GetUserDTO?>(userResult.Errors?.ToString(), null, userResult.Status);

            return Result.Ok(userResult.Value, 200);
        }

        public async Task<Result<List<RoleDTO>>> UpdateUserRolesAsync(Guid userId, IEnumerable<Guid> roleIds)
        {
            var user = await _userContextService.GetAuthenticatedUser();
            var result = await _userRepository.UpdateUserRolesAsync(userId, roleIds, user.Id);

            if(result.Success) using (_logger.BeginScope(LogContextManager.ToDictionary(user.Id))) _logger.LogInformation("Se han modificado los roles del usuario {user}.", user.Email);
            else using (_logger.BeginScope(LogContextManager.ToDictionary(user.Id))) _logger.LogInformation("Se han modificado los roles del usuario {user}, pero hubo un error.", user.Email);

            return result;
        }

        public async Task<Result<List<GetUserDTO>>> GetAllUsersAsync()
        {
            var usersResult = await _userRepository.GetAllUsersAsync();

            if (!usersResult.Success)
                return Result.Failure<List<GetUserDTO>>(usersResult.Errors?.ToString(), null, usersResult.Status);

            return Result.Ok(usersResult.Value, 200);
        }

    }
}
