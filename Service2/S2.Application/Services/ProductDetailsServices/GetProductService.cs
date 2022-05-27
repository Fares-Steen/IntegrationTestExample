using Mapster;
using Models.Models;
using S2.Application.IRepositories;
using S2.Domain.Exceptions;

namespace S2.Application.Services.ProductDetailsServices;

public class GetProductDetailsService : IGetProductDetailsService
{
    private readonly IUnitOfWork _unitOfWork;

    public GetProductDetailsService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ProductDetailsModel> GetByProductId(Guid productId)
    {
        var result = await _unitOfWork.ProductDetailsRepository.GetByProductId(productId);
       if(result == null)
        {
            throw new DomainNotFoundException($"There is no ProductDetails for productId=={productId}");
        }
        var productDetails = result.Adapt<ProductDetailsModel>();
        return productDetails;
    }

    public async Task<List<ProductDetailsModel>> GetAll()
    {
        var result = await _unitOfWork.ProductDetailsRepository.GetFullAll();
        var productDetailssList = result.Adapt<List<ProductDetailsModel>>();
        return productDetailssList;
    }


}