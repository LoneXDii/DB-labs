using DB.Domain.Abstractions;
using DB.Domain.Entities;
using MediatR;

namespace DB.Application.UseCases.Cars.DeleteCar;

internal class DeleteCarRequestHandler(IRepository<Car> repository)
    : IRequestHandler<DeleteCarRequest>
{
    public async Task Handle(DeleteCarRequest request, CancellationToken cancellationToken)
    {
        repository.Delete(request.Id);
    }
}
