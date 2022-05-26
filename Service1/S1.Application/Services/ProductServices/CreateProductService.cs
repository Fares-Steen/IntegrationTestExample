using Mapster;
using Models.Models;
using S1.Application.IRepositories;
using S1.Domain;

namespace S1.Application.Services.ProductServices;

public class CreateProductService : ICreateProductService
{
    private readonly IUnitOfWork unitOfWork;
    public CreateProductService(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }
    
    public async Task Create(ProductModel productModel)
    {
        var product = productModel.Adapt<Product>();
        await unitOfWork.ProductRepository.Create(product);
        await unitOfWork.Complete();
    }
}