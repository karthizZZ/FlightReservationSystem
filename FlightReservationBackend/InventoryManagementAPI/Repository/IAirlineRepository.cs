using InventoryManagementAPI.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementAPI.Repository
{
    public interface IAirlineRepository
    {
        Task<IEnumerable<AirlineDto>> GetAirlines();

        Task<AirlineDto> GetAirlineById(int AirlineID);

        Task<AirlineDto> CreateUpdateAirline(AirlineDto airlineDto);

        Task<bool> BlockAirline(int AirlineID);
    }
}
