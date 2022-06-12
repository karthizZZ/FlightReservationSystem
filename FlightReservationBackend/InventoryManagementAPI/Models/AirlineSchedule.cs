using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementAPI.Models
{
    public class AirlineSchedule
    {
        [Key]
        public int AirlineScheduleID { get; set; }

        [ForeignKey("AirlineID")]
        public int? AirlineID { get; set; }
        public virtual Airline AirlineRef { get; set; }

        public string FlightNumber { get; set; }

        public string FlightName { get; set; }

        public int? FromLocation { get; set; }
        [ForeignKey("FromLocation")]
        public virtual Airport AirportFrom { get; set; }

        public int? ToLocation { get; set; }
        [ForeignKey("ToLocation")]
        public virtual Airport AirportTo { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string MealType { get; set; }

        public bool IsDaily { get; set; }

        public bool IsWeekdays { get; set; }

        public bool IsWeekends { get; set; }

        public bool IsSpecificDays { get; set; }

        public bool IsDeleted { get; set; }
    }
}
