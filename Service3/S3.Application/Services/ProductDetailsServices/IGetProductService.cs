using Models.Models;

namespace S2.Application.Services.ProductDetailsServices;

public interface IGetUserService
{
    Task<List<UserModel>> GetAll();
}