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
    public async Task<IActionResult> GetAll()
    {
        var bodyTypes = await _carBodyTypeService.GetAllAsync();

        return Ok(bodyTypes);
    }

    [HttpGet]
    [Route("id")]
    public async Task<IActionResult> GetById([FromQuery] int id)
    {
        var bodyType = await _carBodyTypeService.GetByIdAsync(id);

        return Ok(bodyType);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] AddCarBodyTypeDTO bodyType)
    {
		await _carBodyTypeService.AddAsync(bodyType);

        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCarBodyTypeDTO bodyType)
    {
		await _carBodyTypeService.UpdateAsync(bodyType);

        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromQuery] int id)
    {
        await _carBodyTypeService.DeleteAsync(id);

        return Ok();
    }
}
