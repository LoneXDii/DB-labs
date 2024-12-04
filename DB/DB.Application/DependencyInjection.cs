using DB.Application.UseCases.BodyTypes;
using DB.Application.UseCases.Brands;
using DB.Application.UseCases.Cars;
using DB.Application.UseCases.Classes;
using DB.Application.UseCases.Logs;
using DB.Application.UseCases.Orders;
using DB.Application.UseCases.Users;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DB.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(DependencyInjection).Assembly))
            .AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddScoped<ICarService, CarService>()
            .AddScoped<ICarBrandService, CarBrandService>()
            .AddScoped<ICarBodyTypeService, CarBodyTypeService>()
            .AddScoped<ICarClassService, CarClassService>()
            .AddScoped<ILogService, LogService>()
            .AddScoped<IUserService, UserService>()
            .AddScoped<IOrderService, OrderService>();

        return services;
    }
}
