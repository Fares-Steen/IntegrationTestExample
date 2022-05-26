using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using S3.Domain;
using S3.Domain.Entities;

namespace S3.Application.IRepositories;

public interface IProductDetailsRepository: IGenericRepository<ProductDetails>
{
    Task<ProductDetails?> GetFullById(Guid id);
    Task<IEnumerable<ProductDetails>> GetFullAll();
    Task DeleteById(Guid id);
}