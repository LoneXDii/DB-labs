using DB.Application.UseCases.BodyTypes.DTO;
using DB.Domain.Entities;

namespace DB.Application.UseCases.BodyTypes;

public interface ICarBodyTypeService
{
    List<CarBodyType> GetAll();
    CarBodyType GetById(int id);
    void Add(AddCarBodyTypeDTO bodyType);
    void Update(UpdateCarBodyTypeDTO bodyType);
    void Delete(int id);
}
