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

        public async Task<Result<List<Permission>>> GetAllPermissionsAsync() => await _permissionRepository.GetAllAsync();
    }
}
