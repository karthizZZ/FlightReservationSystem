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

        Task<List<BookingDetailsDto>> GetBookingDetailsList(string Email);

        Task<List<BookingDetailsDto>> GetBookingDetailsListbyId(int Id);

    }
}
