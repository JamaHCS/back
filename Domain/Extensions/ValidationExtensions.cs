using Domain.DTO;
using Domain.Validations;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Domain.Extensions
{
    public static class ValidationExtensions
    {
        public static void addFluentValidations(this IServiceCollection services) 
        {
            services.AddScoped<IValidator<RegisterDTO>, RegisterDtoValidator>();
            services.AddScoped<IValidator<LoginDTO>, LoginDtoValidator>();
        }
    }
}
