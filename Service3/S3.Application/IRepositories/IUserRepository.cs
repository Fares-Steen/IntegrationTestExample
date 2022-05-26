using S2.Domain.Entities;

namespace S2.Application.IRepositories;

public interface IUserRepository: IGenericRepository<User>
{
    Task<User?> GetFullById(Guid id);
    Task<IEnumerable<User>> GetFullAll();
    Task DeleteById(Guid id);
}