using API.Authorization;
using Domain.Entities.Auth;
using Domain.Entities.Global;
using Domain.Entities.Roles;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Repository.Context;
using System.Text;

namespace API.Extensions
{
    public static class AuthenticationExtensions
    {
        public static void AddAuthenticationConf(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 8;
            })
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();

            services.AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();

            using (var serviceProvider = services.BuildServiceProvider())
            {
                using (var scope = serviceProvider.CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                    var allPermissions = context.Permissions.Select(p => p.Name).ToList();

                    services.AddAuthorization(options =>
                    {
                        foreach (var permission in allPermissions)
                        {
                            options.AddPolicy(permission, policy =>
                            {
                                policy.Requirements.Add(new PermissionRequirement(permission));
                            });
                        }
                    });
                }
            }

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = true;
                options.SaveToken = true;

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"] ?? "test_key_default"))
                };

                options.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        context.Response.ContentType = "application/json";
                        context.Response.StatusCode = 401;

                        var result = Result.Failure("Autorización inválida o expirada.", 401);

                        return context.Response.WriteAsJsonAsync(result);
                    },
                    OnChallenge = context =>
                    {
                        context.HandleResponse();

                        context.Response.ContentType = "application/json";
                        context.Response.StatusCode = 401;

                        var result = Result.Failure("Autenticación requerida. Por favor, inicia sesión.", 401);

                        return context.Response.WriteAsJsonAsync(result);
                    }
                };
            });

            services.AddAuthorization();
        }
    }
}