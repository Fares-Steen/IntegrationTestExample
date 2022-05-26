using Mapster;
using Models.Models;
using S1.Application.IRepositories;

namespace S1.Application.Services.ProductServices;

public class GetProductService : IGetProductService
{
    private readonly IUnitOfWork unitOfWork;

    public GetProductService(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }
    
    public async Task<List<ProductModel>> GetFullAll()
    {
        var result = await unitOfWork.ProductRepository.GetFullAll();
        var productsList = result.Adapt<List<ProductModel>>();
        return productsList;
    }
}