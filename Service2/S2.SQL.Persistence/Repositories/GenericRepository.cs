using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using S2.Application.IRepositories;
using S2.Domain.Entities.Interfaces;

namespace S2.SQL.Persistence.Repositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity>
    where TEntity : class, IEntity
{
    protected readonly Service2DbContext DbContext;

    protected GenericRepository(Service2DbContext dbContext)
    {
        this.DbContext = dbContext;
    }

    public async Task<TEntity> Create(TEntity entity)
    {
        await DbContext.Set<TEntity>().AddAsync(entity);
        return entity;
    }

    public void Delete(TEntity entity)
    {
        DbContext.Set<TEntity>().Remove(entity);
    }
    public async Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>>? filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, int first = 0, int offset = 0, params Expression<Func<TEntity, object>>[] includeProperties)
    {
        IQueryable<TEntity> query = DbContext.Set<TEntity>();

        if (orderBy != null)
        {
            query = orderBy(query);
        }
        if (filter != null)
        {
            query = query.Where(filter);
        }

        if (offset > 0)
        {
            query = query.Skip(offset);
        }
        if (first > 0)
        {
            query = query.Take(first);
        }

        foreach (var includeProperty in includeProperties)
        {
            query = query.Include(includeProperty.GetPropertyAccess().Name);
        }
        return await query.ToListAsync();

    }

    public async Task<IEnumerable<TEntity>> GetAll()
    {
        return await DbContext.Set<TEntity>().ToListAsync();
    }
    public async Task<TEntity> Get(Guid id)
    {
        return await DbContext.Set<TEntity>()
            .FirstAsync(e => e.Id == id);
    }

}