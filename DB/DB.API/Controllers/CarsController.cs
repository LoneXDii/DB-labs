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
    public IActionResult GetAllCars()
    {
        var cars = _carService.GetAll();

        return Ok(cars);
    }

    [HttpGet]
    [Route("id")]
    public IActionResult GetById([FromQuery] int id)
    {
        var car = _carService.GetById(id);

        return Ok(car);
    }

    [HttpPost]
    public ActionResult Add([FromBody] AddCarDTO car)
    {
        _carService.Add(car);

        return Ok();
    }

    [HttpPut]
    public IActionResult Update([FromBody] UpdateCarDTO car)
    {
        _carService.Update(car);

        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromQuery] int id)
    {
        _carService.Delete(id);

        return Ok();
    }
}
