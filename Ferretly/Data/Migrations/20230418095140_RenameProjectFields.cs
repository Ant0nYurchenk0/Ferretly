using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ferretly.Data.Migrations
{
    /// <inheritdoc />
    public partial class RenameProjectFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateStart",
                table: "Projects",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "DateEnd",
                table: "Projects",
                newName: "EndDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Projects",
                newName: "DateStart");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "Projects",
                newName: "DateEnd");
        }
    }
}
