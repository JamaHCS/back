using Domain.Entities.Global;
using Domain.Entities.Roles;
using Repository.Interfaces;
using Service.Interfaces;

namespace Service.Implementations
{
    public class PermissionService : IPermissionService
    {
        private readonly IPermissionRepository _permissionRepository;

        public PermissionService(IPermissionRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;
        }

        public async Task<Result<IEnumerable<Permission>>> GetAllPermissionsAsync()
        {
            IEnumerable<Permission> permissions = await _permissionRepository.GetAllAsync();

            return Result.Ok(permissions, 200);
        }
    }
}
