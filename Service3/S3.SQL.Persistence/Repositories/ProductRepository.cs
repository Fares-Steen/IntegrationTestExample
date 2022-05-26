using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using S3.Application.IRepositories;
using S3.Domain;
using S3.Domain.Entities;
using S3.Domain.Exceptions;

namespace S3.SQL.Persistence.Repositories;

public class ProductDetailsRepository : GenericRepository<ProductDetails>, IProductDetailsRepository

{
    public ProductDetailsRepository(Service2DbContext dbContext) : base(dbContext)
    {
    }

    public async Task<ProductDetails?> GetFullById(Guid id)
    {
        var result = await DbContext.Set<ProductDetails>()
            .Where(p => p.Id == id)
            .OrderBy(p => p.DateAdded)
            .AsNoTracking().AsSplitQuery().FirstAsync();

        return result;
    }

    public async Task<IEnumerable<ProductDetails>> GetFullAll()
    {
        var result = await DbContext.Set<ProductDetails>()
            .OrderBy(p => p.DateAdded)
            .AsNoTracking().AsSplitQuery().ToListAsync();
        return result;
    }

    public async Task DeleteById(Guid id)
    {
        var entity = await DbContext.Set<ProductDetails>().FirstOrDefaultAsync(e => e.Id == id);
        if (entity != null)
        {
            Delete(entity);
            return;
        }

        throw new DomainNotFoundException($"there is no productDetails with id {id}");
    }
}