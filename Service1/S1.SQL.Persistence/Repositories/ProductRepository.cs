using Microsoft.EntityFrameworkCore;
using S1.Application.IRepositories;
using S1.Domain;
using S1.Domain.Exceptions;

namespace S1.SQL.Persistence.Repositories;

public class ProductRepository : GenericRepository<Product>, IProductRepository

{
    public ProductRepository(Service1DbContext dbContext) : base(dbContext)
    {
    }

    public async Task<Product?> GetFullById(Guid id)
    {
        var result = await DbContext.Set<Product>()
            .Where(p => p.Id == id)
            .OrderBy(p => p.DateAdded)
            .AsNoTracking().AsSplitQuery().FirstAsync();

        return result;
    }

    public async Task<IEnumerable<Product>> GetFullAll()
    {
        var result = await DbContext.Set<Product>()
            .OrderBy(p => p.DateAdded)
            .AsNoTracking().AsSplitQuery().ToListAsync();
        return result;
    }

    public async Task DeleteById(Guid id)
    {
        var entity = await DbContext.Set<Product>().FirstOrDefaultAsync(e => e.Id == id);
        if (entity != null)
        {
            Delete(entity);
            return;
        }

        throw new DomainNotFoundException($"there is no product with id {id}");
    }
}