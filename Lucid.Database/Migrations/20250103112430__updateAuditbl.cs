using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lucid.Database.Migrations
{
    /// <inheritdoc />
    public partial class _updateAuditbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastModified",
                table: "Vans",
                newName: "LastModifiedOn");

            migrationBuilder.RenameColumn(
                name: "Created",
                table: "Vans",
                newName: "CreatedOn");

            migrationBuilder.RenameColumn(
                name: "LastModified",
                table: "Customers",
                newName: "LastModifiedOn");

            migrationBuilder.RenameColumn(
                name: "Created",
                table: "Customers",
                newName: "CreatedOn");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastModifiedOn",
                table: "Vans",
                newName: "LastModified");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "Vans",
                newName: "Created");

            migrationBuilder.RenameColumn(
                name: "LastModifiedOn",
                table: "Customers",
                newName: "LastModified");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "Customers",
                newName: "Created");
        }
    }
}
