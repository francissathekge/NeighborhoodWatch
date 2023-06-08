using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NeighborhoodWatch.Migrations
{
    public partial class _202306061802 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Incidents_StoredFile_PictureId",
                table: "Incidents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StoredFile",
                table: "StoredFile");

            migrationBuilder.RenameTable(
                name: "StoredFile",
                newName: "StoredFiles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StoredFiles",
                table: "StoredFiles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Incidents_StoredFiles_PictureId",
                table: "Incidents",
                column: "PictureId",
                principalTable: "StoredFiles",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Incidents_StoredFiles_PictureId",
                table: "Incidents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StoredFiles",
                table: "StoredFiles");

            migrationBuilder.RenameTable(
                name: "StoredFiles",
                newName: "StoredFile");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StoredFile",
                table: "StoredFile",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Incidents_StoredFile_PictureId",
                table: "Incidents",
                column: "PictureId",
                principalTable: "StoredFile",
                principalColumn: "Id");
        }
    }
}
