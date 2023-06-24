using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NeighborhoodWatch.Migrations
{
    public partial class _202306221918 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RewardType",
                table: "Rewards",
                newName: "IncidentType");

            migrationBuilder.AddColumn<double>(
                name: "RewardAmount",
                table: "Rewards",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RewardAmount",
                table: "Rewards");

            migrationBuilder.RenameColumn(
                name: "IncidentType",
                table: "Rewards",
                newName: "RewardType");
        }
    }
}
