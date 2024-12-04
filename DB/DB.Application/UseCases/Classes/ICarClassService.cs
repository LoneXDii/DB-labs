using DB.Application.UseCases.Classes.DTO;
using DB.Domain.Entities;

namespace DB.Application.UseCases.Classes;

public interface ICarClassService
{
    List<CarClass> GetAll();
    CarClass GetById(int id);
    void Add(AddCarClassDTO carClass);
    void Update(UpdateCarClassDTO carClass);
    void Delete(int id);
}
