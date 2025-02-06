using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lucid.Database.Migrations
{
    /// <inheritdoc />
    public partial class _modifiedCustomer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "CustomerTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "CustomerTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "CustomerTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedOn",
                table: "CustomerTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "CustomerTypes");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "CustomerTypes");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "CustomerTypes");

            migrationBuilder.DropColumn(
                name: "LastModifiedOn",
                table: "CustomerTypes");
        }
    }
}
