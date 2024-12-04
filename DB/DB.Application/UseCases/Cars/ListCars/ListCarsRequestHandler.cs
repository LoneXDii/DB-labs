using DB.Domain.Abstractions;
using DB.Domain.Entities;
using MediatR;

namespace DB.Application.UseCases.Cars.ListCars;

internal class ListCarsRequestHandler(IRepository<Car> repository)
    : IRequestHandler<ListCarsRequest, List<Car>>
{
    public async Task<List<Car>> Handle(ListCarsRequest request, CancellationToken cancellationToken)
    {
        var cars = repository.GetAll();

        return cars;
    }
}
