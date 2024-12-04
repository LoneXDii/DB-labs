using DB.Application.UseCases.Cars;
using DB.Application.UseCases.Cars.DTO;
using DB.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DB.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarsController : ControllerBase
{
    private readonly ICarService _carService;

    public CarsController(ICarService carService)
    {
        _carService = carService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCars()
    {
        var cars = await _carService.GetAllAsync();

        return Ok(cars);
    }

    [HttpGet]
    [Route("id")]
    public async Task<IActionResult> GetById([FromQuery] int id)
    {
        var car = await _carService.GetByIdAsync(id);

        return Ok(car);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] AddCarDTO car)
    {
		await _carService.AddAsync(car);

        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCarDTO car)
    {
		await _carService.UpdateAsync(car);

        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromQuery] int id)
    {
        await _carService.DeleteAsync(id);

        return Ok();
    }
}
