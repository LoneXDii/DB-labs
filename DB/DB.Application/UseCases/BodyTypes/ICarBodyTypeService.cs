using DB.Application.UseCases.BodyTypes.DTO;
using DB.Domain.Entities;

namespace DB.Application.UseCases.BodyTypes;

public interface ICarBodyTypeService
{
	Task<List<CarBodyType>> GetAllAsync();
	Task<CarBodyType> GetByIdAsync(int id);
	Task AddAsync(AddCarBodyTypeDTO bodyType);
	Task UpdateAsync(UpdateCarBodyTypeDTO bodyType);
    Task DeleteAsync(int id);
}
