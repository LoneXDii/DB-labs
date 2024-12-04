using DB.Domain.Abstractions;
using DB.Domain.Entities;
using MediatR;

namespace DB.Application.UseCases.Cars.GetById;

internal class GetCarByIdRequestHandler(IRepository<Car> repository)
    : IRequestHandler<GetCarByIdRequest, Car>
{
    public async Task<Car> Handle(GetCarByIdRequest request, CancellationToken cancellationToken)
    {
        var car = repository.GetById(request.Id);

        return car;
    }
}
