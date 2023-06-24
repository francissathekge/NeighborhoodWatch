using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NeighborhoodWatch.Migrations
{
    public partial class _202306221917 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FileType",
                table: "storedImages",
                newName: "FileTypes");

            migrationBuilder.RenameColumn(
                name: "FileName",
                table: "storedImages",
                newName: "FileNames");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FileTypes",
                table: "storedImages",
                newName: "FileType");

            migrationBuilder.RenameColumn(
                name: "FileNames",
                table: "storedImages",
                newName: "FileName");
        }
    }
}
