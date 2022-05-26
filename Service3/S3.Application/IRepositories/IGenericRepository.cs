using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using S3.Domain.Entities.Interfaces;

namespace S3.Application.IRepositories;

public interface IGenericRepository<TEntity>
    where TEntity : class, IEntity
{

    Task<IEnumerable<TEntity>> Get(
        Expression<Func<TEntity, bool>>? filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        int first = 0, int offset = 0, params Expression<Func<TEntity, object>>[] includeProperties);
    Task<TEntity> Get(Guid id);

    Task<TEntity> Create(TEntity entity);

    void Delete(TEntity entity);
    Task<IEnumerable<TEntity>> GetAll();
}