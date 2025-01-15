using AutoMapper;
using Domain.DTO.Auth;
using Domain.Entities.Auth;
using Domain.Entities.Global;
using Domain.Entities.Log;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Repository.Interfaces;
using Service.Interfaces;

namespace Service.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IJwtGenerator _jwtGenerator;
        private readonly IMapper _mapper;
        private readonly ILogger<AuthService> _logger;
        private readonly IUserRepository _userRepository;

        public AuthService(UserManager<AppUser> userManager, IJwtGenerator jwtGenerator, IMapper mapper, ILogger<AuthService> logger, IUserRepository userRepository)
        {
            _userManager = userManager;
            _jwtGenerator = jwtGenerator;
            _mapper = mapper;
            _logger = logger;
            _userRepository = userRepository;
        }

        public async Task<Result<TokenResponse?>> Login(LoginDTO request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if(user is null) using (_logger.BeginScope(LogContextManager.ToDictionary())) _logger.LogInformation("Usuario {UserEmail} no fue encontrado", request.Email);

            if (user is null || !await _userManager.CheckPasswordAsync(user, request.Password))
            {
                using (_logger.BeginScope(LogContextManager.ToDictionary())) _logger.LogInformation("Usuario {UserEmail} no pudo ingresar, credenciales erroneas", request.Email);

                return Result.Failure<TokenResponse?>("Login fallido, credenciales erroneas", 401);
            }
            
            var token = _jwtGenerator.GenerateToken(user);

            using (_logger.BeginScope(LogContextManager.ToDictionary(user.Id))) _logger.LogInformation("Usuario {UserEmail} loggueado", user.Email);

            await _userRepository.UpdateLastLoginAsync(user.Id);

           return Result.Ok<TokenResponse?>(new TokenResponse { Token = token, UserId = user.Id }, 200);
        }

        public async Task<Result<TokenResponse?>> Register(RegisterDTO request)
        {
            var user = _mapper.Map<AppUser>(request);

            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                using (_logger.BeginScope(LogContextManager.ToDictionary())) _logger.LogInformation("Registro fallido: {Email}", user.Email);

                return Result.Failure<TokenResponse?>("Registro fallido", 400);
            }

            var token = _jwtGenerator.GenerateToken(user);

            using (_logger.BeginScope(LogContextManager.ToDictionary(user.Id))) _logger.LogInformation("Usuario {UserEmail} registrado", user.Email);

            return Result.Ok<TokenResponse?>(new TokenResponse { Token = token }, 200);
        }
    }
}
