using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }
    }
}
