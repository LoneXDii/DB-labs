using DB.Domain.Abstractions;
using DB.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using SupportService.Infrastructure.Data;

namespace DB.Infrastructure.Repositories;

internal class CarClassRepository : IRepository<CarClass>
{
    private readonly AppDbContext _dbContext;

    public CarClassRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<CarClass>> GetAllAsync()
    {
        var carClasses = await _dbContext.CarClasses
            .FromSqlRaw("SELECT id AS Id, name AS Name, exp_required AS ExpRequired FROM Car_classes ORDER BY id;")
            .ToListAsync();

        return carClasses;
    }

    public async Task<CarClass> GetByIdAsync(int id)
    {
        var carClass = await _dbContext.CarClasses
            .FromSqlRaw("SELECT id AS Id, name AS Name, exp_required AS ExpRequired FROM Car_classes WHERE id = {0}", id)
            .FirstOrDefaultAsync();

        return carClass;
    }

    public async Task AddAsync(CarClass entity)
    {
        var sql = "INSERT INTO Car_classes (name, exp_required) VALUES ({0}, {1})";
        await _dbContext.Database.ExecuteSqlRawAsync(sql, entity.Name, entity.ExpRequired);
    }

    public async Task UpdateAsync(CarClass entity)
    {
        var sql = "UPDATE Car_classes SET name = {0}, exp_required = {1} WHERE id = {2}";
        await _dbContext.Database.ExecuteSqlRawAsync(sql, entity.Name, entity.ExpRequired, entity.Id);
    }

    public async Task DeleteAsync(int id)
    {
        var sql = "DELETE FROM Car_classes WHERE id = {0}";
        await _dbContext.Database.ExecuteSqlRawAsync(sql, id);
    }
}