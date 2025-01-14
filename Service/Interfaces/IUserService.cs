using Domain.DTO.Users;
using Domain.Entities.Auth;
using Domain.Entities.Global;

namespace Service.Interfaces
{
    public interface IUserService
    {
        Task<Result<GetUserDTO?>> GetById(Guid id);
    }
}
