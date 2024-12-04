using AutoMapper;
using DB.Application.UseCases.Brands.DTO;
using DB.Domain.Abstractions;
using DB.Domain.Entities;

namespace DB.Application.UseCases.Brands;

internal class CarBrandService : ICarBrandService
{
    private readonly IRepository<CarBrand> _repository;
    private readonly IMapper _mapper;

    public CarBrandService(IRepository<CarBrand> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<CarBrand>> GetAllAsync()
    {
        var brands = await _repository.GetAllAsync();

        return brands;
    }

    public async Task<CarBrand> GetByIdAsync(int id)
    {
        var brand = await _repository.GetByIdAsync(id);

        return brand;
    }

    public async Task AddAsync(AddCarBrandDTO car)
    {
        var efBrand = _mapper.Map<CarBrand>(car);

		await _repository.AddAsync(efBrand);
    }

    public async Task UpdateAsync(UpdateCarBrandDTO car)
    {
        var efBrand = _mapper.Map<CarBrand>(car);

		await _repository.UpdateAsync(efBrand);
    }

    public async Task DeleteAsync(int id)
    {
		await _repository.DeleteAsync(id);
    }
}
