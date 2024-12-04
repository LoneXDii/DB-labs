using MediatR;

namespace DB.Application.UseCases.Cars.DeleteCar;

public sealed record DeleteCarRequest(int Id) : IRequest { }
