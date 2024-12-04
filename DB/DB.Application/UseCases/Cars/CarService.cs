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

    public async Task<List<Car>> GetAllAsync()
    {
        var cars = await _repository.GetAllAsync();

        return cars;
    }

    public async Task<Car> GetByIdAsync(int id)
    {
        var car = await _repository.GetByIdAsync(id);

        return car;
    }

    public async Task AddAsync(AddCarDTO car)
    {
        var efCar = _mapper.Map<Car>(car);

        await _repository.AddAsync(efCar);
    }

    public async Task UpdateAsync(UpdateCarDTO car)
    {
        var efCar = _mapper.Map<Car>(car);

        await _repository.UpdateAsync(efCar);
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }

	public async Task<List<Car>> GetByBrandAsync(int brandId)
	{
        var cars = await _repository.FilterByNumberAsync("brand_id", brandId);

        return cars;
	}

	public async Task<List<Car>> GetByClassAsync(int classId)
	{
		var cars = await _repository.FilterByNumberAsync("class_id", classId);

		return cars;
	}

	public async Task<List<Car>> GetByBodyTypeAsync(int bodyTypeId)
	{
		var cars = await _repository.FilterByNumberAsync("bodytype_id", bodyTypeId);

		return cars;
	}
}
