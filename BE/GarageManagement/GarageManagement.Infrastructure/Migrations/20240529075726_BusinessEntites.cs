using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageManagement.Infrastructure.Migrations
{
    public partial class BusinessEntites : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.CreateTable(
                name: "Business",
                columns: table => new
                {
                    BusinessDetailsId = table.Column<string>(type: "varchar(15)", nullable: false),
                    BusinessDetailsName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TypeOfBusinessDetailsId = table.Column<string>(type: "varchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Business", x => x.BusinessDetailsId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Business");

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    TaskId = table.Column<string>(type: "varchar(15)", nullable: false),
                    TaskName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TypeOfTask = table.Column<string>(type: "varchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.TaskId);
                });
        }
    }
}
