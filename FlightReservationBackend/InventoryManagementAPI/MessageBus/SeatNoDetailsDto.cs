using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementAPI.MessageBus
{
    public class SeatNoDetailsDto
    {
        public int RefID { get; set; }

        public int BookingNumber { get; set; }

        public int SeatNumber { get; set; }
    }
}
