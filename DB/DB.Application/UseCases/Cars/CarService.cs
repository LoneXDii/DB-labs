using AutoMapper;
using DB.Application.UseCases.Cars.DTO;
using DB.Domain.Abstractions;
using DB.Domain.Entities;
using MediatR;

namespace DB.Application.UseCases.Cars;

internal class CarService : ICarService
{
    private readonly IRepository<Car> _repository;
    private readonly IMapper _mapper;

    public CarService(IRepository<Car> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public List<Car> GetAll()
    {
        var cars = _repository.GetAll();

        return cars;
    }

    public Car GetById(int id)
    {
        var car = _repository.GetById(id);

        return car;
    }

    public void Add(AddCarDTO car)
    {
        var efCar = _mapper.Map<Car>(car);

        _repository.Add(efCar);
    }

    public void Update(UpdateCarDTO car)
    {
        var efCar = _mapper.Map<Car>(car);

        _repository.Update(efCar);
    }

    public void Delete(int id)
    {
        _repository.Delete(id);
    }
}
