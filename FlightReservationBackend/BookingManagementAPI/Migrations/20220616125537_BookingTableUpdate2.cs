using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingManagementAPI.Migrations
{
    public partial class BookingTableUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FromAirport",
                table: "BookingDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FromLocation",
                table: "BookingDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ToAirport",
                table: "BookingDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ToLocation",
                table: "BookingDetails",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FromAirport",
                table: "BookingDetails");

            migrationBuilder.DropColumn(
                name: "FromLocation",
                table: "BookingDetails");

            migrationBuilder.DropColumn(
                name: "ToAirport",
                table: "BookingDetails");

            migrationBuilder.DropColumn(
                name: "ToLocation",
                table: "BookingDetails");
        }
    }
}
