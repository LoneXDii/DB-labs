using DB.Domain.Entities;
using MediatR;

namespace DB.Application.UseCases.Cars.ListCars;

public sealed record ListCarsRequest() : IRequest<List<Car>> { }
