using System.Net.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Service1.Service2Services;

public class Service3Service : IService3Service
{
    private readonly HttpClient _httpClientFactory;
    private readonly ServicesOption _servicesOption;
    
    public Service3Service(IOptions<ServicesOption> servicesOption, HttpClient httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
        _servicesOption = servicesOption.Value;
    }
    
    public async Task<User> GetUser()
    {
        try
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                $"{_servicesOption.Service3ApiUrl}/user");

            var response = await _httpClientFactory.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var res = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<User>(res);
                return data;
            }

            throw new Exception("response was not success");
        }
        catch (Exception e)
        {
            throw new Exception($"{e.Message}");
        }
    }
}