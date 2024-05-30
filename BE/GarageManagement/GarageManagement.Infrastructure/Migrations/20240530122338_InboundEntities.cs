using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageManagement.Infrastructure.Migrations
{
    public partial class InboundEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InboundDb",
                columns: table => new
                {
                    InvoiceEnterId = table.Column<string>(type: "varchar(20)", nullable: false),
                    DayEnter = table.Column<DateTime>(type: "datetime", nullable: false),
                    SupplierId = table.Column<string>(type: "varchar(20)", nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    StaffId = table.Column<string>(type: "varchar(20)", nullable: false),
                    InvoiceCode = table.Column<string>(type: "varchar(20)", nullable: false),
                    VAT = table.Column<double>(type: "float", nullable: false),
                    RepairCodeId = table.Column<string>(type: "varchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InboundDb", x => x.InvoiceEnterId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InboundDb");
        }
    }
}
