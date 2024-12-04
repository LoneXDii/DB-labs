using DB.Application.UseCases.Brands.DTO;
using DB.Application.UseCases.Cars.DTO;
using DB.Domain.Entities;

namespace DB.Application.UseCases.Cars;

public interface ICarService
{
    Task<List<Car>> GetAllAsync();
    Task<Car> GetByIdAsync(int id);
	Task<List<Car>> GetByBrandAsync(int brandId);
	Task<List<Car>> GetByClassAsync(int classId);
	Task<List<Car>> GetByBodyTypeAsync(int bodyTypeId);
	Task AddAsync(AddCarDTO car);
    Task UpdateAsync(UpdateCarDTO car);
    Task DeleteAsync(int id);
}
