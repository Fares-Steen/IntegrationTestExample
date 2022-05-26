using System.Threading.Tasks;

namespace S3.Application.IRepositories;

public interface IUnitOfWork
{
    IProductDetailsRepository ProductDetailsRepository { get; }
    Task<int> Complete();
}