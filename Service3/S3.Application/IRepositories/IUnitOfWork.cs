namespace S2.Application.IRepositories;

public interface IUnitOfWork
{
    IUserRepository UserRepository { get; }
    Task<int> Complete();
}