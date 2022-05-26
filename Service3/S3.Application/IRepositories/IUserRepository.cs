using S3.Domain.Entities;

namespace S3.Application.IRepositories;

public interface IUserRepository: IGenericRepository<User>
{
    Task<User?> GetByProductId(Guid id);
    Task<IEnumerable<User>> GetFullAll();
    Task DeleteById(Guid id);
}