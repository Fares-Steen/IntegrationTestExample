using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;

namespace IntegrationTests;

internal class SetUpTestEnvironment : WebApplicationFactory<Program>
{
    internal readonly HttpClient TestClient;

    public SetUpTestEnvironment()
    {
        TestClient = CreateClient();
    }
}