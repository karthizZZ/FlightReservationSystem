using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementAPI.Models
{
    public class AirlineScheduleMaster
    {
        public AirlineSchedule AirlineSchedule { get; set; }

        public IEnumerable<AirlineSeatCostReln> AirlineSeatCostDetails {get;set;}

        public IEnumerable<AirlineScheduleDayReln> AirlineScheduleDays { get; set; }
    }
}
