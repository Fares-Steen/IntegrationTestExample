
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Service1.Service2Services;

public class ApiClientBase : IApiClientBase
{
    private readonly HttpClient _clientFactory;

    public ApiClientBase(HttpClient clientFactory)
    {
        _clientFactory = clientFactory;
    }
    public async Task<T> GetWithResponse<T>(string fullUrl)
    {
        try
        {

            var request = new HttpRequestMessage(HttpMethod.Post,
                fullUrl);
            
            var response = await _clientFactory.GetAsync(fullUrl);
            
            if (response.IsSuccessStatusCode)
            {
                var res = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<T>(res);
                return data;
            }

            throw new Exception("response was not success");

        }
        catch (Exception e)
        {
            throw new Exception($"{e.Message}+ the service api is :{fullUrl}");
        }

    }
}