using Domain.DTO.Roles;
using Domain.Entities.Global;
using Domain.Entities.Log;
using Domain.Entities.Roles;
using Microsoft.Extensions.Logging;
using Repository.Interfaces;
using Service.Interfaces;

public class RoleService : IRoleService
{
    private readonly IRoleRepository _roleRepository;
    private readonly IUserContextService _userContextService;
    private readonly ILogger<RoleService> _logger;

    public RoleService(IRoleRepository roleRepository, ILogger<RoleService> logger, IUserContextService userContextService)
    {
        _roleRepository = roleRepository;
        _userContextService = userContextService;
        _logger = logger;
    }

    public async Task<Result<List<RoleWithPermissions>>> GetRolesAndPermissions(Guid userId) => await _roleRepository.GetRolesAndPermissionsByUserIdAsync(userId);
    public async Task<Result<List<PermissionDTO>>> UpdateRolePermissionsAsync(Guid roleId, IEnumerable<Guid> permissionIds)
    {
        var user = await _userContextService.GetAuthenticatedUserId();
        var role = await _roleRepository.GetByIdAsync(roleId);

        if (!role.Success) return Result.Failure<List<PermissionDTO>>(role.Errors?.ToString(), 404);

        var permissions = await _roleRepository.UpdateRolePermissionsAsync(roleId, permissionIds, user.Id);

        if (permissions.Success)
        {
            using (_logger.BeginScope(LogContextManager.ToDictionary(user.Id))) _logger.LogInformation("Se han modificado los permisos del rol {role}.", role.Value.Name);

            return Result.Ok(permissions.Value.Select(p => new PermissionDTO
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description
            }).ToList(), 200);
        }
        else
        {
            using (_logger.BeginScope(LogContextManager.ToDictionary(user.Id))) _logger.LogInformation("Se ha intentado modificar los permisos del rol {role}, pero falló.", role.Value.Name);

            return Result.Failure<List<PermissionDTO>>(permissions.Errors?.ToString(), 400);
        }
    }
    public async Task<Result<RoleWithPermissions?>> GetRoleAndPermissionsById(Guid roleId) => await _roleRepository.GetRoleWithPermissionsByIdAsync(roleId);
    public async Task<Result<RoleWithPermissions?>> CreateRoleAsync(CreateRoleDTO createRoleDto)
    {
        var user = await _userContextService.GetAuthenticatedUserId();

        var role = new AppRole
        {
            Id = Guid.NewGuid(),
            Name = createRoleDto.Name,
            NormalizedName = createRoleDto.Name.ToUpper(),
            Description = createRoleDto.Description,
            CreatedAt = DateTime.UtcNow,
            CreatedBy = user.Id
        };

        var roleCreated = await _roleRepository.CreateRoleWithPermissionsAsync(role, createRoleDto.PermissionIds);

        if(roleCreated.Success) using (_logger.BeginScope(LogContextManager.ToDictionary(user.Id))) _logger.LogInformation("El rol {role} se ha creado.", role.Name);
        else using (_logger.BeginScope(LogContextManager.ToDictionary(user.Id))) _logger.LogInformation("Se ha intentado crear un rol con el nombre {role}, pero falló.", role.Name);

        return roleCreated;
    }
    public async Task<Result> DeleteRoleAsync(Guid roleId)
    {
        var user = await _userContextService.GetAuthenticatedUserId();
        var role = await _roleRepository.GetByIdAsync(roleId);

        if(role is null)
        {
            using (_logger.BeginScope(LogContextManager.ToDictionary(user.Id))) _logger.LogInformation("Se ha intentado eliminar un rol.");

            return role;
        } else
        {
            using (_logger.BeginScope(LogContextManager.ToDictionary(user.Id))) _logger.LogInformation("El rol {role} se ha eliminado.", role.Value.Name);

            return await _roleRepository.DeleteRoleAsync(roleId);
        }
    }

    public async Task<Result<List<RoleDTO>>> GetAllRolesAsync() => await _roleRepository.GetAllRolesAsync();
    public async Task<Result<RoleDTO>> UpdateRoleAsync(Guid roleId, UpdateRoleDTO request)
    {
        var userId = await _userContextService.GetAuthenticatedUserId();
        var result = await _roleRepository.UpdateRoleAsync(roleId, request, userId.Id);

        if (!result.Success) return Result.Failure<RoleDTO>(result.Errors.ToString() ?? "Hubo un problema al actualizar el rol.", result.Status);
        
        return result;
    }
}
