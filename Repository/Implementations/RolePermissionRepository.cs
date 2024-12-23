
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Domain.Entities.Roles;
using Repository.Interfaces;

namespace Repository.Implementations
{
    public class RolePermissionRepository : IRolePermissionRepository
    {
        private readonly AppDbContext _context;

        public RolePermissionRepository(AppDbContext context)
        {
            _context = context;
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
    }
}
