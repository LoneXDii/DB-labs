using DB.Application.UseCases.Brands.DTO;
using DB.Application.UseCases.Cars.DTO;
using DB.Domain.Entities;

namespace DB.Application.UseCases.Cars;

public interface ICarService
{
    List<Car> GetAll();
    Car GetById(int id);
    void Add(AddCarDTO car);
    void Update(UpdateCarDTO car);
    void Delete(int id);
}
