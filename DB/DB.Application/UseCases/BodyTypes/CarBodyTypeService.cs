using AutoMapper;
using DB.Application.UseCases.BodyTypes.DTO;
using DB.Domain.Abstractions;
using DB.Domain.Entities;

namespace DB.Application.UseCases.BodyTypes;

internal class CarBodyTypeService : ICarBodyTypeService
{
    private readonly IRepository<CarBodyType> _repository;
    private readonly IMapper _mapper;

    public CarBodyTypeService(IRepository<CarBodyType> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<CarBodyType>> GetAllAsync()
    {
        var bodyTypes = await _repository.GetAllAsync();

        return bodyTypes;
    }

    public async Task<CarBodyType> GetByIdAsync(int id)
    {
        var bodyType = await _repository.GetByIdAsync(id);

        return bodyType;
    }

    public async Task AddAsync(AddCarBodyTypeDTO bodyType)
    {
        var efBodyType = _mapper.Map<CarBodyType>(bodyType);

        await _repository.AddAsync(efBodyType);
    }

    public async Task UpdateAsync(UpdateCarBodyTypeDTO bodyType)
    {
        var efBodyType = _mapper.Map<CarBodyType>(bodyType);

        await _repository.UpdateAsync(efBodyType);
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }
}
