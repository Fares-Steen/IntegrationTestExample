using Models.Models;

namespace S3.Application.Services.ProductDetailsServices;

public interface IGetUserService
{
    Task<List<UserModel>> GetAll();
    Task<UserModel> GetByProductId(Guid productId);
}