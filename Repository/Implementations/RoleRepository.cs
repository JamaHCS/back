
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

        public async Task<List<Permission>> GetPermissionsByRoleAsync(Guid roleId) => await _context.RolePermissions.Where(rp => rp.RoleId == roleId).Select(rp => rp.Permission).ToListAsync();
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
        public async Task<AppRole?> GetByIdAsync(Guid roleId) => await _context.Roles.FindAsync(roleId);
        public async Task<List<Permission>> UpdateRolePermissionsAsync(Guid roleId, IEnumerable<Guid> permissionIds)
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
        public async Task<RoleWithPermissions?> GetRoleWithPermissionsByIdAsync(Guid roleId) =>await _context.Roles
                .Where(r => r.Id == roleId)
                .Include(r => r.RolePermissions)
                    .ThenInclude(rp => rp.Permission)
                .ProjectTo<RoleWithPermissions>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

    }
}
