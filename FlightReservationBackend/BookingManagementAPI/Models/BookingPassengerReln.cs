using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookingManagementAPI.Models
{
    public class BookingPassengerReln
    {
        [Key]
        public int RefID { get; set; }

        public int BookingRefNumber { get; set; }
        [ForeignKey("BookingRefNumber")]
        public virtual BookingDetails BookingDetailsReference { get; set; }

        public string PassengerName { get; set; }

        public string Gender { get; set; }

        public int Age { get; set; }
    }
}
