using DB.Domain.Entities;

namespace DB.Domain.Abstractions;

public interface IOrderRepository
{
    Task<Order> GetByIdAsync(int id);
    Task<List<Order>> GetAllAsync();
    Task AddAsync(CreateOrder entity);
    Task UpdateAsync(Order entity);
    Task DeleteAsync(int id);
    Task<List<Order>> FilterByStringAsync(string column, string value);
}
