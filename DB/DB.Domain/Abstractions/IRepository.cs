using DB.Domain.Entities;
using System.Threading.Tasks;

namespace DB.Domain.Abstractions;

public interface IRepository<T>
{
    Task<List<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(int id);
    Task<List<T>> FilterByNumberAsync(string column, int value);
    Task<List<T>> FilterByStringAsync(string column, string value);
}
