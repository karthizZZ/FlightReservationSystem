using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementAPI.Models
{
    public class Airline
    {
        [Key]
        public int AirlineID { get; set; }

        [Required]
        public string AirlineName { get; set; }

        public string ContactNumber { get; set; }

        public string ContactAddress { get; set; }

        public string AirlineLogo { get; set; }

        public bool IsBlocked { get; set; }
    }
}
