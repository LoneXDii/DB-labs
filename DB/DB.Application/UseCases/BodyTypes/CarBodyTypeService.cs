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

    public List<CarBodyType> GetAll()
    {
        var bodyTypes = _repository.GetAll();
        return bodyTypes;
    }

    public CarBodyType GetById(int id)
    {
        var bodyType = _repository.GetById(id);
        return bodyType;
    }

    public void Add(AddCarBodyTypeDTO bodyType)
    {
        var efBodyType = _mapper.Map<CarBodyType>(bodyType);
        _repository.Add(efBodyType);
    }

    public void Update(UpdateCarBodyTypeDTO bodyType)
    {
        var efBodyType = _mapper.Map<CarBodyType>(bodyType);
        _repository.Update(efBodyType);
    }

    public void Delete(int id)
    {
        _repository.Delete(id);
    }
}
