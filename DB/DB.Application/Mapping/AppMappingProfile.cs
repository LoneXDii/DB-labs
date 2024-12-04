using AutoMapper;
using DB.Application.UseCases.BodyTypes.DTO;
using DB.Application.UseCases.Brands.DTO;
using DB.Application.UseCases.Cars.DTO;
using DB.Application.UseCases.Users.DTO;
using DB.Domain.Entities;

namespace DB.Application.Mapping;

internal class AppMappingProfile : Profile
{
    public AppMappingProfile()
    {
        CreateMap<AddCarDTO, Car>().ReverseMap();
        CreateMap<UpdateCarDTO, Car>().ReverseMap();

        CreateMap<AddCarBrandDTO, CarBrand>().ReverseMap();
        CreateMap<UpdateCarBrandDTO, CarBrand>().ReverseMap();

        CreateMap<AddCarBodyTypeDTO, CarBodyType>().ReverseMap();
        CreateMap<UpdateCarBodyTypeDTO, CarBodyType>().ReverseMap();

        CreateMap<RegisterDTO, User>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
            .ReverseMap();
    }
}
