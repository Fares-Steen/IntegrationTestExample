using Mapster;
using Models.Models;
using S2.Application.IRepositories;

namespace S2.Application.Services.ProductDetailsServices;

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


}