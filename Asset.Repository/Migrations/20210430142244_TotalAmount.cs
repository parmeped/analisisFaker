using Microsoft.EntityFrameworkCore.Migrations;

namespace Holdings.Repository.Migrations
{
    public partial class TotalAmount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "InvestedAmount",
                table: "Assets",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InvestedAmount",
                table: "Assets");
        }
    }
}
