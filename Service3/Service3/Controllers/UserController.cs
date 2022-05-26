using Microsoft.AspNetCore.Mvc;
using Models.Models;
using S2.Application.Services.ProductDetailsServices;

namespace Service1.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IGetUserService _getUserService;
    private readonly ICreateUserService _createUserService;

    public UserController(IGetUserService getUserService, ICreateUserService createUserService)
    {
        _getUserService = getUserService;
        _createUserService = createUserService;
    }

    [HttpGet, Route("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var users = await _getUserService.GetAll();
        return Ok(users);
    }


    [HttpPost, Route("Create")]
    public async Task<IActionResult> Create(UserModel userModel)
    {
        var createdUserId=await _createUserService.Create(userModel);
        return Ok(createdUserId);
    }
}