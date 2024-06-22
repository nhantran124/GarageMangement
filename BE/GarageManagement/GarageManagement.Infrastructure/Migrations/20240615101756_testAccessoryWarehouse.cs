using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageManagement.Infrastructure.Migrations
{
    public partial class testAccessoryWarehouse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccessoryWarehouseDb",
                columns: table => new
                {
                    SupplierSparePartId = table.Column<string>(type: "varchar(20)", nullable: false),
                    SparePartDetailsId = table.Column<string>(type: "varchar(20)", nullable: false),
                    InputPrice = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    SupplierId = table.Column<string>(type: "varchar(20)", nullable: false),
                    DayEnter = table.Column<DateTime>(type: "datetime", nullable: false),
                    Barcode = table.Column<byte[]>(type: "varbinary(50)", nullable: false),
                    InvoiceEnterId = table.Column<string>(type: "varchar(20)", nullable: false),
                    RepairCardId = table.Column<string>(type: "varchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessoryWarehouseDb", x => x.SupplierSparePartId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccessoryWarehouseDb");
        }
    }
}
