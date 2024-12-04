using AutoMapper;
using DB.Domain.Abstractions;
using DB.Domain.Entities;
using MediatR;

namespace DB.Application.UseCases.Cars.UpdateCar;

internal class UpdateCarRequestHandler(IRepository<Car> repository, IMapper mapper)
    : IRequestHandler<UpdateCarRequest>
{
    public async Task Handle(UpdateCarRequest request, CancellationToken cancellationToken)
    {
        var car = mapper.Map<Car>(request);

        repository.Update(car);
    }
}
