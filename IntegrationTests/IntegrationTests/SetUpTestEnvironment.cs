using System;
using System.Linq;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Service1;
using Service1.Service2Services;


namespace IntegrationTests;

internal class SetUpTestEnvironment2 : WebApplicationFactory<Service2.Program>
{
    internal readonly HttpClient testClient;

    public SetUpTestEnvironment2()
    {
        testClient = CreateClient();
    }
}

internal class SetUpTestEnvironment1 : WebApplicationFactory<Service1.Program>
{
    internal readonly HttpClient testClient;
    private readonly HttpClient _service2Client;
    public SetUpTestEnvironment1(HttpClient service2Client)
    {
        _service2Client = service2Client;
        testClient = CreateClient();
    }
    
    protected override IHost CreateHost(IHostBuilder builder)
    {
        builder.ConfigureServices(serviceCollection =>
        {
            IOptions<ServicesOption> servicesOption = Options.Create(new ServicesOption
            {
                Service2ApiUrl = ""
            });

            serviceCollection.AddScoped<IService2Service>(_ => new Service2Service(servicesOption,_service2Client));
        });

        return base.CreateHost(builder);
    }
}

public static class ServiceCollectionExtensions
{
    public static IServiceCollection Remove<T>(this IServiceCollection services)
    {
        var serviceDescriptor = services.FirstOrDefault(descriptor => descriptor.ServiceType == typeof(T));
        if (serviceDescriptor != null) services.Remove(serviceDescriptor);

        return services;
    }
}