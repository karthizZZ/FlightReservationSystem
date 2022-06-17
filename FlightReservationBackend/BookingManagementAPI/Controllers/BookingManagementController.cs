using BookingManagementAPI.Models;
using BookingManagementAPI.Models.Dto;
using BookingManagementAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingManagementAPI.Controllers
{
    [Route("api/booking")]
    public class BookingManagementController : ControllerBase
    {
        private IBookingRepository _bookingRepository;
        protected ResponseDto _response;

        public BookingManagementController(IBookingRepository bookingRepository )
        {
            _bookingRepository = bookingRepository;
            _response = new ResponseDto();
        }

        [Authorize]
        [HttpGet]
        [Route("Get/{email}")]
        public async Task<object> Get(string email)
        {
            try
            {
                IEnumerable<BookingDetailsDto> bookingDetailsDto = await _bookingRepository.GetBookingDetailsList(email);
                _response.Result = bookingDetailsDto;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [Authorize]
        [HttpGet]
        [Route("GetList/{id}")]
        public async Task<object> GetList(int id)
        {
            try
            {
                IEnumerable<BookingDetailsDto> bookingDetailsDto = await _bookingRepository.GetBookingDetailsListbyId(id);
                _response.Result = bookingDetailsDto;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [Authorize]
        [HttpPut]
        [Route("Cancel/{PNR}")]
        public async Task<object> Cancel(string PNR)
        {
            try
            {                
                _response.Result = await _bookingRepository.CancelBookedFlight(PNR); ;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }
    }
}
