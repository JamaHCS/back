using AutoMapper;
using Domain.DTO;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Service.Interfaces;

namespace Service.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IJwtGenerator _jwtGenerator;
        private readonly IMapper _mapper;
        private readonly ILogger<AuthService> _logger;

        public AuthService(UserManager<AppUser> userManager, IJwtGenerator jwtGenerator, IMapper mapper, ILogger<AuthService> logger)
        {
            _userManager = userManager;
            _jwtGenerator = jwtGenerator;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<AuthResult> Login(LoginDTO request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if(user is null)
            {
                using (_logger.BeginScope(new Dictionary<string, object> { ["LogSubjectId"] = 2 }))
                {
                    _logger.LogInformation("Usuario {UserEmail} no fue encontrado", request.Email);
                }
            }

            if (user is null || !await _userManager.CheckPasswordAsync(user, request.Password))
            {
                using (_logger.BeginScope(new Dictionary<string, object> { ["LogSubjectId"] = 2 }))
                {
                    _logger.LogInformation("Usuario {UserEmail} tuvo login fallido, credenciales erroneas", request.Email);
                }

                return new AuthResult { Success = false, Errors = new[] { "Invalid credentials" } };
            }
            

            var token = _jwtGenerator.GenerateToken(user);

            using (_logger.BeginScope(new Dictionary<string, object> { ["UserId"] = user.Id, ["LogSubjectId"] = 2 }))
            {
                _logger.LogInformation("Usuario {UserEmail} loggueado", user.Email);
            }

            return new AuthResult { Success = true, Token = token };
        }

        public async Task<AuthResult> Register(RegisterDTO request)
        {
            var user = _mapper.Map<AppUser>(request);

            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                using (_logger.BeginScope(new Dictionary<string, object> { ["LogSubjectId"] = 2 }))
                {
                    _logger.LogInformation("Registro fallido: {Email}", user.Email);
                }

                return new AuthResult { Success = false, Errors = result.Errors.Select(e => e.Description) };
            }

            var token = _jwtGenerator.GenerateToken(user);

            using (_logger.BeginScope(new Dictionary<string, object> { ["UserId"] = user.Id, ["LogSubjectId"] = 2 }))
            {
                _logger.LogInformation("Usuario {UserEmail} registrado", user.Email);
            }

            return new AuthResult { Success = true, Token = token };
        }
    }
}
