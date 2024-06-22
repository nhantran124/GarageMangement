using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageManagement.Infrastructure.Migrations
{
    public partial class RepairBill : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RepairBillDb",
                columns: table => new
                {
                    RepairCardId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffId = table.Column<string>(type: "varchar(15)", nullable: false),
                    DateEntryCard = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    TaxGTGT = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    SearchWarrant = table.Column<int>(type: "int", nullable: false),
                    VehicleId = table.Column<string>(type: "varchar(15)", nullable: false),
                    VehicleReturnDate = table.Column<string>(type: "varchar(20)", nullable: false),
                    CustomerId = table.Column<string>(type: "varchar(15)", nullable: false),
                    InsuranceId = table.Column<string>(type: "varchar(20)", nullable: true),
                    Censor = table.Column<string>(type: "nvarchar(520)", maxLength: 520, nullable: true),
                    Kilometer = table.Column<double>(type: "float", nullable: true),
                    InvoiceNumber = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    Note = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    FactoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepairBillDb", x => x.RepairCardId);
                    table.ForeignKey(
                        name: "FK_RepairBillDb_CustomerInfoDb_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "CustomerInfoDb",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RepairBillDb_Factories_FactoryId",
                        column: x => x.FactoryId,
                        principalTable: "Factories",
                        principalColumn: "FactoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RepairBillDb_Staff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staff",
                        principalColumn: "StaffId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RepairBillDb_VehicleDetailsDb_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "VehicleDetailsDb",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RepairBillDb_CustomerId",
                table: "RepairBillDb",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_RepairBillDb_FactoryId",
                table: "RepairBillDb",
                column: "FactoryId");

            migrationBuilder.CreateIndex(
                name: "IX_RepairBillDb_StaffId",
                table: "RepairBillDb",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_RepairBillDb_VehicleId",
                table: "RepairBillDb",
                column: "VehicleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RepairBillDb");
        }
    }
}
