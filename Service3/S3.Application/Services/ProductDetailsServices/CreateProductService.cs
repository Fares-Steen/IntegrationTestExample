using System;
using System.Threading.Tasks;
using Mapster;
using Models.Models;
using S3.Application.IRepositories;
using S3.Domain;
using S3.Domain.Entities;

namespace S3.Application.Services.ProductDetailsServices;

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