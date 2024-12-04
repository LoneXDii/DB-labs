using DB.Application.UseCases.Classes.DTO;
using DB.Application.UseCases.Classes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    public IActionResult GetAll()
    {
        var carClasses = _carClassService.GetAll();
        return Ok(carClasses);
    }

    [HttpGet]
    [Route("id")]
    public IActionResult GetById([FromQuery] int id)
    {
        var carClass = _carClassService.GetById(id);
        return Ok(carClass);
    }

    [HttpPost]
    public ActionResult Add([FromBody] AddCarClassDTO carClass)
    {
        _carClassService.Add(carClass);
        return Ok();
    }

    [HttpPut]
    public IActionResult Update([FromBody] UpdateCarClassDTO carClass)
    {
        _carClassService.Update(carClass);
        return Ok();
    }

    [HttpDelete]
    public IActionResult Delete([FromQuery] int id)
    {
        _carClassService.Delete(id);
        return Ok();
    }
}
