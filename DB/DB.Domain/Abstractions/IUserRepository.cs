using DB.Domain.Entities;

namespace DB.Domain.Abstractions;

public interface IUserRepository
{
    Task<User?> Login(string email, string password);
}
