using DB.Application.UseCases.Brands.DTO;
using DB.Domain.Entities;

namespace DB.Application.UseCases.Brands;

public interface ICarBrandService
{
    Task<List<CarBrand>> GetAllAsync();
    Task<CarBrand> GetByIdAsync(int id);
    Task AddAsync(AddCarBrandDTO car);
    Task UpdateAsync(UpdateCarBrandDTO car);
    Task DeleteAsync(int id);
}
