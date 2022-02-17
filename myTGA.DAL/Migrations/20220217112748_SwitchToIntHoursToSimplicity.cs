using Microsoft.EntityFrameworkCore.Migrations;

namespace myTGA.DAL.Migrations
{
    public partial class SwitchToIntHoursToSimplicity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "HoursWorked",
                table: "EmployeeReportTaskHours",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "HoursWorked",
                table: "EmployeeReportTaskHours",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
