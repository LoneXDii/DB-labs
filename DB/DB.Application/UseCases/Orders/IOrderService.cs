using DB.Domain.Abstractions;
using DB.Domain.Entities;

namespace DB.Application.UseCases.Orders;

public interface IOrderService
{
	Task<Order> GetByIdAsync(int id);
}
