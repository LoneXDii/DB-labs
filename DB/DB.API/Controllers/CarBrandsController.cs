using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DB.Application.UseCases.Brands;
using DB.Application.UseCases.Brands.DTO;
using Microsoft.AspNetCore.Authorization;

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
    public async Task<IActionResult> GetAllCars()
    {
        var cars = await _brandService.GetAllAsync();

        return Ok(cars);
    }

    [HttpGet]
    [Route("id")]
    public async Task<IActionResult> GetById([FromQuery] int id)
    {
        var car = await _brandService.GetByIdAsync(id);

        return Ok(car);
    }

    [HttpPost]
    [Authorize(Policy = "Admin")]
    public async Task<IActionResult> Add([FromBody] AddCarBrandDTO brand)
    {
        await _brandService.AddAsync(brand);

        return Ok();
    }

    [HttpPut]
    [Authorize(Policy = "Admin")]
    public async Task<IActionResult> Update([FromBody] UpdateCarBrandDTO brand)
    {
        await _brandService.UpdateAsync(brand);

        return Ok();
    }

    [HttpDelete]
    [Authorize(Policy = "Admin")]
    public async Task<IActionResult> Delete([FromQuery] int id)
    {
        await _brandService.DeleteAsync(id);

        return Ok();
    }
}
