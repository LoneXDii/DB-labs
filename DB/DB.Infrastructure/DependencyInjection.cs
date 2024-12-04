using DB.Domain.Abstractions;
using DB.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DB.Infrastructure.Repositories;
using SupportService.Infrastructure.Data;

namespace DB.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(opt =>
                        opt.UseMySql(configuration["MySQLConnection"],
                        new MySqlServerVersion(new Version(8, 0, 36)),
                    opt => opt.EnableRetryOnFailure()),
                    ServiceLifetime.Scoped);

        services.AddScoped<IRepository<Car>, CarRepository>();

        return services;
    }
}