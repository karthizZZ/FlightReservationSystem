using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryManagementAPI.Migrations
{
    public partial class dbUpdateSp3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AirlineSearchDetails",
                columns: table => new
                {
                    AirlineScheduleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AirlineID = table.Column<int>(type: "int", nullable: false),
                    AirlineName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FlightName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FlightNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FromAirport = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToAirport = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReachTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AirlineLogo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MealsAvailable = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TicketPrice = table.Column<double>(type: "float", nullable: false),
                    Tax = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirlineSearchDetails", x => x.AirlineScheduleID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AirlineSearchDetails");
        }
    }
}
