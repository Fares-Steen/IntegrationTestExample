using Mapster;
using Models.Models;
using S1.Application.IRepositories;
using S1.Domain;

namespace S1.Application.Services.ProductServices;

public class CreateProductService : ICreateProductService
{
    private readonly IUnitOfWork _unitOfWork;
    public CreateProductService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Guid> Create(ProductModel productModel)
    {
        var product = productModel.Adapt<Product>();
        var createdProduct = await _unitOfWork.ProductRepository.Create(product);
        await _unitOfWork.Complete();
        
        return createdProduct.Id;
    }
}