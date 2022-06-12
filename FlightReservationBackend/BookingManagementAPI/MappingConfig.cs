using AutoMapper;
using BookingManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingManagementAPI
{
    public static class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<BookingDetailsDto, BookingDetails>().ReverseMap();
                config.CreateMap<BookingPassengerReln, BookingPassengerRelnDto>().ReverseMap();
                config.CreateMap<BookingSeatNoRelnDto, BookingSeatNoReln>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
