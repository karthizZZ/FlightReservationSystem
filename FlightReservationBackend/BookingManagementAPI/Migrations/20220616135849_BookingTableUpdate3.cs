using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingManagementAPI.Migrations
{
    public partial class BookingTableUpdate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Tax",
                table: "BookingDetails",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TicketCost",
                table: "BookingDetails",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tax",
                table: "BookingDetails");

            migrationBuilder.DropColumn(
                name: "TicketCost",
                table: "BookingDetails");
        }
    }
}
