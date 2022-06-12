using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementAPI.Models.Dto
{
    public class SearchInputDto
    {
        public int FromAirportID { get; set; }

        public int ToAirportID { get; set; }

        public DateTime TravelDate { get; set; }

        public DateTime ReturnDate { get; set; }

        public bool IsRoundTrip { get; set; }

        public string SeatType { get; set; }

        public int NoOfTickets { get; set; }
    }
}
