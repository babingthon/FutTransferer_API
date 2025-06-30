using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FutManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedClubsData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Clubs",
                columns: new[] { "Id", "CountryId", "CreatedAt", "FoundingYear", "Name", "TransferBudget", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("a1a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b4a"), new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6bf7"), new DateTime(2025, 6, 24, 15, 0, 0, 0, DateTimeKind.Utc), 1970, "Paris Saint-Germain", 220000000m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a1a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b4b"), new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6bf7"), new DateTime(2025, 6, 24, 15, 0, 0, 0, DateTimeKind.Utc), 1899, "Olympique de Marseille", 80000000m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a1a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b4c"), new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6bf7"), new DateTime(2025, 6, 24, 15, 0, 0, 0, DateTimeKind.Utc), 1924, "AS Monaco", 70000000m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a1a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b4d"), new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6bf7"), new DateTime(2025, 6, 24, 15, 0, 0, 0, DateTimeKind.Utc), 1950, "Olympique Lyonnais", 75000000m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b1a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b5a"), new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6bf8"), new DateTime(2025, 6, 24, 15, 0, 0, 0, DateTimeKind.Utc), 1895, "Flamengo", 50000000m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b1a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b5b"), new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6bf8"), new DateTime(2025, 6, 24, 15, 0, 0, 0, DateTimeKind.Utc), 1914, "Palmeiras", 60000000m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b1a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b5c"), new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6bf8"), new DateTime(2025, 6, 24, 15, 0, 0, 0, DateTimeKind.Utc), 1910, "Corinthians", 40000000m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b1a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b5d"), new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6bf8"), new DateTime(2025, 6, 24, 15, 0, 0, 0, DateTimeKind.Utc), 1930, "São Paulo", 35000000m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b1a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b5e"), new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6bf8"), new DateTime(2025, 6, 24, 15, 0, 0, 0, DateTimeKind.Utc), 1903, "Grêmio", 30000000m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c1a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b0a"), new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6bf9"), new DateTime(2025, 6, 24, 15, 0, 0, 0, DateTimeKind.Utc), 1886, "Arsenal", 150000000m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c1a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b0b"), new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6bf9"), new DateTime(2025, 6, 24, 15, 0, 0, 0, DateTimeKind.Utc), 1880, "Manchester City", 200000000m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c1a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b0c"), new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6bf9"), new DateTime(2025, 6, 24, 15, 0, 0, 0, DateTimeKind.Utc), 1878, "Manchester United", 180000000m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c1a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b0d"), new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6bf9"), new DateTime(2025, 6, 24, 15, 0, 0, 0, DateTimeKind.Utc), 1892, "Liverpool", 160000000m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c1a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b0e"), new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6bf9"), new DateTime(2025, 6, 24, 15, 0, 0, 0, DateTimeKind.Utc), 1905, "Chelsea", 170000000m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c1a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b0f"), new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6bf9"), new DateTime(2025, 6, 24, 15, 0, 0, 0, DateTimeKind.Utc), 1882, "Tottenham Hotspur", 120000000m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c2a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b6a"), new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6bf6"), new DateTime(2025, 6, 24, 15, 0, 0, 0, DateTimeKind.Utc), 1901, "River Plate", 45000000m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c2a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b6b"), new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6bf6"), new DateTime(2025, 6, 24, 15, 0, 0, 0, DateTimeKind.Utc), 1905, "Boca Juniors", 42000000m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c2a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b6c"), new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6bf6"), new DateTime(2025, 6, 24, 15, 0, 0, 0, DateTimeKind.Utc), 1903, "Racing Club", 25000000m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d1a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b1a"), new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6bff"), new DateTime(2025, 6, 24, 15, 0, 0, 0, DateTimeKind.Utc), 1902, "Real Madrid", 250000000m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d1a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b1b"), new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6bff"), new DateTime(2025, 6, 24, 15, 0, 0, 0, DateTimeKind.Utc), 1899, "Barcelona", 100000000m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d1a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b1c"), new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6bff"), new DateTime(2025, 6, 24, 15, 0, 0, 0, DateTimeKind.Utc), 1903, "Atlético Madrid", 130000000m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d1a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b1d"), new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6bff"), new DateTime(2025, 6, 24, 15, 0, 0, 0, DateTimeKind.Utc), 1890, "Sevilla", 80000000m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d1a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b1e"), new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6bff"), new DateTime(2025, 6, 24, 15, 0, 0, 0, DateTimeKind.Utc), 1909, "Real Sociedad", 70000000m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e1a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b2a"), new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6c03"), new DateTime(2025, 6, 24, 15, 0, 0, 0, DateTimeKind.Utc), 1900, "Bayern Munich", 180000000m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e1a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b2b"), new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6c03"), new DateTime(2025, 6, 24, 15, 0, 0, 0, DateTimeKind.Utc), 1909, "Borussia Dortmund", 120000000m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e1a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b2c"), new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6c03"), new DateTime(2025, 6, 24, 15, 0, 0, 0, DateTimeKind.Utc), 2009, "RB Leipzig", 100000000m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e1a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b2d"), new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6c03"), new DateTime(2025, 6, 24, 15, 0, 0, 0, DateTimeKind.Utc), 1904, "Bayer 04 Leverkusen", 90000000m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f1a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b3a"), new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6bfd"), new DateTime(2025, 6, 24, 15, 0, 0, 0, DateTimeKind.Utc), 1897, "Juventus", 120000000m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f1a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b3b"), new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6bfd"), new DateTime(2025, 6, 24, 15, 0, 0, 0, DateTimeKind.Utc), 1908, "Inter Milan", 140000000m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f1a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b3c"), new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6bfd"), new DateTime(2025, 6, 24, 15, 0, 0, 0, DateTimeKind.Utc), 1899, "AC Milan", 130000000m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f1a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b3d"), new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6bfd"), new DateTime(2025, 6, 24, 15, 0, 0, 0, DateTimeKind.Utc), 1926, "Napoli", 100000000m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f1a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b3e"), new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6bfd"), new DateTime(2025, 6, 24, 15, 0, 0, 0, DateTimeKind.Utc), 1927, "AS Roma", 90000000m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: new Guid("a1a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b4a"));

            migrationBuilder.DeleteData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: new Guid("a1a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b4b"));

            migrationBuilder.DeleteData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: new Guid("a1a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b4c"));

            migrationBuilder.DeleteData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: new Guid("a1a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b4d"));

            migrationBuilder.DeleteData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: new Guid("b1a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b5a"));

            migrationBuilder.DeleteData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: new Guid("b1a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b5b"));

            migrationBuilder.DeleteData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: new Guid("b1a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b5c"));

            migrationBuilder.DeleteData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: new Guid("b1a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b5d"));

            migrationBuilder.DeleteData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: new Guid("b1a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b5e"));

            migrationBuilder.DeleteData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: new Guid("c1a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b0a"));

            migrationBuilder.DeleteData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: new Guid("c1a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b0b"));

            migrationBuilder.DeleteData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: new Guid("c1a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b0c"));

            migrationBuilder.DeleteData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: new Guid("c1a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b0d"));

            migrationBuilder.DeleteData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: new Guid("c1a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b0e"));

            migrationBuilder.DeleteData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: new Guid("c1a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b0f"));

            migrationBuilder.DeleteData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: new Guid("c2a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b6a"));

            migrationBuilder.DeleteData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: new Guid("c2a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b6b"));

            migrationBuilder.DeleteData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: new Guid("c2a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b6c"));

            migrationBuilder.DeleteData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: new Guid("d1a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b1a"));

            migrationBuilder.DeleteData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: new Guid("d1a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b1b"));

            migrationBuilder.DeleteData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: new Guid("d1a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b1c"));

            migrationBuilder.DeleteData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: new Guid("d1a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b1d"));

            migrationBuilder.DeleteData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: new Guid("d1a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b1e"));

            migrationBuilder.DeleteData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: new Guid("e1a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b2a"));

            migrationBuilder.DeleteData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: new Guid("e1a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b2b"));

            migrationBuilder.DeleteData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: new Guid("e1a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b2c"));

            migrationBuilder.DeleteData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: new Guid("e1a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b2d"));

            migrationBuilder.DeleteData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: new Guid("f1a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b3a"));

            migrationBuilder.DeleteData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: new Guid("f1a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b3b"));

            migrationBuilder.DeleteData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: new Guid("f1a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b3c"));

            migrationBuilder.DeleteData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: new Guid("f1a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b3d"));

            migrationBuilder.DeleteData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: new Guid("f1a7b7b0-1b1a-4b9a-8b0a-0b9b8b0a0b3e"));
        }
    }
}
