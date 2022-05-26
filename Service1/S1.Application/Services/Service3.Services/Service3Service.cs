using Microsoft.Extensions.Options;
using Models.Models;
using Newtonsoft.Json;

namespace S1.Application.Services.Service3.Services;

public class Service3Service : IService3Service
{
    private readonly HttpClient _httpClientFactory;
    private readonly ServicesOption _servicesOption;
    
    public Service3Service(IOptions<ServicesOption> servicesOption, HttpClient httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
        _servicesOption = servicesOption.Value;
    }
    
    public async Task<UserModel> GetUser(Guid productId)
    {
        try
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                $"{_servicesOption.Service3ApiUrl}/user/GetByProductId?productId={productId}");

            var response = await _httpClientFactory.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var res = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<UserModel>(res);
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