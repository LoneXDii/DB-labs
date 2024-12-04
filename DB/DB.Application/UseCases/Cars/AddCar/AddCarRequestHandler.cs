using AutoMapper;
using DB.Domain.Abstractions;
using DB.Domain.Entities;
using MediatR;

namespace DB.Application.UseCases.Cars.AddCar;

internal class AddCarRequestHandler(IRepository<Car> repository, IMapper mapper)
    : IRequestHandler<AddCarRequest>
{
    public async Task Handle(AddCarRequest request, CancellationToken cancellationToken)
    {
        var car = mapper.Map<Car>(request);

        repository.Add(car);
    }
}
