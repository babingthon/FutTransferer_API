using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FutManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CustomizeTableNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clubs_Countries_CountryId",
                table: "Clubs");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_Clubs_ClubId",
                table: "Players");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_Countries_NationalityId",
                table: "Players");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Players",
                table: "Players");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Countries",
                table: "Countries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clubs",
                table: "Clubs");

            migrationBuilder.RenameTable(
                name: "Players",
                newName: "players");

            migrationBuilder.RenameTable(
                name: "Countries",
                newName: "countries");

            migrationBuilder.RenameTable(
                name: "Clubs",
                newName: "clubs");

            migrationBuilder.RenameIndex(
                name: "IX_Players_NationalityId",
                table: "players",
                newName: "IX_players_NationalityId");

            migrationBuilder.RenameIndex(
                name: "IX_Players_ClubId",
                table: "players",
                newName: "IX_players_ClubId");

            migrationBuilder.RenameIndex(
                name: "IX_Clubs_CountryId",
                table: "clubs",
                newName: "IX_clubs_CountryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_players",
                table: "players",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_countries",
                table: "countries",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_clubs",
                table: "clubs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_clubs_countries_CountryId",
                table: "clubs",
                column: "CountryId",
                principalTable: "countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_players_clubs_ClubId",
                table: "players",
                column: "ClubId",
                principalTable: "clubs",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_players_countries_NationalityId",
                table: "players",
                column: "NationalityId",
                principalTable: "countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_clubs_countries_CountryId",
                table: "clubs");

            migrationBuilder.DropForeignKey(
                name: "FK_players_clubs_ClubId",
                table: "players");

            migrationBuilder.DropForeignKey(
                name: "FK_players_countries_NationalityId",
                table: "players");

            migrationBuilder.DropPrimaryKey(
                name: "PK_players",
                table: "players");

            migrationBuilder.DropPrimaryKey(
                name: "PK_countries",
                table: "countries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_clubs",
                table: "clubs");

            migrationBuilder.RenameTable(
                name: "players",
                newName: "Players");

            migrationBuilder.RenameTable(
                name: "countries",
                newName: "Countries");

            migrationBuilder.RenameTable(
                name: "clubs",
                newName: "Clubs");

            migrationBuilder.RenameIndex(
                name: "IX_players_NationalityId",
                table: "Players",
                newName: "IX_Players_NationalityId");

            migrationBuilder.RenameIndex(
                name: "IX_players_ClubId",
                table: "Players",
                newName: "IX_Players_ClubId");

            migrationBuilder.RenameIndex(
                name: "IX_clubs_CountryId",
                table: "Clubs",
                newName: "IX_Clubs_CountryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Players",
                table: "Players",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Countries",
                table: "Countries",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clubs",
                table: "Clubs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Clubs_Countries_CountryId",
                table: "Clubs",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Clubs_ClubId",
                table: "Players",
                column: "ClubId",
                principalTable: "Clubs",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Countries_NationalityId",
                table: "Players",
                column: "NationalityId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
