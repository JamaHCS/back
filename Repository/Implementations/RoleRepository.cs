
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Domain.Entities.Roles;
using Repository.Interfaces;
using AutoMapper;
using Domain.Entities.Auth;
using Microsoft.AspNetCore.Identity;
using AutoMapper.QueryableExtensions;
using Domain.DTO.Roles;

namespace Repository.Implementations
{
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

        public async Task<List<RolePermission>> AssignPermissionToRole(Guid roleId, Guid permissionId)
        {
            var existing = await _context.RolePermissions.FirstOrDefaultAsync(rp => rp.RoleId == roleId && rp.PermissionId == permissionId);

            if (existing == null)
            {
                var rp = new RolePermission
                {
                    RoleId = roleId,
                    PermissionId = permissionId
                };

                _context.RolePermissions.Add(rp);

                await _context.SaveChangesAsync();
            }

            return await _context.RolePermissions.Where(rp => rp.RoleId == roleId).ToListAsync();
        }

        public async Task<List<RolePermission>> RemovePermissionFromRole(Guid roleId, Guid permissionId)
        {
            var existing = await _context.RolePermissions
                .FirstOrDefaultAsync(rp => rp.RoleId == roleId && rp.PermissionId == permissionId);

            if (existing != null)
            {
                _context.RolePermissions.Remove(existing);
                await _context.SaveChangesAsync();
            }

            return await _context.RolePermissions.Where(rp => rp.RoleId == roleId).ToListAsync();
        }

        public async Task<List<RolePermission>> AssignPermissionsToRole(Guid roleId, IEnumerable<Guid> permissionIds)
        {
            var existingPermissions = await _context.RolePermissions
                .Where(rp => rp.RoleId == roleId && permissionIds.Contains(rp.PermissionId))
                .Select(rp => rp.PermissionId)
                .ToListAsync();

            var newPermissions = permissionIds.Except(existingPermissions);

            if (newPermissions.Any())
            {
                var rolePermissions = newPermissions.Select(permissionId => new RolePermission
                {
                    RoleId = roleId,
                    PermissionId = permissionId
                });

                _context.RolePermissions.AddRange(rolePermissions);
                await _context.SaveChangesAsync();
            }

            return await _context.RolePermissions.Where(rp => rp.RoleId == roleId).ToListAsync();
        }

        public async Task<List<RolePermission>> RemovePermissionsFromRole(Guid roleId, IEnumerable<Guid> permissionIds)
        {
            var permissionsToRemove = await _context.RolePermissions
                .Where(rp => rp.RoleId == roleId && permissionIds.Contains(rp.PermissionId))
                .ToListAsync();

            if (permissionsToRemove.Any())
            {
                _context.RolePermissions.RemoveRange(permissionsToRemove);
                await _context.SaveChangesAsync();
            }

            return await _context.RolePermissions.Where(rp => rp.RoleId == roleId).ToListAsync();
        }

        public async Task<List<RolePermission>> GetPermissions(Guid roleId) => await _context.RolePermissions.Where(rp => rp.RoleId == roleId).ToListAsync();

        public async Task<List<RoleWithPermissions>> GetRolesAndPermissionsByUserIdAsync(Guid userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);

            if (user == null) return new List<RoleWithPermissions>();

            var roles = await _userManager.GetRolesAsync(user);

            var rolesWithPermissions = await _context.Roles
                .Where(r => roles.Contains(r.Name))
                .Include(r => r.RolePermissions)
                    .ThenInclude(rp => rp.Permission)
                .ProjectTo<RoleWithPermissions>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return rolesWithPermissions;
        }
    }
}
