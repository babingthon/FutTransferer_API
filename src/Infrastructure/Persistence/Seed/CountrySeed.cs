using FutManagement.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace FutManagement.Infrastructure.Persistence.Seed;

public static class CountrySeed
{
    public static void SeedCountries(this ModelBuilder modelBuilder)
    { 
        var seedDate = new DateTime(2025, 6, 24, 15, 0, 0, DateTimeKind.Utc);

    modelBuilder.Entity<Country>().HasData(
        new Country { Id = Guid.Parse("f81d4fae-7dec-11d0-a765-00a0c91e6bf6"), Name = "Argentina", Code = "ARG", CreatedAt = seedDate },
        new Country { Id = Guid.Parse("f81d4fae-7dec-11d0-a765-00a0c91e6bf7"), Name = "France", Code = "FRA", CreatedAt = seedDate },
        new Country { Id = Guid.Parse("f81d4fae-7dec-11d0-a765-00a0c91e6bf8"), Name = "Brazil", Code = "BRA", CreatedAt = seedDate },
        new Country { Id = Guid.Parse("f81d4fae-7dec-11d0-a765-00a0c91e6bf9"), Name = "England", Code = "ENG", CreatedAt = seedDate },
        new Country { Id = Guid.Parse("f81d4fae-7dec-11d0-a765-00a0c91e6bfa"), Name = "Belgium", Code = "BEL", CreatedAt = seedDate },
        new Country { Id = Guid.Parse("f81d4fae-7dec-11d0-a765-00a0c91e6bfb"), Name = "Croatia", Code = "CRO", CreatedAt = seedDate },
        new Country { Id = Guid.Parse("f81d4fae-7dec-11d0-a765-00a0c91e6bfc"), Name = "Netherlands", Code = "NED", CreatedAt = seedDate },
        new Country { Id = Guid.Parse("f81d4fae-7dec-11d0-a765-00a0c91e6bfd"), Name = "Italy", Code = "ITA", CreatedAt = seedDate },
        new Country { Id = Guid.Parse("f81d4fae-7dec-11d0-a765-00a0c91e6bfe"), Name = "Portugal", Code = "POR", CreatedAt = seedDate },
        new Country { Id = Guid.Parse("f81d4fae-7dec-11d0-a765-00a0c91e6bff"), Name = "Spain", Code = "ESP", CreatedAt = seedDate },
        new Country { Id = Guid.Parse("f81d4fae-7dec-11d0-a765-00a0c91e6c00"), Name = "Morocco", Code = "MAR", CreatedAt = seedDate },
        new Country { Id = Guid.Parse("f81d4fae-7dec-11d0-a765-00a0c91e6c01"), Name = "Switzerland", Code = "SUI", CreatedAt = seedDate },
        new Country { Id = Guid.Parse("f81d4fae-7dec-11d0-a765-00a0c91e6c02"), Name = "USA", Code = "USA", CreatedAt = seedDate },
        new Country { Id = Guid.Parse("f81d4fae-7dec-11d0-a765-00a0c91e6c03"), Name = "Germany", Code = "GER", CreatedAt = seedDate },
        new Country { Id = Guid.Parse("f81d4fae-7dec-11d0-a765-00a0c91e6c04"), Name = "Mexico", Code = "MEX", CreatedAt = seedDate },
        new Country { Id = Guid.Parse("f81d4fae-7dec-11d0-a765-00a0c91e6c05"), Name = "Uruguay", Code = "URU", CreatedAt = seedDate },
        new Country { Id = Guid.Parse("f81d4fae-7dec-11d0-a765-00a0c91e6c06"), Name = "Colombia", Code = "COL", CreatedAt = seedDate },
        new Country { Id = Guid.Parse("f81d4fae-7dec-11d0-a765-00a0c91e6c07"), Name = "Denmark", Code = "DEN", CreatedAt = seedDate },
        new Country { Id = Guid.Parse("f81d4fae-7dec-11d0-a765-00a0c91e6c08"), Name = "Senegal", Code = "SEN", CreatedAt = seedDate },
        new Country { Id = Guid.Parse("f81d4fae-7dec-11d0-a765-00a0c91e6c09"), Name = "Japan", Code = "JPN", CreatedAt = seedDate },
        new Country { Id = Guid.Parse("f81d4fae-7dec-11d0-a765-00a0c91e6c0a"), Name = "Peru", Code = "PER", CreatedAt = seedDate },
        new Country { Id = Guid.Parse("f81d4fae-7dec-11d0-a765-00a0c91e6c0b"), Name = "Iran", Code = "IRN", CreatedAt = seedDate },
        new Country { Id = Guid.Parse("f81d4fae-7dec-11d0-a765-00a0c91e6c0c"), Name = "Serbia", Code = "SRB", CreatedAt = seedDate },
        new Country { Id = Guid.Parse("f81d4fae-7dec-11d0-a765-00a0c91e6c0d"), Name = "Poland", Code = "POL", CreatedAt = seedDate },
        new Country { Id = Guid.Parse("f81d4fae-7dec-11d0-a765-00a0c91e6c0e"), Name = "Sweden", Code = "SWE", CreatedAt = seedDate },
        new Country { Id = Guid.Parse("f81d4fae-7dec-11d0-a765-00a0c91e6c0f"), Name = "Ukraine", Code = "UKR", CreatedAt = seedDate },
        new Country { Id = Guid.Parse("f81d4fae-7dec-11d0-a765-00a0c91e6c10"), Name = "Wales", Code = "WAL", CreatedAt = seedDate },
        new Country { Id = Guid.Parse("f81d4fae-7dec-11d0-a765-00a0c91e6c11"), Name = "South Korea", Code = "KOR", CreatedAt = seedDate },
        new Country { Id = Guid.Parse("f81d4fae-7dec-11d0-a765-00a0c91e6c12"), Name = "Australia", Code = "AUS", CreatedAt = seedDate },
        new Country { Id = Guid.Parse("f81d4fae-7dec-11d0-a765-00a0c91e6c13"), Name = "Austria", Code = "AUT", CreatedAt = seedDate },
        new Country { Id = Guid.Parse("f81d4fae-7dec-11d0-a765-00a0c91e6c14"), Name = "Hungary", Code = "HUN", CreatedAt = seedDate },
        new Country { Id = Guid.Parse("f81d4fae-7dec-11d0-a765-00a0c91e6c15"), Name = "Norway", Code = "NOR", CreatedAt = seedDate },
        new Country { Id = Guid.Parse("f81d4fae-7dec-11d0-a765-00a0c91e6c16"), Name = "Czechia", Code = "CZE", CreatedAt = seedDate },
        new Country { Id = Guid.Parse("f81d4fae-7dec-11d0-a765-00a0c91e6c17"), Name = "Nigeria", Code = "NGA", CreatedAt = seedDate },
        new Country { Id = Guid.Parse("f81d4fae-7dec-11d0-a765-00a0c91e6c18"), Name = "Turkey", Code = "TUR", CreatedAt = seedDate },
        new Country { Id = Guid.Parse("f81d4fae-7dec-11d0-a765-00a0c91e6c19"), Name = "Ecuador", Code = "ECU", CreatedAt = seedDate },
        new Country { Id = Guid.Parse("f81d4fae-7dec-11d0-a765-00a0c91e6c1a"), Name = "Scotland", Code = "SCO", CreatedAt = seedDate },
        new Country { Id = Guid.Parse("f81d4fae-7dec-11d0-a765-00a0c91e6c1b"), Name = "Greece", Code = "GRE", CreatedAt = seedDate },
        new Country { Id = Guid.Parse("f81d4fae-7dec-11d0-a765-00a0c91e6c1c"), Name = "Tunisia", Code = "TUN", CreatedAt = seedDate },
        new Country { Id = Guid.Parse("f81d4fae-7dec-11d0-a765-00a0c91e6c1d"), Name = "Mali", Code = "MLI", CreatedAt = seedDate },
        new Country { Id = Guid.Parse("f81d4fae-7dec-11d0-a765-00a0c91e6c1e"), Name = "Algeria", Code = "ALG", CreatedAt = seedDate },
        new Country { Id = Guid.Parse("f81d4fae-7dec-11d0-a765-00a0c91e6c1f"), Name = "Egypt", Code = "EGY", CreatedAt = seedDate },
        new Country { Id = Guid.Parse("f81d4fae-7dec-11d0-a765-00a0c91e6c20"), Name = "Ivory Coast", Code = "CIV", CreatedAt = seedDate },
        new Country { Id = Guid.Parse("f81d4fae-7dec-11d0-a765-00a0c91e6c21"), Name = "Canada", Code = "CAN", CreatedAt = seedDate },
        new Country { Id = Guid.Parse("f81d4fae-7dec-11d0-a765-00a0c91e6c22"), Name = "Slovakia", Code = "SVK", CreatedAt = seedDate },
        new Country { Id = Guid.Parse("f81d4fae-7dec-11d0-a765-00a0c91e6c23"), Name = "Romania", Code = "ROU", CreatedAt = seedDate },
        new Country { Id = Guid.Parse("f81d4fae-7dec-11d0-a765-00a0c91e6c24"), Name = "Cameroon", Code = "CMR", CreatedAt = seedDate },
        new Country { Id = Guid.Parse("f81d4fae-7dec-11d0-a765-00a0c91e6c25"), Name = "Venezuela", Code = "VEN", CreatedAt = seedDate },
        new Country { Id = Guid.Parse("f81d4fae-7dec-11d0-a765-00a0c91e6c26"), Name = "Paraguay", Code = "PAR", CreatedAt = seedDate },
        new Country { Id = Guid.Parse("f81d4fae-7dec-11d0-a765-00a0c91e6c27"), Name = "Slovenia", Code = "SVN", CreatedAt = seedDate }
    );
    }
}