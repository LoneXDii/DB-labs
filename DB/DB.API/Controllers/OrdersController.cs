using DB.Application.UseCases.Orders;
using DB.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
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

	[HttpGet]
	[Route("user")]
	[Authorize(Policy = "Employee")]
	public async Task<IActionResult> GetByUserAsync()
	{
		var userId = HttpContext.User.FindFirst("Id").Value;

		var orders = await _orderService.GetByUserAsync(userId);

		return Ok(orders);
	}

	[HttpGet]
	[Route("user/id")]
	[Authorize(Policy = "Employee")]
	public async Task<IActionResult> GetByUserAsync([FromQuery] string userId)
	{
		var orders = await _orderService.GetByUserAsync(userId);

		return Ok(orders);
	}

	[HttpPost]
	[Authorize]
	public async Task<IActionResult> CreateOrder([FromBody] CreateOrder order)
	{
        var userId = HttpContext.User.FindFirst("Id").Value;
		order.UserId = userId;

        await _orderService.CreateOrderAsync(order);

		return Ok();
	}
}
