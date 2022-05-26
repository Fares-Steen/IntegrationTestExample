using S2.Application.IRepositories;

namespace S2.SQL.Persistence.Repositories;

public class UnitOfWork: IUnitOfWork
{
    public IProductDetailsRepository ProductDetailsRepository { get; }
    private readonly Service2DbContext dbContext;
    public UnitOfWork(Service2DbContext dbContext)
    {
        this.dbContext = dbContext;
        ProductDetailsRepository = new ProductDetailsRepository(dbContext);
    }
    public async Task<int> Complete()
    {
       return await dbContext.SaveChangesAsync();
    }
}