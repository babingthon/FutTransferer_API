using FutManagement.Core.Entities;
using FutManagement.Core.Enums;
using Microsoft.EntityFrameworkCore;

namespace FutManagement.Infrastructure.Persistence.Seed;

public static class UserSeed
{
    public static void SeedUsers(this ModelBuilder modelBuilder)
    {
        var seedDate = new DateTime(2025, 6, 28, 11, 0, 0, DateTimeKind.Utc);
        const string placeholderPasswordHash = "$2a$11$jcf3sC7CqV/kM2LzXbN5z.K.gYm2U.v9c.n.d.J9n.z9n.d.J9n.z";

        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = Guid.Parse("a0a0a0a0-a0a0-a0a0-a0a0-000000000001"),
                FirstName = "Admin",
                LastName = "User",
                Email = "admin@futmanagement.com",
                PasswordHash = placeholderPasswordHash,
                Role = Role.Admin,
                CreatedAt = seedDate
            },
            new User
            {
                Id = Guid.Parse("b0b0b0b0-b0b0-b0b0-b0b0-000000000002"),
                FirstName = "Club",
                LastName = "Director",
                Email = "director@futmanagement.com",
                PasswordHash = placeholderPasswordHash,
                Role = Role.ClubDirector,
                CreatedAt = seedDate
            },
            new User
            {
                Id = Guid.Parse("c0c0c0c0-c0c0-c0c0-c0c0-000000000003"),
                FirstName = "Player",
                LastName = "Agent",
                Email = "agent@futmanagement.com",
                PasswordHash = placeholderPasswordHash,
                Role = Role.Agent,
                CreatedAt = seedDate
            }
        );
    }  
}