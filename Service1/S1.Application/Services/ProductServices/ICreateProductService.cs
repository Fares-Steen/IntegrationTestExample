using Models.Models;

namespace S1.Application.Services.ProductServices;

public interface ICreateProductService
{
    Task<Guid> Create(ProductModel productModel);
}