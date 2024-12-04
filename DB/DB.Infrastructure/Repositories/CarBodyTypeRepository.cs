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

    public List<CarBodyType> GetAll()
    {
        var bodyTypes = _dbContext.CarBodyTypes
            .FromSqlRaw("SELECT id AS Id, name AS Name FROM Car_bodytypes ORDER BY id;")
            .ToList();

        return bodyTypes;
    }

    public CarBodyType GetById(int id)
    {
        var bodyType = _dbContext.CarBodyTypes
            .FromSqlRaw("SELECT id AS Id, name AS Name FROM Car_bodytypes WHERE id = {0}", id)
            .FirstOrDefault();

        return bodyType;
    }

    public void Add(CarBodyType entity)
    {
        var sql = "INSERT INTO Car_bodytypes (name) VALUES ({0})";
        _dbContext.Database.ExecuteSqlRaw(sql, entity.Name);
    }

    public void Update(CarBodyType entity)
    {
        var sql = "UPDATE Car_bodytypes SET name = {0} WHERE id = {1}";
        _dbContext.Database.ExecuteSqlRaw(sql, entity.Name, entity.Id);
    }

    public void Delete(int id)
    {
        var sql = "DELETE FROM Car_bodytypes WHERE id = {0}";
        _dbContext.Database.ExecuteSqlRaw(sql, id);
    }
}
