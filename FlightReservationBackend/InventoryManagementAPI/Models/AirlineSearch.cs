using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementAPI.Models
{
    public class AirlineSearch
    {
        [Key]
        public int AirlineScheduleID { get; set; }

        public int AirlineID { get; set; }

        public string AirlineName { get; set; }

        public string FlightName { get; set; }

        public string FlightNumber { get; set; }

        public string FromAirport { get; set; }

        public string ToAirport { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime ReachTime { get; set; }

        public string AirlineLogo { get; set; }

        public string MealsAvailable { get; set; }

        public double TicketPrice { get; set; }

        public double Tax { get; set; }
    }
}
