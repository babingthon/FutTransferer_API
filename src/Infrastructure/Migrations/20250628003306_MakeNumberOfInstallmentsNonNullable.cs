using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FutManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MakeNumberOfInstallmentsNonNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsPaidType",
                table: "payment_installments",
                newName: "IsPaid");

            migrationBuilder.AlterColumn<int>(
                name: "NumberOfInstallments",
                table: "transfers",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsPaid",
                table: "payment_installments",
                newName: "IsPaidType");

            migrationBuilder.AlterColumn<int>(
                name: "NumberOfInstallments",
                table: "transfers",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");
        }
    }
}
