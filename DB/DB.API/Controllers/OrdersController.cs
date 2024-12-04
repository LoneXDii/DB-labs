using DB.Application.UseCases.Orders;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DB.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
	private readonly IOrderService _orderService;

	public OrdersController(IOrderService orderService)
	{
		_orderService = orderService;
	}

	[HttpGet]
	public async Task<IActionResult> GetAll()
	{
		var orders = await _orderService.GetAllAsync();

		return Ok(orders);
	}

	[HttpGet]
	[Route("id")]
	public async Task<IActionResult> GetById([FromQuery] int id)
	{
		var order = await _orderService.GetByIdAsync(id);

		return Ok(order);
	}
}
