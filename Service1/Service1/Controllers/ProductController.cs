using Microsoft.AspNetCore.Mvc;
using Service1.Service2Services;

namespace Service1.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly IService2Service _service2Service;
    private readonly IService3Service _service3Service;

    public ProductController(IService2Service service2Service, IService3Service service3Service)
    {
        _service2Service = service2Service;
        _service3Service = service3Service;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var productDetails = await _service2Service.GetProductDetails();
        var user = await _service3Service.GetUser();
        var products = new Product
        {
            Id = 1,
            Name = "Product 1",
            Description = "im a product"
        };

        var fullProduct = new FullProduct
        {
            User = user,
            Product = products,
            ProductDetails = productDetails
        };
        return Ok(fullProduct);
    }
}