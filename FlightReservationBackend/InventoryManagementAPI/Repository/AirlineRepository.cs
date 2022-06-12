using AutoMapper;
using InventoryManagementAPI.DbContexts;
using InventoryManagementAPI.Models;
using InventoryManagementAPI.Models.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementAPI.Repository
{
    public class AirlineRepository : IAirlineRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public AirlineRepository(ApplicationDbContext db,IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<bool> BlockAirline(int AirlineID)
        {
            try
            {
                Airline airline = await _db.Airline.FirstOrDefaultAsync(u => u.AirlineID == AirlineID);
                if (airline == null)
                {
                    return false;
                }
                airline.IsBlocked = true;
                _db.Airline.Update(airline);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<AirlineDto> CreateUpdateAirline(AirlineDto airlineDto)
        {
            Airline airline = _mapper.Map<AirlineDto, Airline>(airlineDto);
            if (airline.AirlineID > 0)
            {
                _db.Airline.Update(airline);
            }
            else
            {
                _db.Airline.Add(airline);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<Airline, AirlineDto>(airline);
        }

        public async Task<AirlineDto> GetAirlineById(int AirlineID)
        {
            Airline airline = await _db.Airline.Where(x => x.AirlineID == AirlineID).FirstOrDefaultAsync(); ;
            return _mapper.Map<AirlineDto>(airline);
        }

        public async Task<IEnumerable<AirlineDto>> GetAirlines()
        {
            IEnumerable<Airline> AirlineList = await _db.Airline.ToListAsync();
            return _mapper.Map<List<AirlineDto>>(AirlineList);
        }
    }
}
