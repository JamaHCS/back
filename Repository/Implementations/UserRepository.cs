using System.Data;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.DTO.Roles;
using Domain.DTO.Users;
using Domain.Entities.Auth;
using Domain.Entities.Global;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Interfaces;

namespace Repository.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IRoleRepository _roleRepository;
        private readonly IEntityAuditHelper _entityAuditHelper;

        public UserRepository(UserManager<AppUser> userManager, AppDbContext context, IMapper mapper, IRoleRepository roleRepository, IEntityAuditHelper entityAuditHelper)
        {
            _userManager = userManager;
            _context = context;
            _mapper = mapper;
            _roleRepository = roleRepository;
            _entityAuditHelper = entityAuditHelper;
        }

        public async Task<Result<AppUser?>> GetByIdAsync(Guid userId)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == userId);

            return user is not null
                ? Result.Ok<AppUser?>(user, 200)
                : Result.Failure<AppUser?>("El usuario no fue encontrado.", 404);
        }

        public async Task<Result<GetUserDTO?>> GetByIdWithRolesAsync(Guid userId)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == userId);

            if (user is null)
                return Result.Failure<GetUserDTO?>("El usuario no fue encontrado.", 404);

            var roles = await _userManager.GetRolesAsync(user);

            var roleList = await _context.Roles
                .Where(r => roles.Contains(r.Name))
                .ProjectTo<UserRoleDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();

            var userDto = _mapper.Map<GetUserDTO>(user);

            userDto.Roles = roleList;

            return Result.Ok(userDto, 200);
        }


        public async Task<Result> UpdateUserAsync(AppUser user)
        {
            _context.Users.Update(user);
            var changes = await _context.SaveChangesAsync();

            return changes > 0
                ? Result.Ok(204)
                : Result.Failure("No se pudo actualizar el usuario.", 400);
        }

        public async Task<Result> UpdateLastLoginAsync(Guid userId)
        {
            var userResult = await GetByIdAsync(userId);

            if (!userResult.Success)
                return Result.Failure(userResult.Errors?.ToString(), userResult.Status);

            var user = userResult.Value!;
            user.LastLoginAt = DateTime.UtcNow;

            return await UpdateUserAsync(user);
        }

        public async Task<Result<List<RoleDTO>>> UpdateUserRolesAsync(Guid userId, IEnumerable<Guid> roleIds, Guid? updatedByUserId = null)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == userId);

            if (user is null) return Result.Failure<List<RoleDTO>>("Usuario no encontrado.", 404);

            var currentRoles = await _roleRepository.GetRolesAndPermissionsByUserIdAsync(user.Id);
            var currentRolesNames = currentRoles.Value.Select(r => r.Name).ToList();

            var removalResult = await _userManager.RemoveFromRolesAsync(user, currentRolesNames);

            if (!removalResult.Succeeded) return Result.Failure<List<RoleDTO>>("No se pudieron eliminar los roles actuales del usuario.", 500);
            
            var rolesToAssign = await _context.Roles.Where(r => roleIds.Contains(r.Id)).ToListAsync();
            var roleNames = rolesToAssign.Select(r => r.Name).ToList();
            var addResult = await _userManager.AddToRolesAsync(user, roleNames);
            
            if (!addResult.Succeeded) return Result.Failure<List<RoleDTO>>("No se pudieron asignar los nuevos roles al usuario.", 500);

            if(updatedByUserId != null)
            {
                _entityAuditHelper.SetUpdatedAuditFields(user, updatedByUserId);
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
            }

            var assignedRoles = _mapper.Map<List<RoleDTO>>(rolesToAssign);

            return Result.Ok(assignedRoles, "Roles actualizados correctamente.", 200);
        }

        public async Task<Result<List<GetUserDTO>>> GetAllUsersAsync()
        {
            var users = await _userManager.Users
                .Include(u => u.UserRoles)
                .ToListAsync();

            if (!users.Any()) return Result.Failure<List<GetUserDTO>>("No se encontraron usuarios.", 404);

            var userDtos = _mapper.Map<List<GetUserDTO>>(users);

            foreach (var userDto in userDtos)
            {
                var user = users.First(u => u.Id == userDto.Id);
                var roles = await _userManager.GetRolesAsync(user);

                userDto.Roles = roles.Select(role => new UserRoleDTO
                {
                    Id = _context.Roles.First(r => r.Name == role).Id,
                    Name = role
                }).ToList();
            }

            return Result.Ok(userDtos, 200);
        }

    }
}
