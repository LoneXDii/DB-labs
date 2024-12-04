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

    public List<CarClass> GetAll()
    {
        var carClasses = _dbContext.CarClasses
            .FromSqlRaw("SELECT id AS Id, name AS Name, exp_required AS ExpRequired FROM Car_classes ORDER BY id;")
            .ToList();

        return carClasses;
    }

    public CarClass GetById(int id)
    {
        var carClass = _dbContext.CarClasses
            .FromSqlRaw("SELECT id AS Id, name AS Name, exp_required AS ExpRequired FROM Car_classes WHERE id = {0}", id)
            .FirstOrDefault();

        return carClass;
    }

    public void Add(CarClass entity)
    {
        var sql = "INSERT INTO Car_classes (name, exp_required) VALUES ({0}, {1})";
        _dbContext.Database.ExecuteSqlRaw(sql, entity.Name, entity.ExpRequired);
    }

    public void Update(CarClass entity)
    {
        var sql = "UPDATE Car_classes SET name = {0}, exp_required = {1} WHERE id = {2}";
        _dbContext.Database.ExecuteSqlRaw(sql, entity.Name, entity.ExpRequired, entity.Id);
    }

    public void Delete(int id)
    {
        var sql = "DELETE FROM Car_classes WHERE id = {0}";
        _dbContext.Database.ExecuteSqlRaw(sql, id);
    }
}