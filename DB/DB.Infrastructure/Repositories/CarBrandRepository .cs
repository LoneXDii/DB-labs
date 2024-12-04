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

    public async Task<List<CarBrand>> GetAllAsync()
    {
        var brands = await _dbContext.CarBrands
            .FromSqlRaw("SELECT id AS Id, name AS Name FROM Car_brands ORDER BY id;")
            .ToListAsync();

        return brands;
    }

    public async Task<CarBrand> GetByIdAsync(int id)
    {
        var brand = await _dbContext.CarBrands
            .FromSqlRaw("SELECT id AS Id, name AS Name FROM Car_brands WHERE id = {0}", id)
            .FirstOrDefaultAsync();

        return brand;
    }

    public async Task AddAsync(CarBrand entity)
    {
        var sql = "INSERT INTO Car_brands (name) VALUES ({0})";
        await _dbContext.Database.ExecuteSqlRawAsync(sql, entity.Name);
    }

    public async Task UpdateAsync(CarBrand entity)
    {
        var sql = "UPDATE Car_brands SET name = {0} WHERE id = {1}";
        await _dbContext.Database.ExecuteSqlRawAsync(sql, entity.Name, entity.Id);
    }

    public async Task DeleteAsync(int id)
    {
        var sql = "DELETE FROM Car_brands WHERE id = {0}";
        await _dbContext.Database.ExecuteSqlRawAsync(sql, id);
    }
}
