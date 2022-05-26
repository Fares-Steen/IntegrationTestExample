using Models.Models;

namespace S2.Application.Services.ProductDetailsServices;

public interface ICreateUserService
{
    Task<Guid> Create(UserModel userModel);
}