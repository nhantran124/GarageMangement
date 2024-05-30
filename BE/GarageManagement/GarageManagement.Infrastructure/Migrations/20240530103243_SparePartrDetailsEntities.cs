using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageManagement.Infrastructure.Migrations
{
    public partial class SparePartrDetailsEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SparePartDetailsDb",
                columns: table => new
                {
                    SparePartDetailsId = table.Column<string>(type: "varchar(15)", nullable: false),
                    SparePartDetailsName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    SparePartDetailsOtherName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    SparePartId = table.Column<string>(type: "varchar(10)", nullable: true),
                    SparePartSupplierId = table.Column<string>(type: "varchar(10)", nullable: false),
                    SparePartPrice = table.Column<double>(type: "float", nullable: false),
                    SparePartPosition = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SparePartUnitCal = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SparePartDetailsDb", x => x.SparePartDetailsId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SparePartDetailsDb");
        }
    }
}
