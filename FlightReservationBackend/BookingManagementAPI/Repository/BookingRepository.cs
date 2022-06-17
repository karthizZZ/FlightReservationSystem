using AutoMapper;
using BookingManagementAPI.DbContexts;
using BookingManagementAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingManagementAPI.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly DbContextOptions<ApplicationDbContext> _dbContext;
        private IMapper _mapper;

        public BookingRepository(DbContextOptions<ApplicationDbContext> dbContext,IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<bool> BookFlight(BookingDetailsDto bookingDetailsDto)
        {
            await using var _db = new ApplicationDbContext(_dbContext);
            if (bookingDetailsDto != null)
            {
                BookingDetails bookingDetails = _mapper.Map<BookingDetailsDto, BookingDetails>(bookingDetailsDto);
                Random random = new Random();
                bookingDetails.PNR = random.Next(100000, 999999).ToString();
                _db.BookingDetails.Add(bookingDetails);
                await _db.SaveChangesAsync();
                var BookedID = bookingDetails.BookingID;
                try
                {
                    foreach (var Item in bookingDetailsDto.PassengerList)
                    {
                        Item.BookingRefNumber = BookedID;
                    }
                    List<BookingPassengerReln> passengerDetails = _mapper.Map<List<BookingPassengerReln>>
                        (bookingDetailsDto.PassengerList);
                    _db.PassengerDetails.AddRange(passengerDetails);
                    await _db.SaveChangesAsync();

                    foreach (var Item in bookingDetailsDto.BookedSeatList)
                    {
                        Item.BookingNumber = BookedID;
                    }
                    List<BookingSeatNoReln> SeatDetails = _mapper.Map<List<BookingSeatNoReln>>
                        (bookingDetailsDto.BookedSeatList);
                    _db.BookingSeatNumberRelation.AddRange(SeatDetails);
                    await _db.SaveChangesAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> CancelBookedFlight(string PNR)
        {
            await using var _db = new ApplicationDbContext(_dbContext);

            try
            {
                BookingDetails airline = await _db.BookingDetails.FirstOrDefaultAsync(u => u.PNR == PNR);
                if (airline == null)
                {
                    return false;
                }
                airline.IsCancelled = true;
                _db.BookingDetails.Update(airline);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<BookingDetailsDto>> GetBookingDetailsList(string Email)
        {
            await using var _db = new ApplicationDbContext(_dbContext);

            IEnumerable<BookingDetails> BookingList = await _db.BookingDetails.Where(x=>x.Email==Email).ToListAsync();
            return _mapper.Map<List<BookingDetailsDto>>(BookingList);
        }

        public async Task<List<BookingDetailsDto>> GetBookingDetailsListbyId(int Id)
        {
            await using var _db = new ApplicationDbContext(_dbContext);

            IEnumerable<BookingDetails> BookingList = await _db.BookingDetails.Where(x => x.CreatedUserID == Id).OrderByDescending(x=>x.CreatedDate).ToListAsync();
            return _mapper.Map<List<BookingDetailsDto>>(BookingList);
        }
    }
}
