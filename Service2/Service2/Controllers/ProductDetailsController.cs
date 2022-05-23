using Microsoft.AspNetCore.Mvc;

namespace Service2.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductDetailsController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        var productDetails = new ProductDetails
        {
            Id = 1,
            Size = 20,
            Price = 40,
            
        };
        return Ok(productDetails);
    }
}