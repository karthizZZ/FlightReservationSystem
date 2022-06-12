using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryManagementAPI.Migrations
{
    public partial class spupdatemigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			string procedure = @"CREATE PROCEDURE GetAirlinesearchResult
            	@FromAirportID int,
            	@ToAirportID int,
            	@TravelDate Date,
            	@SeatType varchar(50),
            	@NoOfTickets int
            AS
            BEGIN
            	SELECT 
            	AR.AirlineID,
            	AR.AirlineName,
            	AH.AirlineScheduleID,
            	AH.FlightName,
            	AH.FlightNumber,
            	AP1.AirportName + '(' + AP1.[Location] + ')' as FromAirport,
                AP2.AirportName + '(' + AP2.[Location] + ')' as ToAirport,
            	AH.StartTime,
            	AH.EndTime as ReachTime,
            	AH.MealType as MealsAvailable,
            	AC.TicketCost as TicketPrice,
            	AC.Tax,
            	AR.AirlineLogo
            	FROM dbo.Airline AR
            	LEFT JOIN dbo.AirlineSchedule AH ON
            	AR.AirlineID = AH.AirlineID
            	LEFT JOIN dbo.AirlineScheduleDayReln AD ON
            	AH.AirlineScheduleID = AD.AirlineScheduleID
            	LEFT JOIN AirlineSeatCostReln AC ON
            	AH.AirlineScheduleID = AC.FlightID
            	LEFT JOIN dbo.Airport AP1
            	ON AH.FromLocation = AP1.AirportID
            	LEFT JOIN dbo.Airport AP2
            	ON AH.ToLocation = AP2.AirportID
            	where ISNULL(AR.IsBlocked,0) = 0
            	AND ISNULL(AH.IsDeleted,0) = 0
            	AND AC.SeatType = @SeatType
            	AND AC.NoOfSeats >= @NoOfTickets
            	AND AH.FromLocation = @FromAirportID
            	AND AH.ToLocation = @ToAirportID
            	AND AH.IsDaily= 1 OR (AH.IsWeekends = 1 AND  DATENAME(WEEKDAY, @TravelDate) in ('Sunday','Saturday')) 
            	OR (AH.IsWeekdays = 1  AND  DATENAME(WEEKDAY, @TravelDate) in ('Monday','Tuesday','Wednesday','Thursday','Friday'))
            	OR (AH.IsSpecificDays = 1 AND AD.[weekDay]=DATENAME(WEEKDAY, @TravelDate))
            
            END";

            migrationBuilder.Sql(procedure);        
		}

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"drop procedure GetAirlinesearchResult";
            migrationBuilder.Sql(procedure);
        }
    }
}
