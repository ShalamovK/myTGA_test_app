using Microsoft.EntityFrameworkCore.Migrations;

namespace myTGA.DAL.Migrations
{
    public partial class AddHoursToEmployeeTasks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "HoursWorked",
                table: "EmployeeTasks",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HoursWorked",
                table: "EmployeeTasks");
        }
    }
}
