using Mapster;
using Models.Models;
using S1.Application.IRepositories;
using S1.Application.Services.Service2Services;
using S1.Application.Services.Service3.Services;
using S1.Domain.Exceptions;

namespace S1.Application.Services.ProductServices;

public class GetProductService : IGetProductService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IService2Service _service2Service;
    private readonly IService3Service _service3Service;

    public GetProductService(IUnitOfWork unitOfWork, IService2Service service2Service, IService3Service service3Service)
    {
        _unitOfWork = unitOfWork;
        _service2Service = service2Service;
        _service3Service = service3Service;
    }
    
    public async Task<List<ProductModel>> GetAll()
    {
        var result = await _unitOfWork.ProductRepository.GetFullAll();
        var productsList = result.Adapt<List<ProductModel>>();
        return productsList;
    }

    public async Task<FullProductModel> GetFull(Guid productId)
    {
        var result = await _unitOfWork.ProductRepository.Get(productId);
        if(result == null)
        {
            throw new DomainNotFoundException($"There is no product with productId=={productId}");
        }

        var product = result.Adapt<ProductModel>();

        var service2Task = _service2Service.GetProductDetails(productId);
        var service3Task = _service3Service.GetUser(productId);
        Task.WaitAll(service2Task, service3Task);
        var service2Result = service2Task.Result;
        var service3Result = service3Task.Result;
        
        var fullProduct = new FullProductModel
        {
            ProductModel = product,
            ProductDetailsModel = service2Result,
            UserModel = service3Result
        };
        return fullProduct;
    }
}