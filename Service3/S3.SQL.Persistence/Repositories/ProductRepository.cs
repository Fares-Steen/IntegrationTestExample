using Microsoft.EntityFrameworkCore;
using S3.Application.IRepositories;
using S3.Domain.Entities;
using S3.Domain.Exceptions;

namespace S3.SQL.Persistence.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository

{
    public UserRepository(Service3DbContext dbContext) : base(dbContext)
    {
    }

    public async Task<User?> GetByProductId(Guid id)
    {
        var result = await DbContext.Set<User>()
            .Where(p => p.ProductId == id)
            .AsNoTracking().AsSplitQuery().FirstOrDefaultAsync();

        return result;
    }

    public async Task<IEnumerable<User>> GetFullAll()
    {
        var result = await DbContext.Set<User>()
            .OrderBy(p => p.DateAdded)
            .AsNoTracking().AsSplitQuery().ToListAsync();
        return result;
    }

    public async Task DeleteById(Guid id)
    {
        var entity = await DbContext.Set<User>().FirstOrDefaultAsync(e => e.Id == id);
        if (entity != null)
        {
            Delete(entity);
            return;
        }

        throw new DomainNotFoundException($"there is no user with id {id}");
    }
}