using System.Collections.Generic;
using System.Threading.Tasks;
using Models.Models;

namespace S3.Application.Services.ProductDetailsServices;

public interface IGetProductDetailsService
{
    Task<List<ProductDetailsModel>> GetAll();
}