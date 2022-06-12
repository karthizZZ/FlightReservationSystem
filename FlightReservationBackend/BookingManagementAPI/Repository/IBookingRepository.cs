using BookingManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingManagementAPI.Repository
{
    public interface IBookingRepository
    {
        Task<bool> BookFlight(BookingDetailsDto bookingDetailsDto);

        Task<bool> CancelBookedFlight(string PNR);
    }
}
