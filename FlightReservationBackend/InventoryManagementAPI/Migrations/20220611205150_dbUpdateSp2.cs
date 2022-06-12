using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryManagementAPI.Migrations
{
    public partial class dbUpdateSp2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AirlineSearchDetails");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AirlineSearchDetails",
                columns: table => new
                {
                    RefID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AirlineID = table.Column<int>(type: "int", nullable: false),
                    AirlineLogo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AirlineName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AirlineScheduleID = table.Column<int>(type: "int", nullable: false),
                    FlightName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FlightNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FromAirport = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MealsAvailable = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReachTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tax = table.Column<double>(type: "float", nullable: false),
                    TicketPrice = table.Column<double>(type: "float", nullable: false),
                    ToAirport = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirlineSearchDetails", x => x.RefID);
                });
        }
    }
}
