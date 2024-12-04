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

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDTO user)
    {
        await _userService.RegisterAsync(user);

        return Ok();
    }

    [HttpGet]
    [Route("user")]
    [Authorize]
    public async Task<IActionResult> GetUserInfo()
    {
        var id = HttpContext.User.FindFirst("Id")?.Value;

        var user = await _userService.GetByIdAsync(id);

        return Ok(user);
    }

    [HttpGet]
    [Authorize(Policy = "Employee")]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _userService.GetAllUsersAsync();

        return Ok(users);
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
