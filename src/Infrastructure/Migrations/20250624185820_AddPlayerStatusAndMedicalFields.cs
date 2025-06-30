using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FutManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPlayerStatusAndMedicalFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MedicalStatus",
                table: "Players",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PlayerStatus",
                table: "Players",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MedicalStatus",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "PlayerStatus",
                table: "Players");
        }
    }
}
