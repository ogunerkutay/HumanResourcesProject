using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DataAccessLayer.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
               name: "EmploymentDate",
               table: "AspNetUsers",
               type: "DateTime",
               nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AnnualLeave",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                computedColumnSql: "DATEDIFF(year, GETDATE(), [EmploymentDate])");

               
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnnualLeave",
                table: "AspNetUsers");
        }
    }
}
