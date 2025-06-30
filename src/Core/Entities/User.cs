using System.Security.AccessControl;
using FutManagement.Core.Enums;

namespace FutManagement.Core.Entities;

public class User : BaseEntity
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public Role Role { get; set; }
}