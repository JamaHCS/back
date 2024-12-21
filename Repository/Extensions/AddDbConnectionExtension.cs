using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository.Context;

namespace Repository.Extensions
{
    public static class AddDbConnectionExtension
    {
        public static void AddConnection(this IServiceCollection services, IConfiguration configuration) => 
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("ContafacilServerConnection")));
    }
}
