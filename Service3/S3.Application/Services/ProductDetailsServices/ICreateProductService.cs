using System;
using System.Threading.Tasks;
using Models.Models;

namespace S3.Application.Services.ProductDetailsServices;

public interface ICreateProductDetailsService
{
    Task<Guid> Create(ProductDetailsModel productDetailsModel);
}