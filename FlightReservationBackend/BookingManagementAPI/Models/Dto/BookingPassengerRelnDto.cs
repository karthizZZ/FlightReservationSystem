using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookingManagementAPI.Models
{
    public class BookingPassengerRelnDto
    {
        public int RefID { get; set; }

        public int BookingRefNumber { get; set; }

        public string PassengerName { get; set; }

        public string Gender { get; set; }

        public int Age { get; set; }
    }
}
