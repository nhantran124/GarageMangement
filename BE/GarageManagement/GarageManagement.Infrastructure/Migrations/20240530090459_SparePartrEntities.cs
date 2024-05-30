using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageManagement.Infrastructure.Migrations
{
    public partial class SparePartrEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SparePartDb",
                columns: table => new
                {
                    SparePartId = table.Column<string>(type: "varchar(15)", nullable: false),
                    SparePartName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SparePartContent = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SparePartDb", x => x.SparePartId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SparePartDb");
        }
    }
}
