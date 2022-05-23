using Microsoft.AspNetCore.Mvc;

namespace Service3.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        var user = new User()
        {
            Id = 1,
            FirstName = "Test",
            LastName = "Testson"
        };
        return Ok(user);
    }
}