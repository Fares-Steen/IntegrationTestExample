using Microsoft.Extensions.Options;

namespace Service1.Service2Services;

public class Service2Service : IService2Service
{
    private readonly IApiClientBase _apiClient;
    private readonly ServicesOption _servicesOption;

    public Service2Service(IApiClientBase apiClient,IOptions<ServicesOption> servicesOption)
    {
        _apiClient = apiClient;
        _servicesOption = servicesOption.Value;
    }
    
    public async Task<ProductDetails> GetProductDetails()
    {
        return await _apiClient.GetWithResponse<ProductDetails>( $"{_servicesOption.Service2ApiUrl}/ProductDetails");
    }
}