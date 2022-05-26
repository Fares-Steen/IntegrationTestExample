using S2.Domain;
using S2.Domain.Entities;

namespace S2.Application.IRepositories;

public interface IProductDetailsRepository: IGenericRepository<ProductDetails>
{
    Task<ProductDetails?> GetFullById(Guid id);
    Task<IEnumerable<ProductDetails>> GetFullAll();
    Task DeleteById(Guid id);
}