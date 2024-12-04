using DB.Application.UseCases.Users.DTO;
using DB.Domain.Entities;

namespace DB.Application.UseCases.Users;

public interface IUserService
{
    Task<string> LoginAsync(LoginDTO user);
    Task RegisterAsync(RegisterDTO user);
    Task<List<User>> GetAllUsersAsync();
    Task<User> GetByIdAsync(string id);
}
