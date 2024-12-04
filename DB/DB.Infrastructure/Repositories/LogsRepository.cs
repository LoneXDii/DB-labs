using DB.Domain.Abstractions;
using DB.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using SupportService.Infrastructure.Data;

namespace DB.Infrastructure.Repositories;

internal class LogsRepository : IRepository<Log>
{
    private readonly AppDbContext _dbContext;

    public LogsRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Log>> GetAllAsync()
    {
        var logs = await _dbContext.Logs
            .FromSqlRaw(@"
            SELECT id AS Id, datetime AS Datetime, action AS Action, table_name AS TableName, comment AS Comment FROM Logs
            ORDER BY id DESC")
            .ToListAsync();

        return logs;
    }

    public Task<Log> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(Log entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Log entity)
    {
        throw new NotImplementedException();
    }

	public Task<List<Log>> FilterByNumberAsync(string column, int value)
	{
		throw new NotImplementedException();
	}

	public Task<List<Log>> FilterByStringAsync(string column, string value)
	{
		throw new NotImplementedException();
	}
}
