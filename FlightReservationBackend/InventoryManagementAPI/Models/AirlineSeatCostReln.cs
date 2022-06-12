using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementAPI.Models
{
    public class AirlineSeatCostReln
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int RefID { get; set; }

        public int FlightID { get; set; }
        [ForeignKey("FlightID")]
        public virtual AirlineSchedule AirlineScheduleRef { get; set; }

        public string SeatType { get; set; }

        public int NoOfSeats { get; set; }

        public double TicketCost { get; set; }

        public double Tax { get; set; }
    }
}
