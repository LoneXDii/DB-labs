﻿using DB.Domain.Abstractions;
using DB.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SupportService.Infrastructure.Data;

namespace DB.Infrastructure.Repositories;

internal class UserRepository : IUserRepository
{
    private readonly AppDbContext _dbContext;

    public UserRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

	public async Task<User?> Login(string email, string password)
	{
		var user = await _dbContext.Users
			.FromSqlRaw("SELECT id AS Id, username AS Username, email AS Email, role_id AS RoleId " +
						 "FROM Users WHERE email = {0} AND password_hash = {1}", email, password)
			.FirstOrDefaultAsync();

		return user;
	}

	public async Task<List<User>> GetAllUsersAsync()
    {
		var users = await _dbContext.Users
			.FromSqlRaw("SELECT id AS Id, username AS Username, email AS Email, role_id AS RoleId FROM Users")
			.ToListAsync();

		return users;
	}

	public async Task<User?> GetByIdAsync(string id)
	{
		var user = await _dbContext.Users
			.FromSqlRaw("SELECT id AS Id, username AS Username, email AS Email, role_id AS RoleId " +
						 "FROM Users WHERE id = {0}", id)
			.FirstOrDefaultAsync();

		return user;
	}
}
