using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryManagementAPI.Migrations
{
    public partial class AddAirllineTablesToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Airport",
                columns: table => new
                {
                    AirportID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AirportName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AirportCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airport", x => x.AirportID);
                });

            migrationBuilder.CreateTable(
                name: "AirlineSchedule",
                columns: table => new
                {
                    AirlineScheduleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AirlineID = table.Column<int>(type: "int", nullable: true),
                    FlightNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FlightName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FromLocation = table.Column<int>(type: "int", nullable: true),
                    ToLocation = table.Column<int>(type: "int", nullable: true),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MealType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsWeekly = table.Column<bool>(type: "bit", nullable: false),
                    IsWeekends = table.Column<bool>(type: "bit", nullable: false),
                    IsSpecificDays = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirlineSchedule", x => x.AirlineScheduleID);
                    table.ForeignKey(
                        name: "FK_AirlineSchedule_Airline_AirlineID",
                        column: x => x.AirlineID,
                        principalTable: "Airline",
                        principalColumn: "AirlineID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AirlineSchedule_Airport_FromLocation",
                        column: x => x.FromLocation,
                        principalTable: "Airport",
                        principalColumn: "AirportID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AirlineSchedule_Airport_ToLocation",
                        column: x => x.ToLocation,
                        principalTable: "Airport",
                        principalColumn: "AirportID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AirlineScheduleDayReln",
                columns: table => new
                {
                    RefID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AirlineScheduleID = table.Column<int>(type: "int", nullable: false),
                    AirlineID = table.Column<int>(type: "int", nullable: true),
                    weekDay = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirlineScheduleDayReln", x => x.RefID);
                    table.ForeignKey(
                        name: "FK_AirlineScheduleDayReln_AirlineSchedule_AirlineID",
                        column: x => x.AirlineID,
                        principalTable: "AirlineSchedule",
                        principalColumn: "AirlineScheduleID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AirlineSeatCostReln",
                columns: table => new
                {
                    RefID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlightID = table.Column<int>(type: "int", nullable: false),
                    SeatType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoOfSeats = table.Column<int>(type: "int", nullable: false),
                    TicketCost = table.Column<double>(type: "float", nullable: false),
                    Tax = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirlineSeatCostReln", x => x.RefID);
                    table.ForeignKey(
                        name: "FK_AirlineSeatCostReln_AirlineSchedule_FlightID",
                        column: x => x.FlightID,
                        principalTable: "AirlineSchedule",
                        principalColumn: "AirlineScheduleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AirlineSchedule_AirlineID",
                table: "AirlineSchedule",
                column: "AirlineID");

            migrationBuilder.CreateIndex(
                name: "IX_AirlineSchedule_FromLocation",
                table: "AirlineSchedule",
                column: "FromLocation");

            migrationBuilder.CreateIndex(
                name: "IX_AirlineSchedule_ToLocation",
                table: "AirlineSchedule",
                column: "ToLocation");

            migrationBuilder.CreateIndex(
                name: "IX_AirlineScheduleDayReln_AirlineID",
                table: "AirlineScheduleDayReln",
                column: "AirlineID");

            migrationBuilder.CreateIndex(
                name: "IX_AirlineSeatCostReln_FlightID",
                table: "AirlineSeatCostReln",
                column: "FlightID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AirlineScheduleDayReln");

            migrationBuilder.DropTable(
                name: "AirlineSeatCostReln");

            migrationBuilder.DropTable(
                name: "AirlineSchedule");

            migrationBuilder.DropTable(
                name: "Airport");
        }
    }
}
