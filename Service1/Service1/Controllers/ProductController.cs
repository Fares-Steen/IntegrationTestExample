using Microsoft.AspNetCore.Mvc;
using Models.Models;
using S1.Application.Services.ProductServices;
namespace Service1.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly IGetProductService _getProductService;
    private readonly ICreateProductService _createProductService;

    public ProductController(IGetProductService getProductService, ICreateProductService createProductService)
    {
        _getProductService = getProductService;
        _createProductService = createProductService;
    }

    [HttpGet, Route("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var products = await _getProductService.GetAll();
        return Ok(products);
    }
    
    [HttpGet, Route("GetFull")]
    public async Task<IActionResult> GetFull(Guid id)
    {
        var product = await _getProductService.GetFull(id);
        return Ok(product);
    }
    
    
    [HttpPost, Route("Create")]
    public async Task<IActionResult> Create(ProductModel productModel)
    {
        var createdProductId=await _createProductService.Create(productModel);
        return Ok(createdProductId);
    }
}