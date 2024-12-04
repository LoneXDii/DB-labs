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

    public List<CarClass> GetAll()
    {
        var carClasses = _repository.GetAll();
        return carClasses;
    }

    public CarClass GetById(int id)
    {
        var carClass = _repository.GetById(id);
        return carClass;
    }

    public void Add(AddCarClassDTO carClass)
    {
        var efCarClass = _mapper.Map<CarClass>(carClass);
        _repository.Add(efCarClass);
    }

    public void Update(UpdateCarClassDTO carClass)
    {
        var efCarClass = _mapper.Map<CarClass>(carClass);
        _repository.Update(efCarClass);
    }

    public void Delete(int id)
    {
        _repository.Delete(id);
    }
}
