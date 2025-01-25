using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.DTO.Roles;
using Domain.Entities.Auth;
using Domain.Entities.Global;
using Domain.Entities.Roles;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Interfaces;

public class RoleRepository : IRoleRepository
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;
    private readonly UserManager<AppUser> _userManager;
    private readonly IUserRepository _userRepository;

    public RoleRepository(AppDbContext context, UserManager<AppUser> userManager, IMapper mapper, IUserRepository userRepository)
    {
        _context = context;
        _userManager = userManager;
        _mapper = mapper;
        _userRepository = userRepository;
    }

    public async Task<Result<List<Permission>>> GetPermissionsByRoleAsync(Guid roleId)
    {
        var permissions = await _context.RolePermissions.Where(rp => rp.RoleId == roleId).Select(rp => rp.Permission).ToListAsync();

        return permissions.Any()
            ? Result.Ok(permissions, 200)
            : Result.Ok(new List<Permission>(), "No se encontraron permisos para el rol.", 204);
    }

    public async Task<Result<List<RoleWithPermissions>>> GetRolesAndPermissionsByUserIdAsync(Guid userId)
    {
        var user = await _userRepository.GetByIdAsync(userId);

        if (!user.Success) return Result.Failure<List<RoleWithPermissions>>("Usuario no encontrado.", 404);

        var roles = await _userManager.GetRolesAsync(user.Value);

        var rolesWithPermissions = await _context.Roles
            .Where(r => roles.Contains(r.Name))
            .Include(r => r.RolePermissions)
                .ThenInclude(rp => rp.Permission)
                .ProjectTo<RoleWithPermissions>(_mapper.ConfigurationProvider)
                .ToListAsync();
                
        return Result.Ok(rolesWithPermissions, 200);
    }

    public async Task<Result<AppRole?>> GetByIdAsync(Guid roleId)
    {
        var role = await _context.Roles.FindAsync(roleId);

        return role is not null
            ? Result.Ok<AppRole?>(role, 200)
            : Result.Failure<AppRole?>("Rol no encontrado.", 404);
    }

    public async Task<Result<List<Permission>>> UpdateRolePermissionsAsync(Guid roleId, IEnumerable<Guid> permissionIds)
    {
        var existingPermissions = _context.RolePermissions.Where(rp => rp.RoleId == roleId);
        _context.RolePermissions.RemoveRange(existingPermissions);

        if (permissionIds.Any())
        {
            var newPermissions = permissionIds.Select(permissionId => new RolePermission
            {
                RoleId = roleId,
                PermissionId = permissionId
            });

            await _context.RolePermissions.AddRangeAsync(newPermissions);
        }

        await _context.SaveChangesAsync();

        return await GetPermissionsByRoleAsync(roleId);
    }

    public async Task<Result<RoleWithPermissions?>> GetRoleWithPermissionsByIdAsync(Guid roleId)
    {
        var role = await _context.Roles
            .Where(r => r.Id == roleId)
            .Include(r => r.RolePermissions)
                .ThenInclude(rp => rp.Permission)
            .ProjectTo<RoleWithPermissions>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync();

        return role is not null
            ? Result.Ok<RoleWithPermissions?>(role, 200)
            : Result.Failure<RoleWithPermissions?>("Rol no encontrado.", 404);
    }

    public async Task<Result<RoleWithPermissions?>> CreateRoleWithPermissionsAsync(AppRole role, IEnumerable<Guid> permissionIds)
    {
        await _context.Roles.AddAsync(role);

        if (permissionIds.Any())
        {
            var rolePermissions = permissionIds.Select(permissionId => new RolePermission
            {
                RoleId = role.Id,
                PermissionId = permissionId
            });

            await _context.RolePermissions.AddRangeAsync(rolePermissions);
        }

        await _context.SaveChangesAsync();

        return await GetRoleWithPermissionsByIdAsync(role.Id);
    }

    public async Task<Result> DeleteRoleAsync(Guid roleId)
    {
        var role = await _context.Roles.Include(r => r.RolePermissions).FirstOrDefaultAsync(r => r.Id == roleId);

        if (role is null) return Result.Failure("Rol no encontrado.", 404);

        _context.RolePermissions.RemoveRange(role.RolePermissions);

        var userRoles = await _context.UserRoles.Where(ur => ur.RoleId == roleId).ToListAsync();
        _context.UserRoles.RemoveRange(userRoles);
        _context.Roles.Remove(role);

        await _context.SaveChangesAsync();

        return Result.Ok(204);
    }
}
