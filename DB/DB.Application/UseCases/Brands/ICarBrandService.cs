using DB.Application.UseCases.Brands.DTO;
using DB.Domain.Entities;

namespace DB.Application.UseCases.Brands;

public interface ICarBrandService
{
    List<CarBrand> GetAll();
    CarBrand GetById(int id);
    void Add(AddCarBrandDTO car);
    void Update(UpdateCarBrandDTO car);
    void Delete(int id);
}
