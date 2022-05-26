using System.Threading.Tasks;
using S3.Application.IRepositories;

namespace S3.SQL.Persistence.Repositories;

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