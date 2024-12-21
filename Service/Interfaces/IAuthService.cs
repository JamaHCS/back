using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTO;
using NuGet.Protocol.Plugins;

namespace Service.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResult> Login(LoginDTO request);
        Task<AuthResult> Register(RegisterDTO request);
    }
}
