using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementAPI.Models.Dto
{
    public class AirlineScheduleMasterDto
    {

        public AirlineScheduleDto AirlineSchedule { get; set; }

        public IEnumerable<AirlineSeatCostRelnDto> AirlineSeatCostDetails { get; set; }

        public IEnumerable<AirlineScheduleDayRelnDto> AirlineScheduleDays { get; set; }
    }
}
