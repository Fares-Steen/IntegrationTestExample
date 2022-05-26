using S1.Domain;

namespace S1.Application.IRepositories;

public interface IProductRepository: IGenericRepository<Product>
{
    Task<Product?> GetFullById(Guid id);
    Task<IEnumerable<Product>> GetFullAll();
    Task DeleteById(Guid id);
}