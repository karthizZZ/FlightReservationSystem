using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementAPI.Models.Dto
{
    public class AirlineSeatCostRelnDto
    {
        public int FlightID { get; set; }

        public string SeatType { get; set; }

        public int NoOfSeats { get; set; }

        public double TicketCost { get; set; }

        public double Tax { get; set; }
    }
}
