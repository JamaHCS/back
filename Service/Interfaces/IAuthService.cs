using Domain.DTO.Auth;
using Domain.Entities.Global;

namespace Service.Interfaces
{
    public interface IAuthService
    {
        Task<Result<TokenResponse?>> Login(LoginDTO request);
        Task<Result<TokenResponse?>> Register(RegisterDTO request);
    }
}