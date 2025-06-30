namespace FutManagement.Application.Features.Auth.Queries.Login;

public record LoginResponse(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    string Role,
    string Token
    );