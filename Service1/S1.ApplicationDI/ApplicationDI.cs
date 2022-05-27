using Microsoft.Extensions.DependencyInjection;
using S1.Application.Services.ProductServices;
using S1.Application.Services.Service2Services;
using S1.Application.Services.Service3.Services;

namespace ApplicationDI;

public static class ApplicationDI
{
    public static IServiceCollection AddApplicationLibrary(this IServiceCollection services)
    {
        services.AddScoped<ICreateProductService, CreateProductService>();
        services.AddScoped<IGetProductService, GetProductService>();
        services.AddHttpClient<IService2Service,Service2Service>();
        services.AddHttpClient<IService3Service,Service3Service>();
        return services;
    }
}