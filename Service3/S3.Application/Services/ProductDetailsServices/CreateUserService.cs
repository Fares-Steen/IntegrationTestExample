using Mapster;
using Models.Models;
using S2.Application.IRepositories;
using S2.Domain.Entities;

namespace S2.Application.Services.ProductDetailsServices;

public class CreateUserService : ICreateUserService
{
    private readonly IUnitOfWork _unitOfWork;
    public CreateUserService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Guid> Create(UserModel userModel)
    {
        var user = userModel.Adapt<User>();
        var createdUser = await _unitOfWork.UserRepository.Create(user);
        await _unitOfWork.Complete();
        
        return createdUser.Id;
    }
}