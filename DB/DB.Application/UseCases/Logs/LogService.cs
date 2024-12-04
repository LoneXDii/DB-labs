using DB.Domain.Abstractions;
using DB.Domain.Entities;

namespace DB.Application.UseCases.Logs;

internal class LogService : ILogService
{
    private readonly IRepository<Log> _repository;

    public LogService(IRepository<Log> repository)
    {
        _repository = repository;
    }

    public async Task<List<Log>> GetAllAsync()
    {
        var logs = await _repository.GetAllAsync();

        return logs;
    }
}
