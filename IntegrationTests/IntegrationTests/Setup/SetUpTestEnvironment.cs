using System.Linq;
using System.Net.Http;
using IntegrationTests.Setup.ConnectionFactories;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Moq;
using S1.Application;
using S1.Application.Services.Service2Services;
using S1.Application.Services.Service3.Services;
using S1.SQL.Persistence;
using S2.SQL.Persistence;
using S3.SQL.Persistence;

namespace IntegrationTests.Setup;

internal class SetUpTestEnvironment3 : WebApplicationFactory<Service3.Program>
{
    internal readonly HttpClient TestClient;
    internal readonly Service3DbContext service3DbContext;
    public SetUpTestEnvironment3()
    {
        service3DbContext = new ConnectionFactory<Service3DbContext>().CreateContextForSqLite((options) => new Service3DbContext(options));
        TestClient = CreateClient();
    }
    protected override IHost CreateHost(IHostBuilder builder)
    {
        builder.ConfigureServices(serviceCollection =>
        {
            var servicesOption = Options.Create(new ServicesOption
            {
                Service2ApiUrl = "",
                Service3ApiUrl = ""
            });
            serviceCollection.Remove<S3.SQL.Persistence.Initialize.IDbInitializer>();
            serviceCollection.AddSingleton(service3DbContext);
            serviceCollection.AddSingleton(new Mock<S3.SQL.Persistence.Initialize.IDbInitializer>().Object);
        });

        return base.CreateHost(builder);
    }
}
internal class SetUpTestEnvironment2 : WebApplicationFactory<Service2.Program>
{
    internal readonly HttpClient TestClient;
    internal readonly Service2DbContext service2DbContext;

    public SetUpTestEnvironment2()
    {
        service2DbContext = new ConnectionFactory<Service2DbContext>().CreateContextForSqLite((options) => new Service2DbContext(options));
        TestClient = CreateClient();
    }

    protected override IHost CreateHost(IHostBuilder builder)
    {
        builder.ConfigureServices(serviceCollection =>
        {
            var servicesOption = Options.Create(new ServicesOption
            {
                Service2ApiUrl = "",
                Service3ApiUrl = ""
            });
            serviceCollection.Remove<S2.SQL.Persistence.Initialize.IDbInitializer>();
            serviceCollection.AddSingleton(service2DbContext);
            serviceCollection.AddSingleton(new Mock<S2.SQL.Persistence.Initialize.IDbInitializer>().Object);
        });

        return base.CreateHost(builder);
    }
}

internal class SetUpTestEnvironment1 : WebApplicationFactory<Service1.Program>
{
    internal readonly HttpClient TestClient;
    private readonly HttpClient _service2Client;
    private readonly HttpClient _service3Client;
    internal readonly Service1DbContext service1DbContext;

    public SetUpTestEnvironment1(HttpClient service2Client,HttpClient service3Client)
    {
        service1DbContext = new ConnectionFactory<Service1DbContext>().CreateContextForSqLite((options) => new Service1DbContext(options));
        _service2Client = service2Client;
        _service3Client = service3Client;
        TestClient = CreateClient();
    }

    protected override IHost CreateHost(IHostBuilder builder)
    {
        builder.ConfigureServices(serviceCollection =>
        {
            var servicesOption = Options.Create(new ServicesOption
            {
                Service2ApiUrl = "",
                Service3ApiUrl = ""
            });
            serviceCollection.Remove<S1.SQL.Persistence.Initialize.IDbInitializer>();
            serviceCollection.Remove<IService2Service>();
            serviceCollection.Remove<IService3Service>();
            serviceCollection.AddSingleton(service1DbContext);
            serviceCollection.AddSingleton(new Mock<S1.SQL.Persistence.Initialize.IDbInitializer>().Object);
            serviceCollection.AddScoped<IService2Service>(_ => new Service2Service(servicesOption, _service2Client));
            serviceCollection.AddScoped<IService3Service>(_ => new Service3Service(servicesOption, _service3Client));
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