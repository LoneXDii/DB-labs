using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DB.Application.UseCases.Brands;
using DB.Application.UseCases.Brands.DTO;

namespace DB.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarBrandsController : ControllerBase
{
    private readonly ICarBrandService _brandService;

    public CarBrandsController(ICarBrandService brandService)
    {
        _brandService = brandService;
    }

    [HttpGet]
    public IActionResult GetAllCars()
    {
        var cars = _brandService.GetAll();

        return Ok(cars);
    }

    [HttpGet]
    [Route("id")]
    public IActionResult GetById([FromQuery] int id)
    {
        var car = _brandService.GetById(id);

        return Ok(car);
    }

    [HttpPost]
    public ActionResult Add([FromBody] AddCarBrandDTO brand)
    {
        _brandService.Add(brand);

        return Ok();
    }

    [HttpPut]
    public IActionResult Update([FromBody] UpdateCarBrandDTO brand)
    {
        _brandService.Update(brand);

        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromQuery] int id)
    {
        _brandService.Delete(id);

        return Ok();
    }
}
