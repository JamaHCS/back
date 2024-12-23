using Domain.Entities.Roles;

namespace Repository.Interfaces
{
    public interface IPermissionRepository
    {
        Task<Permission?> GetByIdAsync(Guid id);
        Task<IEnumerable<Permission>> GetAllAsync();
    }
}
