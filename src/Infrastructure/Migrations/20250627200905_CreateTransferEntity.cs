using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FutManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateTransferEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "transfers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PlayerId = table.Column<Guid>(type: "uuid", nullable: false),
                    OriginClubId = table.Column<Guid>(type: "uuid", nullable: false),
                    DestinationClubId = table.Column<Guid>(type: "uuid", nullable: false),
                    TransferValue = table.Column<decimal>(type: "numeric", nullable: false),
                    TransferDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transfers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_transfers_clubs_DestinationClubId",
                        column: x => x.DestinationClubId,
                        principalTable: "clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_transfers_clubs_OriginClubId",
                        column: x => x.OriginClubId,
                        principalTable: "clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_transfers_players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_transfers_DestinationClubId",
                table: "transfers",
                column: "DestinationClubId");

            migrationBuilder.CreateIndex(
                name: "IX_transfers_OriginClubId",
                table: "transfers",
                column: "OriginClubId");

            migrationBuilder.CreateIndex(
                name: "IX_transfers_PlayerId",
                table: "transfers",
                column: "PlayerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "transfers");
        }
    }
}
