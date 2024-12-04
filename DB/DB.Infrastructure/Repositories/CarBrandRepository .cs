using DB.Domain.Abstractions;
using DB.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using SupportService.Infrastructure.Data;

namespace DB.Infrastructure.Repositories;

internal class CarBrandRepository : IRepository<CarBrand>
{
    private readonly AppDbContext _dbContext;

    public CarBrandRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<CarBrand> GetAll()
    {
        var brands = _dbContext.CarBrands
            .FromSqlRaw("SELECT id AS Id, name AS Name FROM Car_brands ORDER BY id;")
            .ToList();

        return brands;
    }

    public CarBrand GetById(int id)
    {
        var brand = _dbContext.CarBrands
            .FromSqlRaw("SELECT id AS Id, name AS Name FROM Car_brands WHERE id = {0}", id)
            .FirstOrDefault();

        return brand;
    }

    public void Add(CarBrand entity)
    {
        var sql = "INSERT INTO Car_brands (name) VALUES ({0})";
        _dbContext.Database.ExecuteSqlRaw(sql, entity.Name);
    }

    public void Update(CarBrand entity)
    {
        var sql = "UPDATE Car_brands SET name = {0} WHERE id = {1}";
        _dbContext.Database.ExecuteSqlRaw(sql, entity.Name, entity.Id);
    }

    public void Delete(int id)
    {
        var sql = "DELETE FROM Car_brands WHERE id = {0}";
        _dbContext.Database.ExecuteSqlRaw(sql, id);
    }
}
