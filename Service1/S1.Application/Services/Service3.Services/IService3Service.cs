using Models.Models;

namespace S1.Application.Services.Service3.Services;

public interface IService3Service
{
    Task<UserModel> GetUser(Guid productId);
}