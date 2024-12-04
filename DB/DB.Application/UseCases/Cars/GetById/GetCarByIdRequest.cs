using DB.Domain.Entities;
using MediatR;

namespace DB.Application.UseCases.Cars.GetById;

public sealed record GetCarByIdRequest(int Id) : IRequest<Car> { }
