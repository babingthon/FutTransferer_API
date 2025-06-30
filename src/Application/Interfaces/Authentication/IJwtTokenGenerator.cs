using FutManagement.Core.Entities;

namespace FutManagement.Application.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}