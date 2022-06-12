using InventoryManagementAPI.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementAPI.Repository
{
    public interface IAirlineScheduleRepository
    {

        Task<IEnumerable<AirlineScheduleDto>> GetAirlineSchedule();

        Task<AirlineScheduleMasterDto> GetScheduleByID(int AirlineID);

        Task<bool> CreateUpdateSchedule(AirlineScheduleMasterDto airlineScheduleDto);

        Task<bool> DeleteSchedule(int AirlineID);

        Task<List<AirlineSearchDto>> GetSearchResults(SearchInputDto InputData);
    }
}
