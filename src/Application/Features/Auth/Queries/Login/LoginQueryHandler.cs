using FutManagement.Application.Common.Exceptions;
using FutManagement.Application.Interfaces.Authentication;
using FutManagement.Application.Interfaces.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FutManagement.Application.Features.Auth.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, LoginResponse>
{
    private readonly IAppDbContext _context;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public LoginQueryHandler(IAppDbContext context, IPasswordHasher passwordHasher, IJwtTokenGenerator jwtTokenGenerator)
    {
        _context = context;
        _passwordHasher = passwordHasher;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<LoginResponse> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email, cancellationToken);
        
        if (user is null || !_passwordHasher.Verify(request.Password, user.PasswordHash))
        {
            throw new BusinessRuleViolationException("Invalid email or password.");
        }
        
        var token = _jwtTokenGenerator.GenerateToken(user);
    
        return new LoginResponse(
            user.Id,
            user.FirstName,
            user.LastName,
            user.Email,
            user.Role.ToString(),
            token
        ); 
    }
}