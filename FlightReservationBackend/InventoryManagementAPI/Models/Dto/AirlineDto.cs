using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementAPI.Models.Dto
{
    public class AirlineDto
    {
        public int AirlineID { get; set; }

        public string AirlineName { get; set; }

        public string ContactNumber { get; set; }

        public string ContactAddress { get; set; }

        public string AirlineLogo { get; set; }

        public bool IsBlocked { get; set; }
    }
}
