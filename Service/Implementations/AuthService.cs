using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.DTO;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Service.Interfaces;

namespace Service.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IJwtGenerator _jwtGenerator;
        private readonly IMapper _mapper;


        public AuthService(UserManager<AppUser> userManager, IJwtGenerator jwtGenerator, IMapper mapper)
        {
            _userManager = userManager;
            _jwtGenerator = jwtGenerator;
            _mapper = mapper;
        }

        public async Task<AuthResult> Login(LoginDTO request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user is null || !await _userManager.CheckPasswordAsync(user, request.Password))
            {
                return new AuthResult { Success = false, Errors = new[] { "Invalid credentials" } };
            }

            var token = _jwtGenerator.GenerateToken(user);

            return new AuthResult { Success = true, Token = token };
        }

        public async Task<AuthResult> Register(RegisterDTO request)
        {
            var user = _mapper.Map<AppUser>(request);

            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                return new AuthResult { Success = false, Errors = result.Errors.Select(e => e.Description) };
            }

            var token = _jwtGenerator.GenerateToken(user);

            return new AuthResult { Success = true, Token = token };
        }
    }
}
