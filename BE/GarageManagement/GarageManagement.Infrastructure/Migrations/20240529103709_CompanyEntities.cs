using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageManagement.Infrastructure.Migrations
{
    public partial class CompanyEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "companyInfoDb",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CompanyAddress = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CompanyPhoneNumber = table.Column<string>(type: "varchar(30)", nullable: false),
                    CompanyEmail = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CompanyWeb = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CompanyTax = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NotePrice = table.Column<string>(type: "nvarchar(MAX)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_companyInfoDb", x => x.CompanyId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "companyInfoDb");
        }
    }
}
