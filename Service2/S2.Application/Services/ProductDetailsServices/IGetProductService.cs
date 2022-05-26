using Models.Models;

namespace S2.Application.Services.ProductDetailsServices;

public interface IGetProductDetailsService
{
    Task<List<ProductDetailsModel>> GetAll();
    Task<ProductDetailsModel> GetByProductId(Guid productId);
}