using Microsoft.Extensions.DependencyInjection;

using Service.Implementations;
using Service.Interfaces;
using Service.Utils;

namespace Service.Extensions
{
    public static class RegisterServicesExtension
    {
        public static void registerServices(this IServiceCollection services)
        {
            services.AddScoped<IJwtGenerator, JwtGenerator>();

            services.AddScoped<IAuthService, AuthService>();
        }
    }
}
