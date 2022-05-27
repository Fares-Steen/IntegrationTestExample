using Mapster;
using Models.Models;
using S3.Application.IRepositories;
using S3.Domain.Exceptions;

namespace S3.Application.Services.ProductDetailsServices;

public class GetUserService : IGetUserService
{
    private readonly IUnitOfWork _unitOfWork;

    public GetUserService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<List<UserModel>> GetAll()
    {
        var result = await _unitOfWork.UserRepository.GetFullAll();
        var usersList = result.Adapt<List<UserModel>>();
        return usersList;
    }

    public async Task<UserModel> GetByProductId(Guid productId)
    {
        var result = await _unitOfWork.UserRepository.GetByProductId(productId);
        if(result == null)
        {
            throw new DomainNotFoundException($"There is no user with productId=={productId}");
        }
        var usersList = result.Adapt<UserModel>();
        return usersList;
    }
}