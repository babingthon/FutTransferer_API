using MediatR;

namespace FutManagement.Application.Features.Auth.Queries.Login;

public record LoginQuery(
    string Email,
    string Password
    ) : IRequest<LoginResponse>;