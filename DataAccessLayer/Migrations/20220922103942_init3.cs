using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "AnnualLeave",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                computedColumnSql: "DATEDIFF(year, [EmploymentDate], GETDATE())",
                oldClrType: typeof(int),
                oldType: "int",
                oldComputedColumnSql: "DATEDIFF(year, GETDATE(), [EmploymentDate])");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "AnnualLeave",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                computedColumnSql: "DATEDIFF(year, GETDATE(), [EmploymentDate])",
                oldClrType: typeof(int),
                oldType: "int",
                oldComputedColumnSql: "DATEDIFF(year, [EmploymentDate], GETDATE())");
        }
    }
}
