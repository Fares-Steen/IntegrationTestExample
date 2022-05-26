namespace S2.Application.IRepositories;

public interface IUnitOfWork
{
    IProductDetailsRepository ProductDetailsRepository { get; }
    Task<int> Complete();
}