using Microsoft.EntityFrameworkCore.Migrations;

namespace Holdings.Repository.Migrations
{
    public partial class Platform : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Platform",
                table: "Entries");

            migrationBuilder.AddColumn<int>(
                name: "Platform",
                table: "Assets",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Platform",
                table: "Assets");

            migrationBuilder.AddColumn<int>(
                name: "Platform",
                table: "Entries",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
