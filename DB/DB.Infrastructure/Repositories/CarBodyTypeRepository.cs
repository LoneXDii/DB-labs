using DB.Domain.Abstractions;
using DB.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using SupportService.Infrastructure.Data;

namespace DB.Infrastructure.Repositories;

internal class CarBodyTypeRepository : IRepository<CarBodyType>
{
    private readonly AppDbContext _dbContext;

    public CarBodyTypeRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<CarBodyType>> GetAllAsync()
    {
        var bodyTypes = await _dbContext.CarBodyTypes
            .FromSqlRaw("SELECT id AS Id, name AS Name FROM Car_bodytypes ORDER BY id;")
            .ToListAsync();

        return bodyTypes;
    }

    public async Task<CarBodyType> GetByIdAsync(int id)
    {
        var bodyType = await _dbContext.CarBodyTypes
            .FromSqlRaw("SELECT id AS Id, name AS Name FROM Car_bodytypes WHERE id = {0}", id)
            .FirstOrDefaultAsync();

        return bodyType;
    }

    public async Task AddAsync(CarBodyType entity)
    {
        var sql = "INSERT INTO Car_bodytypes (name) VALUES ({0})";
        await _dbContext.Database.ExecuteSqlRawAsync(sql, entity.Name);
    }

    public async Task UpdateAsync(CarBodyType entity)
    {
        var sql = "UPDATE Car_bodytypes SET name = {0} WHERE id = {1}";
        await _dbContext.Database.ExecuteSqlRawAsync(sql, entity.Name, entity.Id);
    }

    public async Task DeleteAsync(int id)
    {
        var sql = "DELETE FROM Car_bodytypes WHERE id = {0}";
        await _dbContext.Database.ExecuteSqlRawAsync(sql, id);
    }

	public Task<List<CarBodyType>> FilterByNumberAsync(string column, int value)
	{
		throw new NotImplementedException();
	}

	public Task<List<CarBodyType>> FilterByStringAsync(string column, string value)
	{
		throw new NotImplementedException();
	}
}
