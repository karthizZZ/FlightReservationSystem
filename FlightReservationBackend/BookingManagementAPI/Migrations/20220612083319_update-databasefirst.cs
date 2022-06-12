using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingManagementAPI.Migrations
{
    public partial class updatedatabasefirst : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookingDetails",
                columns: table => new
                {
                    BookingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AirlineID = table.Column<int>(type: "int", nullable: false),
                    FlightNumber = table.Column<int>(type: "int", nullable: false),
                    AirlineName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MealType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoOfPassengers = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeatType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PNR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCancelled = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserID = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingDetails", x => x.BookingID);
                });

            migrationBuilder.CreateTable(
                name: "BookingSeatNumberRelation",
                columns: table => new
                {
                    RefID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingNumber = table.Column<int>(type: "int", nullable: false),
                    SeatNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingSeatNumberRelation", x => x.RefID);
                    table.ForeignKey(
                        name: "FK_BookingSeatNumberRelation_BookingDetails_BookingNumber",
                        column: x => x.BookingNumber,
                        principalTable: "BookingDetails",
                        principalColumn: "BookingID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PassengerDetails",
                columns: table => new
                {
                    RefID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingRefNumber = table.Column<int>(type: "int", nullable: false),
                    PassengerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PassengerDetails", x => x.RefID);
                    table.ForeignKey(
                        name: "FK_PassengerDetails_BookingDetails_BookingRefNumber",
                        column: x => x.BookingRefNumber,
                        principalTable: "BookingDetails",
                        principalColumn: "BookingID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingSeatNumberRelation_BookingNumber",
                table: "BookingSeatNumberRelation",
                column: "BookingNumber");

            migrationBuilder.CreateIndex(
                name: "IX_PassengerDetails_BookingRefNumber",
                table: "PassengerDetails",
                column: "BookingRefNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingSeatNumberRelation");

            migrationBuilder.DropTable(
                name: "PassengerDetails");

            migrationBuilder.DropTable(
                name: "BookingDetails");
        }
    }
}
