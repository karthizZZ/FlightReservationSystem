using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryManagementAPI.Migrations
{
    public partial class updatetables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsWeekly",
                table: "AirlineSchedule",
                newName: "IsWeekdays");

            migrationBuilder.AddColumn<bool>(
                name: "IsDaily",
                table: "AirlineSchedule",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDaily",
                table: "AirlineSchedule");

            migrationBuilder.RenameColumn(
                name: "IsWeekdays",
                table: "AirlineSchedule",
                newName: "IsWeekly");
        }
    }
}
