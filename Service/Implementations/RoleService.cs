using Domain.DTO.Roles;
using Domain.Entities.Global;
using Domain.Entities.Roles;
using Repository.Interfaces;
using Service.Interfaces;

public class RoleService : IRoleService
{
    private readonly IRoleRepository _roleRepository;
    private readonly IUserContextService _userContextService;

    public RoleService(IRoleRepository roleRepository, IUserContextService userContextService)
    {
        _roleRepository = roleRepository;
        _userContextService = userContextService;
    }
    public async Task<Result<List<RoleWithPermissions>>> GetRolesAndPermissions(Guid userId) => await _roleRepository.GetRolesAndPermissionsByUserIdAsync(userId);
    public async Task<Result<List<PermissionDTO>>> UpdateRolePermissionsAsync(Guid roleId, IEnumerable<Guid> permissionIds)
    {
        var role = await _roleRepository.GetByIdAsync(roleId);

        if (!role.Success) return Result.Failure<List<PermissionDTO>>(role.Errors?.ToString(), 404);

        var permissions = await _roleRepository.UpdateRolePermissionsAsync(roleId, permissionIds);

        return permissions.Success
            ? Result.Ok(permissions.Value.Select(p => new PermissionDTO
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description
            }).ToList(), 200)
            : Result.Failure<List<PermissionDTO>>(permissions.Errors?.ToString(), 400);
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

        return await _roleRepository.CreateRoleWithPermissionsAsync(role, createRoleDto.PermissionIds);
    }
    public async Task<Result> DeleteRoleAsync(Guid roleId) => await _roleRepository.DeleteRoleAsync(roleId);
}
