using DB.Application.UseCases.Classes.DTO;
using DB.Domain.Entities;

namespace DB.Application.UseCases.Classes;

public interface ICarClassService
{
    Task<List<CarClass>> GetAllAsync();
    Task<CarClass> GetByIdAsync(int id);
    Task AddAsync(AddCarClassDTO carClass);
    Task UpdateAsync(UpdateCarClassDTO carClass);
    Task DeleteAsync(int id);
}
