namespace DB.Domain.Abstractions;

public interface ITokenService
{
    string GetToken(string email, Guid id, int role);
}
