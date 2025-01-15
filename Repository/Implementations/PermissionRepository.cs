using Domain.Entities.Roles;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Interfaces;

namespace Repository.Implementations
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly AppDbContext _context;

        public PermissionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Permission?> GetByIdAsync(Guid id) => await _context.Permissions.FindAsync(id);
        public async Task<IEnumerable<Permission>> GetAllAsync() => await _context.Permissions.ToListAsync();
        
    }
}
