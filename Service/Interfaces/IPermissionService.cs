using Domain.DTO.Users;
using Domain.Entities.Global;
using Domain.Entities.Roles;

namespace Service.Interfaces
{
    public interface IPermissionService
    {
        public Task<Result<IEnumerable<Permission>>> GetAllPermissionsAsync();
    }
}
