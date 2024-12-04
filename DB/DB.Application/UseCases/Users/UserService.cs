using DB.Application.Exceptions;
using DB.Application.UseCases.Users.DTO;
using DB.Domain.Abstractions;
using DB.Domain.Entities;

namespace DB.Application.UseCases.Users;

internal class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenService _tokenService;

    public UserService(IUserRepository userRepository, ITokenService tokenService)
    {
        _userRepository = userRepository;
        _tokenService = tokenService;
    }

    public async Task<string> LoginAsync(LoginDTO userDto)
    {
        var user = await _userRepository.Login(userDto.Email, userDto.Password);

        if (user is null)
        {
            throw new BadRequestException("Wrong user credentials");
        }

        var token = _tokenService.GetToken(user.Email, user.Id, user.RoleId.Value);

        return token;
    }

    public async Task<List<User>> GetAllUsersAsync()
    {
        var users = await _userRepository.GetAllUsersAsync();

        return users;
    }

    public async Task<User> GetByIdAsync(string id)
    {
        var user = await _userRepository.GetByIdAsync(id);

        if(user is null)
        {
            throw new BadRequestException("No such user");
        }

        return user;
    }
}
