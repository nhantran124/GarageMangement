using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageManagement.Infrastructure.Migrations
{
    public partial class Migv4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Factories",
                columns: table => new
                {
                    FactoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FactoryName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factories", x => x.FactoryId);
                });

            migrationBuilder.CreateTable(
                name: "Insurances",
                columns: table => new
                {
                    InsuranceId = table.Column<string>(type: "varchar(15)", nullable: false),
                    InsuranceName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    InsuranceTax = table.Column<string>(type: "varchar(50)", nullable: false),
                    InsuranceAddress = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    InsuranceNumberAccount = table.Column<string>(type: "varchar(50)", nullable: false),
                    InsuranceBank = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    InsuranceBranch = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insurances", x => x.InsuranceId);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Factories");

            migrationBuilder.DropTable(
                name: "Insurances");

            migrationBuilder.DropTable(
                name: "Tasks");
        }
    }
}
