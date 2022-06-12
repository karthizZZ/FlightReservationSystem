using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementAPI.MessageBus
{
    public class PassengerDetailsDto
    {
        public int BookingRefNumber { get; set; }

        public string PassengerName { get; set; }

        public string Gender { get; set; }

        public int Age { get; set; }
    }
}
