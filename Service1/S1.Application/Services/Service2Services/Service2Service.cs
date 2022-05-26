using Microsoft.Extensions.Options;
using Models.Models;
using Newtonsoft.Json;

namespace S1.Application.Services.Service2Services;

public class Service2Service : IService2Service
{
    private readonly HttpClient _httpClientFactory;
    private readonly ServicesOption _servicesOption;
    
    public Service2Service(IOptions<ServicesOption> servicesOption, HttpClient httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
        _servicesOption = servicesOption.Value;
    }
    public async Task<ProductDetailsModel> GetProductDetails(Guid productId)
    {
        try
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                $"{_servicesOption.Service2ApiUrl}/ProductDetails?productId={productId}");

            var response = await _httpClientFactory.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<ProductDetailsModel>(result);
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