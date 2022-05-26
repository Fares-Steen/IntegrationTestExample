using Microsoft.Extensions.DependencyInjection;
using S1.Application.Services.ProductServices;

namespace ApplicationDI;

public static class ApplicationDI
{
    public static IServiceCollection AddApplicationLibrary(this IServiceCollection services)
    {
        services.AddScoped<ICreateProductService, CreateProductService>();
        services.AddScoped<IGetProductService, GetProductService>();
        return services;
    }
}