using DB.Domain.Abstractions;
using DB.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using SupportService.Infrastructure.Data;

namespace DB.Infrastructure.Repositories;

internal class CarRepository : IRepository<Car>
{
    private readonly AppDbContext _dbContext;

    public CarRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Car>> GetAllAsync()
    {
        var cars = await _dbContext.Cars
            .FromSqlRaw(@"
            SELECT c.id AS Id,
               c.model AS Model,
               c.registration_number AS RegistrationNumber,
               c.price AS Price,
               c.rent_price AS RentPrice,
               c.manufacture_year AS ManufactureYear,
               c.brand_id AS BrandId,
               b.name AS BrandName,
               c.class_id AS ClassId,
               cl.name AS ClassName,
               c.bodytype_id AS BodytypeId,
               bt.name AS BodytypeName
            FROM Cars c
            JOIN Car_brands b ON c.brand_id = b.id
            JOIN Car_classes cl ON c.class_id = cl.id
            JOIN Car_bodytypes bt ON c.bodytype_id = bt.id
            ORDER BY c.id;")
            .ToListAsync(); 

        return cars; 
    }

    public async Task<Car> GetByIdAsync(int id)
    {
        var car = await _dbContext.Cars
        .FromSqlRaw(@"
            SELECT c.id AS Id,
                   c.model AS Model,
                   c.registration_number AS RegistrationNumber,
                   c.price AS Price,
                   c.rent_price AS RentPrice,
                   c.manufacture_year AS ManufactureYear,
                   c.brand_id AS BrandId,
                   b.name AS BrandName,
                   c.class_id AS ClassId,
                   cl.name AS ClassName,
                   c.bodytype_id AS BodytypeId,
                   bt.name AS BodytypeName
            FROM Cars c
            JOIN Car_brands b ON c.brand_id = b.id
            JOIN Car_classes cl ON c.class_id = cl.id
            JOIN Car_bodytypes bt ON c.bodytype_id = bt.id
            WHERE c.id = {0}", id)
        .FirstOrDefaultAsync();

        return car;
    }

    public async Task AddAsync(Car entity)
    {
        var sql = @"
        INSERT INTO Cars (model, registration_number, price, rent_price, manufacture_year, brand_id, class_id, bodytype_id)
        VALUES ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7})";

        await _dbContext.Database.ExecuteSqlRawAsync(sql,
            entity.Model,
            entity.RegistrationNumber,
            entity.Price,
            entity.RentPrice,
            entity.ManufactureYear,
            entity.BrandId,
            entity.ClassId,
            entity.BodytypeId);
    }

    public async Task UpdateAsync(Car entity)
    {
        var sql = @"
        UPDATE Cars
        SET model = {0}, 
            registration_number = {1}, 
            price = {2}, 
            rent_price = {3}, 
            manufacture_year = {4}, 
            brand_id = {5}, 
            class_id = {6}, 
            bodytype_id = {7}
        WHERE id = {8}";

        var affectedRows = await _dbContext.Database.ExecuteSqlRawAsync(sql,
            entity.Model,
            entity.RegistrationNumber,
            entity.Price,
            entity.RentPrice,
            entity.ManufactureYear,
            entity.BrandId,
            entity.ClassId,
            entity.BodytypeId,
            entity.Id);
    }

    public async Task DeleteAsync(int id)
    {
        var sql = "DELETE FROM Cars WHERE id = {0}";

        var affectedRows = await _dbContext.Database.ExecuteSqlRawAsync(sql, id);
    }
}
