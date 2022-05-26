using Microsoft.EntityFrameworkCore;
using S2.Application.IRepositories;
using S2.Domain.Entities;
using S2.Domain.Exceptions;

namespace S2.SQL.Persistence.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository

{
    public UserRepository(Service3DbContext dbContext) : base(dbContext)
    {
    }

    public async Task<User?> GetFullById(Guid id)
    {
        var result = await DbContext.Set<User>()
            .Where(p => p.Id == id)
            .OrderBy(p => p.DateAdded)
            .AsNoTracking().AsSplitQuery().FirstAsync();

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