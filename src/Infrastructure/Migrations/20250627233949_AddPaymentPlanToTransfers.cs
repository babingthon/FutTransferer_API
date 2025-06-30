using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FutManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPaymentPlanToTransfers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfInstallments",
                table: "transfers",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentType",
                table: "transfers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "payment_installments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TransferId = table.Column<Guid>(type: "uuid", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    DueDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsPaidType = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payment_installments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_payment_installments_transfers_TransferId",
                        column: x => x.TransferId,
                        principalTable: "transfers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_payment_installments_TransferId",
                table: "payment_installments",
                column: "TransferId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "payment_installments");

            migrationBuilder.DropColumn(
                name: "NumberOfInstallments",
                table: "transfers");

            migrationBuilder.DropColumn(
                name: "PaymentType",
                table: "transfers");
        }
    }
}
