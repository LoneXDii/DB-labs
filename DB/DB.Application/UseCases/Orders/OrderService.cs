using DB.Application.Exceptions;
using DB.Domain.Abstractions;
using DB.Domain.Entities;

namespace DB.Application.UseCases.Orders;

internal class OrderService : IOrderService
{
	private readonly IOrderRepository _repository;

	public OrderService(IOrderRepository repository)
	{
		_repository = repository;
	}

	public async Task<Order> GetByIdAsync(int id)
	{
		var order = await _repository.GetByIdAsync(id);

		return order;
	}

	public async Task<List<Order>> GetAllAsync()
	{
		var orders = await _repository.GetAllAsync();

		return orders;
	}

	public async Task<List<Order>> GetByUserAsync(string userId)
	{
		var orders = await _repository.FilterByStringAsync("user_id", userId);

		return orders;
	}

	public async Task CreateOrderAsync(CreateOrder order)
	{
		if (!order.CarsIds.Any())
		{
			throw new BadRequestException("Cannot create empty order");
		}

		await _repository.AddAsync(order);
	}
}
