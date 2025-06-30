using FutManagement.Application.Common.Exceptions;
using FutManagement.Application.Interfaces.Authentication;
using FutManagement.Application.Interfaces.Persistence;
using FutManagement.Core.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FutManagement.Application.Features.Auth.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Guid>
{
    private readonly IAppDbContext _context;
    private readonly IPasswordHasher _passwordHasher;

    public RegisterCommandHandler(IAppDbContext context, IPasswordHasher passwordHasher)
    {
        _context = context;
        _passwordHasher = passwordHasher;
    }
    
    public async Task<Guid> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        if (await _context.Users.AnyAsync(u => u.Email == request.Email, cancellationToken))
        {
            throw new BusinessRuleViolationException("User with this email already exists.");
        }

        var passwordHash = _passwordHasher.Hash(request.Password);

        var user = new User
        {
            Id = Guid.NewGuid(),
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            PasswordHash = passwordHash,
            Role = request.Role,
            CreatedAt = DateTime.UtcNow
        };

        await _context.Users.AddAsync(user, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return user.Id;
    }
}