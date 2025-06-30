using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FutManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedUsersData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "CreatedAt", "Email", "FirstName", "LastName", "PasswordHash", "Role", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("a0a0a0a0-a0a0-a0a0-a0a0-000000000001"), new DateTime(2025, 6, 28, 11, 0, 0, 0, DateTimeKind.Utc), "admin@futmanagement.com", "Admin", "User", "$2a$11$jcf3sC7CqV/kM2LzXbN5z.K.gYm2U.v9c.n.d.J9n.z9n.d.J9n.z", "Admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b0b0b0b0-b0b0-b0b0-b0b0-000000000002"), new DateTime(2025, 6, 28, 11, 0, 0, 0, DateTimeKind.Utc), "director@futmanagement.com", "Club", "Director", "$2a$11$jcf3sC7CqV/kM2LzXbN5z.K.gYm2U.v9c.n.d.J9n.z9n.d.J9n.z", "ClubDirector", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c0c0c0c0-c0c0-c0c0-c0c0-000000000003"), new DateTime(2025, 6, 28, 11, 0, 0, 0, DateTimeKind.Utc), "agent@futmanagement.com", "Player", "Agent", "$2a$11$jcf3sC7CqV/kM2LzXbN5z.K.gYm2U.v9c.n.d.J9n.z9n.d.J9n.z", "Agent", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("a0a0a0a0-a0a0-a0a0-a0a0-000000000001"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("b0b0b0b0-b0b0-b0b0-b0b0-000000000002"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("c0c0c0c0-c0c0-c0c0-c0c0-000000000003"));
        }
    }
}
