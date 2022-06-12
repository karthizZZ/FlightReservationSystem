using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementAPI.Models
{
    public class Airport
    {
        [Key]
        public int AirportID { get; set; }

        public string AirportName { get; set; }

        public string Location { get; set; }

        public string AirportCode { get; set; }
    }
}
