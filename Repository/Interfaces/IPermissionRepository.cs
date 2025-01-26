using Domain.Entities.Global;
using Domain.Entities.Roles;

namespace Repository.Interfaces
{
    public interface IPermissionRepository
    {
        public Task<Result<List<Permission>>> GetAllAsync();
    }
}
