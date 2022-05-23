using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Service1;


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
            serviceCollection.Configure<ServicesOption>(options =>
            {
                options.Service2ApiUrl = "";
            });
            serviceCollection.AddSingleton(_service2Client);
        });

        return base.CreateHost(builder);
    }
}