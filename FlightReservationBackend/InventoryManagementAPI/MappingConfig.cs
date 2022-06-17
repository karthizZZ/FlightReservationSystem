using AutoMapper;
using InventoryManagementAPI.Models;
using InventoryManagementAPI.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<AirlineDto, Airline>();
                config.CreateMap<Airline, AirlineDto>();
                config.CreateMap<AirlineScheduleDayReln, AirlineScheduleDayRelnDto>().
                ReverseMap();
                config.CreateMap<AirlineScheduleDto, AirlineSchedule>().ReverseMap();
                config.CreateMap<AirlineSeatCostReln, AirlineSeatCostRelnDto>().
                ReverseMap();
                config.CreateMap<AirlineDto, Airport>().ReverseMap();
                config.CreateMap<AirlineScheduleMasterDto, AirlineScheduleMaster>()
                .ReverseMap();
                config.CreateMap<AirlineSearch, AirlineSearchDto>().ReverseMap();
                config.CreateMap<Airport, AirportDto>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
