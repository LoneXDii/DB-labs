using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DB.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(DependencyInjection).Assembly))
            .AddAutoMapper(Assembly.GetExecutingAssembly());

        return services;
    }
}
