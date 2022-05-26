using System.Collections.Generic;
using System.Threading.Tasks;
using Mapster;
using Models.Models;
using S3.Application.IRepositories;

namespace S3.Application.Services.ProductDetailsServices;

public class GetProductDetailsService : IGetProductDetailsService
{
    private readonly IUnitOfWork _unitOfWork;

    public GetProductDetailsService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<List<ProductDetailsModel>> GetAll()
    {
        var result = await _unitOfWork.ProductDetailsRepository.GetFullAll();
        var productDetailssList = result.Adapt<List<ProductDetailsModel>>();
        return productDetailssList;
    }


}