using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementAPI.Models.Dto
{
    public class AirlineScheduleDto
    {
        public int AirlineScheduleID { get; set; }

        public int? AirlineID { get; set; }

        public string FlightNumber { get; set; }

        public string FlightName { get; set; }

        public int? FromLocation { get; set; }

        public int? ToLocation { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string MealType { get; set; }

        public bool IsDaily { get; set; }

        public bool IsWeekdays { get; set; }

        public bool IsWeekends { get; set; }

        public bool IsSpecificDays { get; set; }
    }
}
