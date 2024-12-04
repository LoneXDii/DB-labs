using DB.Application.UseCases.Cars.GetById;
using DB.Application.UseCases.Cars.ListCars;
using MediatR;
using DB.Application.UseCases.Cars.AddCar;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DB.Application.UseCases.Cars.UpdateCar;
using DB.Application.UseCases.Cars.DeleteCar;

namespace DB.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarsController : ControllerBase
{
    private readonly IMediator _mediator;

    public CarsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCars()
    {
        var cars = await _mediator.Send(new ListCarsRequest());

        return Ok(cars);
    }

    [HttpGet]
    [Route("id")]
    public async Task<IActionResult> GetById([FromQuery] GetCarByIdRequest request)
    {
        var car = await _mediator.Send(request);

        return Ok(car);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] AddCarRequest request)
    {
        await _mediator.Send(request);

        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCarRequest request)
    {
        await _mediator.Send(request);

        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromQuery] DeleteCarRequest request)
    {
        await _mediator.Send(request);

        return Ok();
    }
}
