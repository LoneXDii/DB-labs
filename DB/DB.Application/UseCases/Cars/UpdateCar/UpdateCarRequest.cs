using MediatR;

namespace DB.Application.UseCases.Cars.UpdateCar;

public sealed record UpdateCarRequest(int Id, string Model, string RegistrationNumber, double Price,
    double RentPrice, int ManufactureYear, int BrandId, int ClassId, int BodytypeId)
    : IRequest
{ }
