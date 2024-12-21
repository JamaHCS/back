
using Domain.Mapping;
using Microsoft.Extensions.DependencyInjection;

namespace Domain.Extensions
{
    public static class MappingExtension
    {
        public static void addAutoMappers(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(RegisterMapping));
        }

    }
}
