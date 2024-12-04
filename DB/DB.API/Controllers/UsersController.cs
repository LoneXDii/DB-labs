using DB.Application.UseCases.Users;
using DB.Application.UseCases.Users.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DB.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login([FromBody] LoginDTO user)
    {
        var token = await _userService.LoginAsync(user);

        return Ok(token);
    }

    [HttpGet]
    [Route("base")]
    [Authorize]
    public IActionResult TestBase() {
        return Ok();
    }

    [HttpGet]
    [Route("employee")]
    [Authorize(Policy = "Employee")]
    public IActionResult TestEmployee()
    {
        return Ok();
    }

    [HttpGet]
    [Route("admin")]
    [Authorize(Policy = "Admin")]
    public IActionResult TestAdmin()
    {
        return Ok();
    }
}
