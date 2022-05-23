namespace Service1.Service2Services;

public class Service2Service : IService2Service
{
    private readonly IApiClientBase _apiClient;

    public Service2Service(IApiClientBase apiClient)
    {
        _apiClient = apiClient;
    }
    
    public async Task<ProductDetails> GetProductDetails()
    {
        return await _apiClient.GetWithResponse<ProductDetails>("ProductDetails");
    }
}