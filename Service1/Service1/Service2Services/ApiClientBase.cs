
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Service1.Service2Services;

public class ApiClientBase : IApiClientBase
{
    private readonly HttpClient _clientFactory;
    private readonly ServicesOption _servicesOption;

    public ApiClientBase(HttpClient clientFactory,IOptions<ServicesOption> servicesOption)
    {
        _clientFactory = clientFactory;
        _servicesOption = servicesOption.Value;
    }
    public async Task<T> GetWithResponse<T>(string api)
    {
        var baseUrl = _servicesOption.Service2ApiUrl;
        try
        {
            var fullUrl = $"{baseUrl}/{api}";
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
            throw new Exception($"{e.Message}+ the service api is :{baseUrl}");
        }

    }
}