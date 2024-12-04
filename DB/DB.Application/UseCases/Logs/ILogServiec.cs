using DB.Domain.Entities;

namespace DB.Application.UseCases.Logs;

public interface ILogService
{
    Task<List<Log>> GetAllAsync();
}
