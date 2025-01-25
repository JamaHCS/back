using Domain.DTO.Roles;
using Domain.Entities.Roles;

namespace Repository.Interfaces
{
    public interface IPermissionRepository
    {
        Task<IEnumerable<Permission>> GetAllAsync();
    }
}
