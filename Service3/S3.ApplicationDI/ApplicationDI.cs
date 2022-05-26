using Microsoft.Extensions.DependencyInjection;
using S2.Application.Services.ProductDetailsServices;

namespace ApplicationDI;

public static class ApplicationDI
{
    public static IServiceCollection AddApplicationLibrary(this IServiceCollection services)
    {
        services.AddScoped<ICreateUserService, CreateUserService>();
        services.AddScoped<IGetUserService, GetUserService>();
        return services;
    }
}