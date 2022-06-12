using AutoMapper;
using InventoryManagementAPI.DbContexts;
using InventoryManagementAPI.Models;
using InventoryManagementAPI.Models.Dto;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementAPI.Repository
{
    public class AirlineScheduleRepository : IAirlineScheduleRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public AirlineScheduleRepository(ApplicationDbContext db,IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async  Task<bool> CreateUpdateSchedule(AirlineScheduleMasterDto airlineScheduleDto)
        {
            if (airlineScheduleDto != null)
            {
                AirlineScheduleMaster airlineScheduleMaster = _mapper.Map<AirlineScheduleMasterDto, AirlineScheduleMaster>
                (airlineScheduleDto);
                if (airlineScheduleMaster.AirlineSchedule.AirlineScheduleID > 0)
                {
                    _db.AirlineSchedule.Update(airlineScheduleMaster.AirlineSchedule);
                    await _db.SaveChangesAsync();
                    if (airlineScheduleMaster.AirlineScheduleDays != null)
                    {
                        foreach (var item in airlineScheduleMaster.AirlineScheduleDays)
                        {
                            item.AirlineScheduleID = airlineScheduleMaster.AirlineSchedule.AirlineScheduleID;
                        }
                        _db.AirlineScheduleDayReln.UpdateRange(airlineScheduleMaster.AirlineScheduleDays);
                    }
                    foreach (var item in airlineScheduleMaster.AirlineSeatCostDetails)
                    {
                        item.FlightID = airlineScheduleMaster.AirlineSchedule.AirlineScheduleID;
                    }
                    _db.AirlineSeatCostReln.UpdateRange(airlineScheduleMaster.AirlineSeatCostDetails);
                }
                else
                {
                    _db.AirlineSchedule.Add(airlineScheduleMaster.AirlineSchedule);
                    await _db.SaveChangesAsync();
                    if (airlineScheduleMaster.AirlineScheduleDays != null)
                    {
                        foreach (var item in airlineScheduleMaster.AirlineScheduleDays)
                        {
                            item.AirlineScheduleID = airlineScheduleMaster.AirlineSchedule.AirlineScheduleID;
                        }
                        _db.AirlineScheduleDayReln.AddRange(airlineScheduleMaster.AirlineScheduleDays);
                    }
                    foreach (var item in airlineScheduleMaster.AirlineSeatCostDetails)
                    {
                        item.FlightID = airlineScheduleMaster.AirlineSchedule.AirlineScheduleID;
                    }
                    _db.AirlineSeatCostReln.AddRange(airlineScheduleMaster.AirlineSeatCostDetails);
                }
                await _db.SaveChangesAsync();

                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> DeleteSchedule(int AirlineScheduleID)
        {
            try
            {
                AirlineSchedule airlineSchedule = await _db.AirlineSchedule.FirstOrDefaultAsync(u => u.AirlineScheduleID == AirlineScheduleID);
                if (airlineSchedule == null)
                {
                    return false;
                }
                airlineSchedule.IsDeleted = true;
                _db.AirlineSchedule.Update(airlineSchedule);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<AirlineScheduleDto>> GetAirlineSchedule()
        {
            IEnumerable<AirlineSchedule> ScheduleList = await _db.AirlineSchedule.Where(x => x.IsDeleted != true).ToListAsync();
            return _mapper.Map<List<AirlineScheduleDto>>(ScheduleList);
        }

        public async Task<AirlineScheduleMasterDto> GetScheduleByID(int AirlineScheduleID)
        {
            AirlineScheduleMaster objData = new AirlineScheduleMaster();
            objData.AirlineSchedule = await _db.AirlineSchedule.Where(x => x.AirlineScheduleID == AirlineScheduleID).FirstOrDefaultAsync();
            objData.AirlineScheduleDays = await _db.AirlineScheduleDayReln.Where(x => x.AirlineScheduleID == AirlineScheduleID).ToListAsync();
            objData.AirlineSeatCostDetails = await _db.AirlineSeatCostReln.Where(x => x.FlightID == AirlineScheduleID).ToListAsync();

            return _mapper.Map<AirlineScheduleMasterDto>(objData);
        }

        public async Task<List<AirlineSearchDto>> GetSearchResults(SearchInputDto InputData)
        {
            var FromAirportParam = new SqlParameter("@FromAirportID", InputData.FromAirportID);
            var ToAirportParam = new SqlParameter("@ToAirportID", InputData.ToAirportID);
            var TravelDateParam = new SqlParameter("@TravelDate", InputData.TravelDate);
            var SeatTypeParam = new SqlParameter("@SeatType", InputData.SeatType);
            var NoOfTicketParam = new SqlParameter("@NoOfTickets", InputData.NoOfTickets);

            List<AirlineSearch> objData = new List<AirlineSearch>();
            objData = await _db.AirlineSearchDetails.FromSqlRaw("exec GetAirlinesearchResult @FromAirportID , @ToAirportID,@TravelDate,@SeatType,@NoOfTickets",
                        FromAirportParam,
                        ToAirportParam,
                        TravelDateParam,
                        SeatTypeParam,
                        NoOfTicketParam).ToListAsync();
            return _mapper.Map<List<AirlineSearchDto>>(objData);
        }
    }
}
