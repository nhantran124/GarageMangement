using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageManagement.Infrastructure.Migrations
{
    public partial class CustomerEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_companyInfoDb",
                table: "companyInfoDb");

            migrationBuilder.RenameTable(
                name: "companyInfoDb",
                newName: "CompanyInfoDb");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompanyInfoDb",
                table: "CompanyInfoDb",
                column: "CompanyId");

            migrationBuilder.CreateTable(
                name: "CustomerInfoDb",
                columns: table => new
                {
                    CustomerId = table.Column<string>(type: "varchar(15)", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CustomerAddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CustomerPhonenumber = table.Column<string>(type: "varchar(20)", nullable: false),
                    CustomerTax = table.Column<string>(type: "varchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerInfoDb", x => x.CustomerId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerInfoDb");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompanyInfoDb",
                table: "CompanyInfoDb");

            migrationBuilder.RenameTable(
                name: "CompanyInfoDb",
                newName: "companyInfoDb");

            migrationBuilder.AddPrimaryKey(
                name: "PK_companyInfoDb",
                table: "companyInfoDb",
                column: "CompanyId");
        }
    }
}
