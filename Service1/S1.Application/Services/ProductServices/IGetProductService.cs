using Models.Models;

namespace S1.Application.Services.ProductServices;

public interface IGetProductService
{
    Task<List<ProductModel>> GetAll();
    Task<FullProductModel> GetFull(Guid id);
}