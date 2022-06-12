using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookingManagementAPI.Models
{
    public class BookingSeatNoRelnDto
    {
        public int RefID { get; set; }

        public int BookingNumber { get; set; }

        public int SeatNumber { get; set; }
    }
}
