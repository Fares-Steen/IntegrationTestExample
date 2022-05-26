using Microsoft.AspNetCore.Mvc;
using Models.Models;
using S2.Application.Services.ProductDetailsServices;
namespace Service2.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductDetailsController : ControllerBase
{
    private readonly IGetProductDetailsService _getProductDetailsService;
    private readonly ICreateProductDetailsService _createProductDetailsService;

    public ProductDetailsController(IGetProductDetailsService getProductDetailsService, ICreateProductDetailsService createProductDetailsService)
    {
        _getProductDetailsService = getProductDetailsService;
        _createProductDetailsService = createProductDetailsService;
    }

    [HttpGet, Route("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var productDetailss = await _getProductDetailsService.GetAll();
        return Ok(productDetailss);
    }


    [HttpPost, Route("Create")]
    public async Task<IActionResult> Create(ProductDetailsModel productDetailsModel)
    {
        var createdProductDetailsId=await _createProductDetailsService.Create(productDetailsModel);
        return Ok(createdProductDetailsId);
    }


    [HttpGet, Route("GetByProductId")]
    public async Task<IActionResult> GetByProductId(Guid productId)
    {
        var productDetailss = await _getProductDetailsService.GetByProductId(productId);
        return Ok(productDetailss);
    }
}