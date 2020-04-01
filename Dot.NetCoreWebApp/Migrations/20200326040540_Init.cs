using Microsoft.EntityFrameworkCore.Migrations;

namespace Dot.NetCoreWebApp.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(250)", maxLength: 10, nullable: false),
                    EmpCode = table.Column<string>(type: "varchar(10)", nullable: true),
                    Position = table.Column<string>(type: "varchar(100)", maxLength: 10, nullable: true),
                    OfficeLocation = table.Column<string>(type: "varchar(100)", nullable: true),
                    Email = table.Column<string>(maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
