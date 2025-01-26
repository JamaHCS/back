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

    public RoleRepository(AppDbContext context, UserManager<AppUser> userManager, IMapper mapper)
    {
        _context = context;
        _userManager = userManager;
        _mapper = mapper;
    }

    public async Task<Result<List<RoleDTO>>> GetAllRolesAsync()
    {
        var roles = await _context.Roles.ProjectTo<RoleDTO>(_mapper.ConfigurationProvider).ToListAsync();

        return Result.Ok(roles, 200);
    }
    public async Task<Result<RoleDTO>> UpdateRoleAsync(Guid roleId, UpdateRoleDTO request, Guid updatedBy)
    {
        var role = await _context.Roles.FirstOrDefaultAsync(r => r.Id == roleId);

        if (role is null) return Result.Failure<RoleDTO>("Rol no encontrado.", 404);

        role.Name = request.Name;
        role.NormalizedName = request.Name.ToUpper();
        role.Description = request.Description;
        role.UpdatedAt = DateTime.UtcNow;
        role.UpdatedBy = updatedBy;

        _context.Roles.Update(role);
        await _context.SaveChangesAsync();

        var roleDTO = _mapper.Map<RoleDTO>(role);

        return Result.Ok(roleDTO, "Rol actualizado correctamente.", 200);
    }

    public async Task<Result<List<Permission>>> GetPermissionsByRoleAsync(Guid roleId)
    {
        var permissions = await _context.RolePermissions.Where(rp => rp.AppRoleId == roleId).Select(rp => rp.Permission).ToListAsync();

        return permissions.Any()
            ? Result.Ok(permissions, 200)
            : Result.Ok(new List<Permission>(), "No se encontraron permisos para el rol.", 204);
    }

    public async Task<Result<List<RoleWithPermissions>>> GetRolesAndPermissionsByUserIdAsync(Guid userId)
    {
        var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == userId);

        if (user is null) return Result.Failure<List<RoleWithPermissions>>("Usuario no encontrado.", 404);

        var roles = await _userManager.GetRolesAsync(user);

        var rolesWithPermissions = await _context.Roles
            .Where(r => roles.Contains(r.Name))
            .Include(r => r.RolePermissions)
                .ThenInclude(rp => rp.Permission)
                .ProjectTo<RoleWithPermissions>(_mapper.ConfigurationProvider)
                .ToListAsync();
                
        return Result.Ok(rolesWithPermissions, rolesWithPermissions.Any() ? 200 : 204);
    }

    public async Task<Result<AppRole?>> GetByIdAsync(Guid roleId)
    {
        var role = await _context.Roles.FindAsync(roleId);

        return role is not null
            ? Result.Ok<AppRole?>(role, 200)
            : Result.Failure<AppRole?>("Rol no encontrado.", 404);
    }

    public async Task<Result<List<Permission>>> UpdateRolePermissionsAsync(Guid roleId, IEnumerable<Guid> permissionIds, Guid updatedBy)
    {
        var role = await _context.Roles.FirstOrDefaultAsync(r => r.Id == roleId);

        if (role == null) return Result.Failure("Rol no encontrado.", new List<Permission>(), 404);

        var existingPermissions = _context.RolePermissions.Where(rp => rp.AppRoleId == roleId);
        
        if (permissionIds.Any())
        {
            _context.RolePermissions.RemoveRange(existingPermissions);

            var newPermissions = permissionIds.Select(permissionId => new RolePermission
            {
                AppRoleId = roleId,
                PermissionId = permissionId
            });

            await _context.RolePermissions.AddRangeAsync(newPermissions);
        }
        else return Result.Failure<List<Permission>>("El rol debe de tener al menos 1 permiso asociado.", 400);

        role.UpdatedAt = DateTime.UtcNow;
        role.UpdatedBy = updatedBy;

        _context.Roles.Update(role);

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

        var existingRole = await _context.Roles.FirstOrDefaultAsync(r => r.NormalizedName == role.NormalizedName);

        if (existingRole is not null) return Result.Failure<RoleWithPermissions?>("El nombre del rol ya está en uso.", 409);

        if (permissionIds.Any())
        {
            await _context.Roles.AddAsync(role);

            var rolePermissions = permissionIds.Select(permissionId => new RolePermission
            {
                AppRoleId = role.Id,
                PermissionId = permissionId
            });

            await _context.RolePermissions.AddRangeAsync(rolePermissions);
        }
        else return Result.Failure<RoleWithPermissions?>("El rol debe de tener al menos 1 permiso asociado.", 400);
        

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
