using DB.Application.UseCases.Classes.DTO;
using DB.Application.UseCases.Classes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace DB.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarClassesController : ControllerBase
{
    private readonly ICarClassService _carClassService;

    public CarClassesController(ICarClassService carClassService)
    {
        _carClassService = carClassService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var carClasses = await _carClassService.GetAllAsync();

        return Ok(carClasses);
    }

    [HttpGet]
    [Route("id")]
    public async Task<IActionResult> GetById([FromQuery] int id)
    {
        var carClass = await _carClassService.GetByIdAsync(id);

        return Ok(carClass);
    }

    [HttpPost]
    [Authorize(Policy = "Admin")]
    public async Task<IActionResult> Add([FromBody] AddCarClassDTO carClass)
    {
        await _carClassService.AddAsync(carClass);

        return Ok();
    }

    [HttpPut]
    [Authorize(Policy = "Admin")]
    public async Task<IActionResult> Update([FromBody] UpdateCarClassDTO carClass)
    {
        await _carClassService.UpdateAsync(carClass);

        return Ok();
    }

    [HttpDelete]
    [Authorize(Policy = "Admin")]
    public async Task<IActionResult> Delete([FromQuery] int id)
    {
        await _carClassService.DeleteAsync(id);

        return Ok();
    }
}
