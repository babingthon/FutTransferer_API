using FutManagement.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace FutManagement.Infrastructure.Persistence.Seed;

public static class ClubSeed
{
    public static void SeedClubs(this ModelBuilder modelBuilder)
    {
        var englandId = Guid.Parse("f81d4fae-7dec-11d0-a765-00a0c91e6bf9");
        var spainId = Guid.Parse("f81d4fae-7dec-11d0-a765-00a0c91e6bff");
        var germanyId = Guid.Parse("f81d4fae-7dec-11d0-a765-00a0c91e6c03");
        var italyId = Guid.Parse("f81d4fae-7dec-11d0-a765-00a0c91e6bfd");
        var franceId = Guid.Parse("f81d4fae-7dec-11d0-a765-00a0c91e6bf7");
        var brazilId = Guid.Parse("f81d4fae-7dec-11d0-a765-00a0c91e6bf8");
        var argentinaId = Guid.Parse("f81d4fae-7dec-11d0-a765-00a0c91e6bf6");

        var seedDate = new DateTime(2025, 6, 24, 15, 0, 0, DateTimeKind.Utc);

         modelBuilder.Entity<Club>().HasData(
        // England - Premier League
        new Club { Id = Guid.Parse("c1a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b0a"), Name = "Arsenal", CountryId = englandId, FoundingYear = 1886, TransferBudget = 150000000, CreatedAt = seedDate },
        new Club { Id = Guid.Parse("c1a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b0b"), Name = "Manchester City", CountryId = englandId, FoundingYear = 1880, TransferBudget = 200000000, CreatedAt = seedDate },
        new Club { Id = Guid.Parse("c1a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b0c"), Name = "Manchester United", CountryId = englandId, FoundingYear = 1878, TransferBudget = 180000000, CreatedAt = seedDate },
        new Club { Id = Guid.Parse("c1a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b0d"), Name = "Liverpool", CountryId = englandId, FoundingYear = 1892, TransferBudget = 160000000, CreatedAt = seedDate },
        new Club { Id = Guid.Parse("c1a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b0e"), Name = "Chelsea", CountryId = englandId, FoundingYear = 1905, TransferBudget = 170000000, CreatedAt = seedDate },
        new Club { Id = Guid.Parse("c1a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b0f"), Name = "Tottenham Hotspur", CountryId = englandId, FoundingYear = 1882, TransferBudget = 120000000, CreatedAt = seedDate },

        // Spain - La Liga
        new Club { Id = Guid.Parse("d1a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b1a"), Name = "Real Madrid", CountryId = spainId, FoundingYear = 1902, TransferBudget = 250000000, CreatedAt = seedDate },
        new Club { Id = Guid.Parse("d1a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b1b"), Name = "Barcelona", CountryId = spainId, FoundingYear = 1899, TransferBudget = 100000000, CreatedAt = seedDate },
        new Club { Id = Guid.Parse("d1a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b1c"), Name = "Atlético Madrid", CountryId = spainId, FoundingYear = 1903, TransferBudget = 130000000, CreatedAt = seedDate },
        new Club { Id = Guid.Parse("d1a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b1d"), Name = "Sevilla", CountryId = spainId, FoundingYear = 1890, TransferBudget = 80000000, CreatedAt = seedDate },
        new Club { Id = Guid.Parse("d1a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b1e"), Name = "Real Sociedad", CountryId = spainId, FoundingYear = 1909, TransferBudget = 70000000, CreatedAt = seedDate },

        // Germany - Bundesliga
        new Club { Id = Guid.Parse("e1a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b2a"), Name = "Bayern Munich", CountryId = germanyId, FoundingYear = 1900, TransferBudget = 180000000, CreatedAt = seedDate },
        new Club { Id = Guid.Parse("e1a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b2b"), Name = "Borussia Dortmund", CountryId = germanyId, FoundingYear = 1909, TransferBudget = 120000000, CreatedAt = seedDate },
        new Club { Id = Guid.Parse("e1a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b2c"), Name = "RB Leipzig", CountryId = germanyId, FoundingYear = 2009, TransferBudget = 100000000, CreatedAt = seedDate },
        new Club { Id = Guid.Parse("e1a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b2d"), Name = "Bayer 04 Leverkusen", CountryId = germanyId, FoundingYear = 1904, TransferBudget = 90000000, CreatedAt = seedDate },

        // Italy - Serie A
        new Club { Id = Guid.Parse("f1a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b3a"), Name = "Juventus", CountryId = italyId, FoundingYear = 1897, TransferBudget = 120000000, CreatedAt = seedDate },
        new Club { Id = Guid.Parse("f1a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b3b"), Name = "Inter Milan", CountryId = italyId, FoundingYear = 1908, TransferBudget = 140000000, CreatedAt = seedDate },
        new Club { Id = Guid.Parse("f1a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b3c"), Name = "AC Milan", CountryId = italyId, FoundingYear = 1899, TransferBudget = 130000000, CreatedAt = seedDate },
        new Club { Id = Guid.Parse("f1a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b3d"), Name = "Napoli", CountryId = italyId, FoundingYear = 1926, TransferBudget = 100000000, CreatedAt = seedDate },
        new Club { Id = Guid.Parse("f1a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b3e"), Name = "AS Roma", CountryId = italyId, FoundingYear = 1927, TransferBudget = 90000000, CreatedAt = seedDate },

        // France - Ligue 1
        new Club { Id = Guid.Parse("a1a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b4a"), Name = "Paris Saint-Germain", CountryId = franceId, FoundingYear = 1970, TransferBudget = 220000000, CreatedAt = seedDate },
        new Club { Id = Guid.Parse("a1a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b4b"), Name = "Olympique de Marseille", CountryId = franceId, FoundingYear = 1899, TransferBudget = 80000000, CreatedAt = seedDate },
        new Club { Id = Guid.Parse("a1a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b4c"), Name = "AS Monaco", CountryId = franceId, FoundingYear = 1924, TransferBudget = 70000000, CreatedAt = seedDate },
        new Club { Id = Guid.Parse("a1a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b4d"), Name = "Olympique Lyonnais", CountryId = franceId, FoundingYear = 1950, TransferBudget = 75000000, CreatedAt = seedDate },

        // Brazil - Brasileirão
        new Club { Id = Guid.Parse("b1a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b5a"), Name = "Flamengo", CountryId = brazilId, FoundingYear = 1895, TransferBudget = 50000000, CreatedAt = seedDate },
        new Club { Id = Guid.Parse("b1a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b5b"), Name = "Palmeiras", CountryId = brazilId, FoundingYear = 1914, TransferBudget = 60000000, CreatedAt = seedDate },
        new Club { Id = Guid.Parse("b1a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b5c"), Name = "Corinthians", CountryId = brazilId, FoundingYear = 1910, TransferBudget = 40000000, CreatedAt = seedDate },
        new Club { Id = Guid.Parse("b1a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b5d"), Name = "São Paulo", CountryId = brazilId, FoundingYear = 1930, TransferBudget = 35000000, CreatedAt = seedDate },
        new Club { Id = Guid.Parse("b1a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b5e"), Name = "Grêmio", CountryId = brazilId, FoundingYear = 1903, TransferBudget = 30000000, CreatedAt = seedDate },
        
        // Argentina - Primera División
        new Club { Id = Guid.Parse("c2a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b6a"), Name = "River Plate", CountryId = argentinaId, FoundingYear = 1901, TransferBudget = 45000000, CreatedAt = seedDate },
        new Club { Id = Guid.Parse("c2a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b6b"), Name = "Boca Juniors", CountryId = argentinaId, FoundingYear = 1905, TransferBudget = 42000000, CreatedAt = seedDate },
        new Club { Id = Guid.Parse("c2a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b6c"), Name = "Racing Club", CountryId = argentinaId, FoundingYear = 1903, TransferBudget = 25000000, CreatedAt = seedDate }
    );
    }
}