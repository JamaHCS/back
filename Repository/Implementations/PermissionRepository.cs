using Domain.Entities.Global;
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

        public async Task<Result<List<Permission>>> GetAllAsync()
        {
            var permissions = await _context.Permissions.ToListAsync();

            return permissions.Any()
                ? Result.Ok(permissions, 200)
                : Result.Failure<List<Permission>>("No se han encontrado permisos.", 404);            
        }
    }
}
