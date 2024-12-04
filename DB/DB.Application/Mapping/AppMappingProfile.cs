using AutoMapper;
using DB.Application.UseCases.Cars.AddCar;
using DB.Application.UseCases.Cars.UpdateCar;
using DB.Domain.Entities;

namespace DB.Application.Mapping;

internal class AppMappingProfile : Profile
{
    public AppMappingProfile()
    {
        CreateMap<AddCarRequest, Car>().ReverseMap();
        CreateMap<UpdateCarRequest, Car>().ReverseMap();
    }
}
