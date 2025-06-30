using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FutManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedCountriesData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6bf6"), "ARG", new DateTime(2025, 6, 24, 15, 0, 0, 0, DateTimeKind.Utc), "Argentina", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6bf7"), "FRA", new DateTime(2025, 6, 24, 15, 0, 0, 0, DateTimeKind.Utc), "France", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6bf8"), "BRA", new DateTime(2025, 6, 24, 15, 0, 0, 0, DateTimeKind.Utc), "Brazil", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6bf9"), "ENG", new DateTime(2025, 6, 24, 15, 0, 0, 0, DateTimeKind.Utc), "England", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6bfa"), "BEL", new DateTime(2025, 6, 24, 15, 0, 0, 0, DateTimeKind.Utc), "Belgium", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6bfb"), "CRO", new DateTime(2025, 6, 24, 15, 0, 0, 0, DateTimeKind.Utc), "Croatia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6bfc"), "NED", new DateTime(2025, 6, 24, 15, 0, 0, 0, DateTimeKind.Utc), "Netherlands", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6bfd"), "ITA", new DateTime(2025, 6, 24, 15, 0, 0, 0, DateTimeKind.Utc), "Italy", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6bfe"), "POR", new DateTime(2025, 6, 24, 15, 0, 0, 0, DateTimeKind.Utc), "Portugal", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6bff"), "ESP", new DateTime(2025, 6, 24, 15, 0, 0, 0, DateTimeKind.Utc), "Spain", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6c00"), "MAR", new DateTime(2025, 6, 24, 15, 0, 0, 0, DateTimeKind.Utc), "Morocco", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6c01"), "SUI", new DateTime(2025, 6, 24, 15, 0, 0, 0, DateTimeKind.Utc), "Switzerland", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6c02"), "USA", new DateTime(2025, 6, 24, 15, 0, 0, 0, DateTimeKind.Utc), "USA", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6c03"), "GER", new DateTime(2025, 6, 24, 15, 0, 0, 0, DateTimeKind.Utc), "Germany", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6c04"), "MEX", new DateTime(2025, 6, 24, 15, 0, 0, 0, DateTimeKind.Utc), "Mexico", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6c05"), "URU", new DateTime(2025, 6, 24, 15, 0, 0, 0, DateTimeKind.Utc), "Uruguay", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6c06"), "COL", new DateTime(2025, 6, 24, 15, 0, 0, 0, DateTimeKind.Utc), "Colombia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6c07"), "DEN", new DateTime(2025, 6, 24, 15, 0, 0, 0, DateTimeKind.Utc), "Denmark", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6c08"), "SEN", new DateTime(2025, 6, 24, 15, 0, 0, 0, DateTimeKind.Utc), "Senegal", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6c09"), "JPN", new DateTime(2025, 6, 24, 15, 0, 0, 0, DateTimeKind.Utc), "Japan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6c0a"), "PER", new DateTime(2025, 6, 24, 15, 0, 0, 0, DateTimeKind.Utc), "Peru", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6c0b"), "IRN", new DateTime(2025, 6, 24, 15, 0, 0, 0, DateTimeKind.Utc), "Iran", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6c0c"), "SRB", new DateTime(2025, 6, 24, 15, 0, 0, 0, DateTimeKind.Utc), "Serbia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6c0d"), "POL", new DateTime(2025, 6, 24, 15, 0, 0, 0, DateTimeKind.Utc), "Poland", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6c0e"), "SWE", new DateTime(2025, 6, 24, 15, 0, 0, 0, DateTimeKind.Utc), "Sweden", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6c0f"), "UKR", new DateTime(2025, 6, 24, 15, 0, 0, 0, DateTimeKind.Utc), "Ukraine", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6c10"), "WAL", new DateTime(2025, 6, 24, 15, 0, 0, 0, DateTimeKind.Utc), "Wales", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6c11"), "KOR", new DateTime(2025, 6, 24, 15, 0, 0, 0, DateTimeKind.Utc), "South Korea", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6c12"), "AUS", new DateTime(2025, 6, 24, 15, 0, 0, 0, DateTimeKind.Utc), "Australia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6c13"), "AUT", new DateTime(2025, 6, 24, 15, 0, 0, 0, DateTimeKind.Utc), "Austria", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6c14"), "HUN", new DateTime(2025, 6, 24, 15, 0, 0, 0, DateTimeKind.Utc), "Hungary", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6c15"), "NOR", new DateTime(2025, 6, 24, 15, 0, 0, 0, DateTimeKind.Utc), "Norway", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6c16"), "CZE", new DateTime(2025, 6, 24, 15, 0, 0, 0, DateTimeKind.Utc), "Czechia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6c17"), "NGA", new DateTime(2025, 6, 24, 15, 0, 0, 0, DateTimeKind.Utc), "Nigeria", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6c18"), "TUR", new DateTime(2025, 6, 24, 15, 0, 0, 0, DateTimeKind.Utc), "Turkey", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6c19"), "ECU", new DateTime(2025, 6, 24, 15, 0, 0, 0, DateTimeKind.Utc), "Ecuador", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6c1a"), "SCO", new DateTime(2025, 6, 24, 15, 0, 0, 0, DateTimeKind.Utc), "Scotland", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6c1b"), "GRE", new DateTime(2025, 6, 24, 15, 0, 0, 0, DateTimeKind.Utc), "Greece", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6c1c"), "TUN", new DateTime(2025, 6, 24, 15, 0, 0, 0, DateTimeKind.Utc), "Tunisia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6c1d"), "MLI", new DateTime(2025, 6, 24, 15, 0, 0, 0, DateTimeKind.Utc), "Mali", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6c1e"), "ALG", new DateTime(2025, 6, 24, 15, 0, 0, 0, DateTimeKind.Utc), "Algeria", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6c1f"), "EGY", new DateTime(2025, 6, 24, 15, 0, 0, 0, DateTimeKind.Utc), "Egypt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6c20"), "CIV", new DateTime(2025, 6, 24, 15, 0, 0, 0, DateTimeKind.Utc), "Ivory Coast", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6c21"), "CAN", new DateTime(2025, 6, 24, 15, 0, 0, 0, DateTimeKind.Utc), "Canada", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6c22"), "SVK", new DateTime(2025, 6, 24, 15, 0, 0, 0, DateTimeKind.Utc), "Slovakia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6c23"), "ROU", new DateTime(2025, 6, 24, 15, 0, 0, 0, DateTimeKind.Utc), "Romania", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6c24"), "CMR", new DateTime(2025, 6, 24, 15, 0, 0, 0, DateTimeKind.Utc), "Cameroon", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6c25"), "VEN", new DateTime(2025, 6, 24, 15, 0, 0, 0, DateTimeKind.Utc), "Venezuela", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6c26"), "PAR", new DateTime(2025, 6, 24, 15, 0, 0, 0, DateTimeKind.Utc), "Paraguay", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6c27"), "SVN", new DateTime(2025, 6, 24, 15, 0, 0, 0, DateTimeKind.Utc), "Slovenia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6bf6"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6bf7"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6bf8"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6bf9"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6bfa"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6bfb"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6bfc"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6bfd"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6bfe"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6bff"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6c00"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6c01"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6c02"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6c03"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6c04"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6c05"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6c06"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6c07"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6c08"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6c09"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6c0a"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6c0b"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6c0c"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6c0d"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6c0e"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6c0f"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6c10"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6c11"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6c12"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6c13"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6c14"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6c15"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6c16"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6c17"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6c18"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6c19"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6c1a"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6c1b"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6c1c"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6c1d"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6c1e"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6c1f"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6c20"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6c21"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6c22"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6c23"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6c24"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6c25"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6c26"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f81d4fae-7dec-11d0-a765-00a0c91e6c27"));
        }
    }
}
