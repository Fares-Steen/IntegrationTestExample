using System.Net.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Service1.Service2Services;

public class Service2Service : IService2Service
{
    private readonly HttpClient _httpClientFactory;
    private readonly ServicesOption _servicesOption;
    
    public Service2Service(IOptions<ServicesOption> servicesOption, HttpClient httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
        _servicesOption = servicesOption.Value;
    }
    
    public async Task<ProductDetails> GetProductDetails()
    {
        try
        {
        var request = new HttpRequestMessage(HttpMethod.Get,
            $"{_servicesOption.Service2ApiUrl}/ProductDetails");

        var response = await _httpClientFactory.SendAsync(request);
        if (response.IsSuccessStatusCode)
        {
            var res = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<ProductDetails>(res);
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