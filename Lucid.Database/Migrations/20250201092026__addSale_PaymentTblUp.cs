using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lucid.Database.Migrations
{
    /// <inheritdoc />
    public partial class _addSale_PaymentTblUp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Payments_PaymentId",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_Sales_PaymentId",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "Sales");

            migrationBuilder.AddColumn<double>(
                name: "Payment",
                table: "Sales",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Payments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_CustomerId",
                table: "Payments",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Customers_CustomerId",
                table: "Payments",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Customers_CustomerId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_CustomerId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "Payment",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Payments");

            migrationBuilder.AddColumn<int>(
                name: "PaymentId",
                table: "Sales",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Sales_PaymentId",
                table: "Sales",
                column: "PaymentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Payments_PaymentId",
                table: "Sales",
                column: "PaymentId",
                principalTable: "Payments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
