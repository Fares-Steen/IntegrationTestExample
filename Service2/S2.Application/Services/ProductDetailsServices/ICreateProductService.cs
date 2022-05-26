using Models.Models;

namespace S2.Application.Services.ProductDetailsServices;

public interface ICreateProductDetailsService
{
    Task<Guid> Create(ProductDetailsModel productDetailsModel);
}