using S1.Application.IRepositories;

namespace S1.SQL.Persistence.Repositories;

public class UnitOfWork: IUnitOfWork
{
    public IProductRepository ProductRepository { get; }
    private readonly Service1DbContext dbContext;
    public UnitOfWork(Service1DbContext dbContext)
    {
        this.dbContext = dbContext;
        ProductRepository = new ProductRepository(dbContext);
    }
    public async Task<int> Complete()
    {
       return await dbContext.SaveChangesAsync();
    }
}