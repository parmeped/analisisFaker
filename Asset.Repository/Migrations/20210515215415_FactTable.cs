using Microsoft.EntityFrameworkCore.Migrations;

namespace Holdings.Repository.Migrations
{
    public partial class FactTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FactDistribution",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IndividualKey = table.Column<int>(type: "int", nullable: false),
                    VaccineKey = table.Column<int>(type: "int", nullable: false),
                    HospitalKey = table.Column<int>(type: "int", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    Vaccinated = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactDistribution", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FactDistribution");
        }
    }
}
