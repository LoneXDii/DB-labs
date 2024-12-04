using AutoMapper;
using DB.Application.UseCases.Classes.DTO;
using DB.Domain.Abstractions;
using DB.Domain.Entities;

namespace DB.Application.UseCases.Classes;

internal class CarClassService : ICarClassService
{
    private readonly IRepository<CarClass> _repository;
    private readonly IMapper _mapper;

    public CarClassService(IRepository<CarClass> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<CarClass>> GetAllAsync()
    {
        var carClasses = await _repository.GetAllAsync();

        return carClasses;
    }

    public async Task<CarClass> GetByIdAsync(int id)
    {
        var carClass = await _repository.GetByIdAsync(id);

        return carClass;
    }

    public async Task AddAsync(AddCarClassDTO carClass)
    {
        var efCarClass = _mapper.Map<CarClass>(carClass);

        await _repository.AddAsync(efCarClass);
    }

    public async Task UpdateAsync(UpdateCarClassDTO carClass)
    {
        var efCarClass = _mapper.Map<CarClass>(carClass);

        await _repository.UpdateAsync(efCarClass);
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }
}
