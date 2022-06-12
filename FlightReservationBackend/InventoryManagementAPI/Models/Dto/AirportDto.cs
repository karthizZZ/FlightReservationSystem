using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementAPI.Models.Dto
{
    public class AirportDto
    {
        public int AirportID { get; set; }

        public string AirportName { get; set; }

        public string Location { get; set; }

        public string AirportCode { get; set; }
    }
}
