namespace S1.Application.IRepositories;

public interface IUnitOfWork
{
    IProductRepository ProductRepository { get; }
    Task<int> Complete();
}