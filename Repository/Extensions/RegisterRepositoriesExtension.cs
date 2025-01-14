using Microsoft.Extensions.DependencyInjection;
using Repository.Implementations;
using Repository.Interfaces;

namespace Repository.Extensions
{
    public static class RegisterRepositoriesExtension
    {
        public static void registerRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPermissionRepository, PermissionRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
        }
    }
}
