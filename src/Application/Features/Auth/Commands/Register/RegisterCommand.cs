using FutManagement.Core.Enums;
using MediatR;

namespace FutManagement.Application.Features.Auth.Commands.Register;

public record RegisterCommand(
    string FirstName, 
    string LastName, 
    string Email, 
    string Password, 
    Role Role
    ) : IRequest<Guid>;