using Mapster;
using Models.Models;
using S2.Application.IRepositories;
using S2.Domain;
using S2.Domain.Entities;

namespace S2.Application.Services.ProductDetailsServices;

public class CreateProductDetailsService : ICreateProductDetailsService
{
    private readonly IUnitOfWork _unitOfWork;
    public CreateProductDetailsService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Guid> Create(ProductDetailsModel productDetailsModel)
    {
        var productDetails = productDetailsModel.Adapt<ProductDetails>();
        var createdProductDetails = await _unitOfWork.ProductDetailsRepository.Create(productDetails);
        await _unitOfWork.Complete();
        
        return createdProductDetails.Id;
    }
}