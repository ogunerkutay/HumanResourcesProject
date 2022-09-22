using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class init5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "AnnualLeave",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                computedColumnSql: "IIF((DATEDIFF(year, [EmploymentDate], GETDATE())) > 15, 26, IIF((DATEDIFF(year, [EmploymentDate], GETDATE())) > 5, 20, 14))",
                oldClrType: typeof(int),
                oldType: "int",
                oldComputedColumnSql: "IIF((DATEDIFF(year, [EmploymentDate], GETDATE())) > 5, 20, 14)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "AnnualLeave",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                computedColumnSql: "IIF((DATEDIFF(year, [EmploymentDate], GETDATE())) > 5, 20, 14)",
                oldClrType: typeof(int),
                oldType: "int",
                oldComputedColumnSql: "IIF((DATEDIFF(year, [EmploymentDate], GETDATE())) > 15, 26, IIF((DATEDIFF(year, [EmploymentDate], GETDATE())) > 5, 20, 14))");
        }
    }
}
