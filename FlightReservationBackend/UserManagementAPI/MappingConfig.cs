using AutoMapper;
using UserManagementAPI.Models;
using UserManagementAPI.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagementAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                //config.CreateMap<AirlineDto, Airline>();
                //config.CreateMap<Airline, AirlineDto>();
                //config.CreateMap<AirlineScheduleDayReln, AirlineScheduleDayRelnDto>().
                //ReverseMap();
                //config.CreateMap<AirlineScheduleDto, AirlineSchedule>().ReverseMap();
                //config.CreateMap<AirlineSeatCostReln, AirlineSeatCostRelnDto>().
                //ReverseMap();
                //config.CreateMap<AirlineDto, Airport>().ReverseMap();
                //config.CreateMap<AirlineScheduleMasterDto, AirlineScheduleMaster>()
                //.ReverseMap();
                //config.CreateMap<AirlineSearch, AirlineSearchDto>().ReverseMap();
                //config.CreateMap<Airport, AirportDto>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
