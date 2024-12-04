using DB.Domain.Entities;

namespace DB.Domain.Abstractions;

public interface IUserRepository
{
    Task<User?> LoginAsync(string email, string password);
    Task RegisterAsync(User user, string password);
    Task<List<User>> GetAllUsersAsync();
    Task<User?> GetByIdAsync(string id);
    Task AssignToRoleAsync(string userId, int roleId);
}
