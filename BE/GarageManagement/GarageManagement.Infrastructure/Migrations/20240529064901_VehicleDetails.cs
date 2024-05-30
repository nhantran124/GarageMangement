using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageManagement.Infrastructure.Migrations
{
    public partial class VehicleDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IDTypeOfVehicle",
                table: "Vehicles",
                newName: "TypeOfVehicleId");

            migrationBuilder.CreateTable(
                name: "VehicleDetailsDb",
                columns: table => new
                {
                    VehicleId = table.Column<string>(type: "varchar(15)", nullable: false),
                    TypeOfVehicleId = table.Column<string>(type: "varchar(20)", nullable: false),
                    LicensePlates = table.Column<string>(type: "varchar(20)", nullable: false),
                    VehicleNumber = table.Column<string>(type: "varchar(20)", nullable: false),
                    ChassisNumber = table.Column<string>(type: "varchar(50)", nullable: false),
                    VehicleColor = table.Column<int>(type: "int", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleDetailsDb", x => x.VehicleId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehicleDetailsDb");

            migrationBuilder.RenameColumn(
                name: "TypeOfVehicleId",
                table: "Vehicles",
                newName: "IDTypeOfVehicle");
        }
    }
}
