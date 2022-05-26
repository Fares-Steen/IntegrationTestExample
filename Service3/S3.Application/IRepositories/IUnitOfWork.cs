namespace S3.Application.IRepositories;

public interface IUnitOfWork
{
    IUserRepository UserRepository { get; }
    Task<int> Complete();
}