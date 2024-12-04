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

    public List<CarBrand> GetAll()
    {
        var brands = _repository.GetAll();

        return brands;
    }

    public CarBrand GetById(int id)
    {
        var brand = _repository.GetById(id);

        return brand;
    }

    public void Add(AddCarBrandDTO car)
    {
        var efBrand = _mapper.Map<CarBrand>(car);

        _repository.Add(efBrand);
    }

    public void Update(UpdateCarBrandDTO car)
    {
        var efBrand = _mapper.Map<CarBrand>(car);

        _repository.Update(efBrand);
    }

    public void Delete(int id)
    {
        _repository.Delete(id);
    }
}
