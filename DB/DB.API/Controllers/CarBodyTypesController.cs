using DB.Application.UseCases.BodyTypes.DTO;
using DB.Application.UseCases.BodyTypes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DB.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarBodyTypesController : ControllerBase
{
    private readonly ICarBodyTypeService _carBodyTypeService;

    public CarBodyTypesController(ICarBodyTypeService carBodyTypeService)
    {
        _carBodyTypeService = carBodyTypeService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var bodyTypes = _carBodyTypeService.GetAll();
        return Ok(bodyTypes);
    }

    [HttpGet]
    [Route("id")]
    public IActionResult GetById([FromQuery] int id)
    {
        var bodyType = _carBodyTypeService.GetById(id);
        return Ok(bodyType);
    }

    [HttpPost]
    public ActionResult Add([FromBody] AddCarBodyTypeDTO bodyType)
    {
        _carBodyTypeService.Add(bodyType);
        return Ok();
    }

    [HttpPut]
    public IActionResult Update([FromBody] UpdateCarBodyTypeDTO bodyType)
    {
        _carBodyTypeService.Update(bodyType);
        return Ok();
    }

    [HttpDelete]
    public IActionResult Delete([FromQuery] int id)
    {
        _carBodyTypeService.Delete(id);
        return Ok();
    }
}
