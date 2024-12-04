using DB.Domain.Abstractions;
using DB.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using SupportService.Infrastructure.Data;

namespace DB.Infrastructure.Repositories;

internal class OrderRepository : IRepository<Order>
{
	private readonly AppDbContext _dbContext;

	public OrderRepository(AppDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task<Order> GetByIdAsync(int id)
	{
		var sql = @"
		SELECT o.id AS Id, o.start AS Start, o.end AS End, o.price AS TotalPrice, o.closed AS Closed, 
			   u.id AS UserId, u.username AS Username, u.email AS Email,
			   c.id AS CarId, c.model AS Model, c.registration_number AS RegistrationNumber, c.price AS Price, 
			   c.rent_price AS RentPrice, c.manufacture_year AS ManufactureYear, 
			   c.brand_id AS BrandId, cb.name AS BrandName, 
			   c.class_id AS ClassId, cc.name AS ClassName, 
			   c.bodytype_id AS BodytypeId, cbt.name AS BodytypeName
		FROM Orders o
		JOIN Users u ON o.user_id = u.id
		LEFT JOIN Cars_orders co ON o.id = co.order_id
		LEFT JOIN Cars c ON co.car_id = c.id
		LEFT JOIN Car_brands cb ON c.brand_id = cb.id
		LEFT JOIN Car_classes cc ON c.class_id = cc.id
		LEFT JOIN Car_bodytypes cbt ON c.bodytype_id = cbt.id
		WHERE o.id = {0}";

		var orderList = await _dbContext.Orders
			.FromSqlRaw(sql, id)
			.AsNoTracking()
			.ToListAsync();

		var firstOrder = orderList.First();

		var result = new Order
		{
			OrderId = firstOrder.Id,
			Start = firstOrder.Start,
			End = firstOrder.End,
			TotalPrice = firstOrder.TotalPrice,
			Closed = firstOrder.Closed,
			UserId = firstOrder.UserId,
			Username = firstOrder.Username,
			Email = firstOrder.Email,
			Cars = orderList.Select(o => new Car
			{
				Id = o.CarId,
				Model = o.Model,
				RegistrationNumber = o.RegistrationNumber,
				Price = o.Price,
				RentPrice = o.RentPrice,
				ManufactureYear = o.ManufactureYear,
				BrandName = o.BrandName,
				ClassName = o.ClassName,
				BodytypeName = o.BodytypeName,
				BrandId = o.BrandId,
				ClassId = o.ClassId,
				BodytypeId = o.BodytypeId
			}).ToList()
		};

		return result;
	}

	public async Task<List<Order>> GetAllAsync()
	{
		var sql = @"
		SELECT o.id AS Id, o.start AS Start, o.end AS End, o.price AS TotalPrice, o.closed AS Closed, 
			   u.id AS UserId, u.username AS Username, u.email AS Email,
			   c.id AS CarId, c.model AS Model, c.registration_number AS RegistrationNumber, c.price AS Price, 
			   c.rent_price AS RentPrice, c.manufacture_year AS ManufactureYear, 
			   c.brand_id AS BrandId, cb.name AS BrandName, 
			   c.class_id AS ClassId, cc.name AS ClassName, 
			   c.bodytype_id AS BodytypeId, cbt.name AS BodytypeName
		FROM Orders o
		JOIN Users u ON o.user_id = u.id
		LEFT JOIN Cars_orders co ON o.id = co.order_id
		LEFT JOIN Cars c ON co.car_id = c.id
		LEFT JOIN Car_brands cb ON c.brand_id = cb.id
		LEFT JOIN Car_classes cc ON c.class_id = cc.id
		LEFT JOIN Car_bodytypes cbt ON c.bodytype_id = cbt.id";

		var orderList = await _dbContext.Orders
			.FromSqlRaw(sql)
			.AsNoTracking()
			.ToListAsync();

		var orders = orderList
			.GroupBy(o => o.Id)
			.Select(g => new Order
			{
				OrderId = g.Key,
				Start = g.First().Start,
				End = g.First().End,
				TotalPrice = g.First().TotalPrice,
				Closed = g.First().Closed,
				UserId = g.First().UserId,
				Username = g.First().Username,
				Email = g.First().Email,
				Cars = g.Select(car => new Car
				{
					Id = car.CarId,
					Model = car.Model,
					RegistrationNumber = car.RegistrationNumber,
					Price = car.Price,
					RentPrice = car.RentPrice,
					ManufactureYear = car.ManufactureYear,
					BrandId = car.BrandId,
					BrandName = car.BrandName,
					ClassId = car.ClassId,
					ClassName = car.ClassName,
					BodytypeId = car.BodytypeId,
					BodytypeName = car.BodytypeName
				}).ToList()
			}).ToList();

		return orders;
	}

	public Task AddAsync(Order entity)
	{
		throw new NotImplementedException();
	}

	public Task DeleteAsync(int id)
	{
		throw new NotImplementedException();
	}

	public Task UpdateAsync(Order entity)
	{
		throw new NotImplementedException();
	}

	public Task<List<Order>> FilterByNumberAsync(string column, int value)
	{
		throw new NotImplementedException();
	}

	public async Task<List<Order>> FilterByStringAsync(string column, string value)
	{
		var sql = $@"
		SELECT o.id AS Id, o.start AS Start, o.end AS End, o.price AS TotalPrice, o.closed AS Closed, 
			   u.id AS UserId, u.username AS Username, u.email AS Email,
			   c.id AS CarId, c.model AS Model, c.registration_number AS RegistrationNumber, c.price AS Price, 
			   c.rent_price AS RentPrice, c.manufacture_year AS ManufactureYear, 
			   c.brand_id AS BrandId, cb.name AS BrandName, 
			   c.class_id AS ClassId, cc.name AS ClassName, 
			   c.bodytype_id AS BodytypeId, cbt.name AS BodytypeName
		FROM Orders o
		JOIN Users u ON o.user_id = u.id
		LEFT JOIN Cars_orders co ON o.id = co.order_id
		LEFT JOIN Cars c ON co.car_id = c.id
		LEFT JOIN Car_brands cb ON c.brand_id = cb.id
		LEFT JOIN Car_classes cc ON c.class_id = cc.id
		LEFT JOIN Car_bodytypes cbt ON c.bodytype_id = cbt.id
		WHERE {column} = {{0}}";

		var orderList = await _dbContext.Orders
			.FromSqlRaw(sql, value)
			.AsNoTracking()
			.ToListAsync();

		var orders = orderList
			.GroupBy(o => o.Id)
			.Select(g => new Order
			{
				OrderId = g.Key,
				Start = g.First().Start,
				End = g.First().End,
				TotalPrice = g.First().TotalPrice,
				Closed = g.First().Closed,
				UserId = g.First().UserId,
				Username = g.First().Username,
				Email = g.First().Email,
				Cars = g.Select(car => new Car
				{
					Id = car.CarId,
					Model = car.Model,
					RegistrationNumber = car.RegistrationNumber,
					Price = car.Price,
					RentPrice = car.RentPrice,
					ManufactureYear = car.ManufactureYear,
					BrandId = car.BrandId,
					BrandName = car.BrandName,
					ClassId = car.ClassId,
					ClassName = car.ClassName,
					BodytypeId = car.BodytypeId,
					BodytypeName = car.BodytypeName
				}).ToList()
			}).ToList();

		return orders;
	}
}
