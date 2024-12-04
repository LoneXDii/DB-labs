using MediatR;

namespace DB.Application.UseCases.Cars.AddCar;

public sealed record AddCarRequest(string Model, string RegistrationNumber, double Price,
    double RentPrice, int ManufactureYear, int BrandId, int ClassId, int BodytypeId)
    : IRequest
{ }
