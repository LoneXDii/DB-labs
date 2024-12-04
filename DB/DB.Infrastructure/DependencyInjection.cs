using DB.Domain.Abstractions;
using DB.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DB.Infrastructure.Repositories;
using SupportService.Infrastructure.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using DB.Infrastructure.Auth;

namespace DB.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(opt =>
            opt.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = "Issuer",
                ValidAudience = "Audience",
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("TempSecretKey123123123123123123123"))
            });

        services.AddAuthorization(opt =>
        {
            opt.AddPolicy("Admin", p => p.RequireRole("2"));
            opt.AddPolicy("Employee", p => p.RequireRole("3", "2"));
        });

        services.AddDbContext<AppDbContext>(opt =>
                        opt.UseMySql(configuration["MySQLConnection"],
                        new MySqlServerVersion(new Version(8, 0, 36)),
                    opt => opt.EnableRetryOnFailure()),
                    ServiceLifetime.Scoped);

        services.AddScoped<ITokenService, TokenService>()
            .AddScoped<IUserRepository, UserRepository>();

        services.AddScoped<IRepository<Car>, CarRepository>()
            .AddScoped<IRepository<CarBodyType>, CarBodyTypeRepository>()
            .AddScoped<IRepository<CarBrand>, CarBrandRepository>()
            .AddScoped<IRepository<CarClass>, CarClassRepository>()
            .AddScoped<IRepository<Log>, LogsRepository>();

        return services;
    }
}