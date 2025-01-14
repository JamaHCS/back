using Domain.DTO.Users;
using Domain.Entities.Auth;
using Domain.Entities.Global;
using Domain.Entities.Roles;
using Microsoft.AspNetCore.Identity;
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

        public async Task<Result<Permission?>> GetPermissionByIdAsync(Guid id)
        {
            Permission? permission = await _permissionRepository.GetByIdAsync(id);

            return Result.Ok(permission, 200);
        }
    }
}
