using Models.Models;

namespace S1.Application.Services.Service2Services;

public interface IService2Service
{
    Task<ProductDetailsModel> GetProductDetails(Guid productId);
}