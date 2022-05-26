using S3.Application.IRepositories;

namespace S3.SQL.Persistence.Repositories;

public class UnitOfWork: IUnitOfWork
{
    public IUserRepository UserRepository { get; }
    private readonly Service3DbContext dbContext;
    public UnitOfWork(Service3DbContext dbContext)
    {
        this.dbContext = dbContext;
        UserRepository = new UserRepository(dbContext);
    }
    public async Task<int> Complete()
    {
       return await dbContext.SaveChangesAsync();
    }
}