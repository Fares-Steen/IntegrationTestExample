using Models.Models;

namespace S3.Application.Services.ProductDetailsServices;

public interface ICreateUserService
{
    Task<Guid> Create(UserModel userModel);
}