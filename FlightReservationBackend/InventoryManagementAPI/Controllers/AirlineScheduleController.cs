using InventoryManagementAPI.MessageBus;
using InventoryManagementAPI.Models.Dto;
using InventoryManagementAPI.RabbitMQSender;
using InventoryManagementAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementAPI.Controllers
{
    [Route("api/airlineschedule")]
    public class AirlineScheduleController : ControllerBase
    {
        protected ResponseDto _response;
        private IAirlineScheduleRepository _airlineScheduleRepository;
        private readonly IRabbitMQBookingMessageSender _rabbitMQBookingMessageSender;

        public AirlineScheduleController(IAirlineScheduleRepository airlineScheduleRepository, 
            IRabbitMQBookingMessageSender rabbitMQBookingMessageSender)
        {
            _airlineScheduleRepository = airlineScheduleRepository;
            _rabbitMQBookingMessageSender = rabbitMQBookingMessageSender;
            this._response = new ResponseDto();
        }

        [Route("Add")]
        [HttpPost]
        public async Task<object> Add([FromBody]AirlineScheduleMasterDto airlineSchedule)
        {
            try
            {
                bool IsSuccess = await _airlineScheduleRepository.CreateUpdateSchedule(airlineSchedule);
                _response.Result = IsSuccess;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [Route("Update")]
        [HttpPut]
        public async Task<object> Update([FromBody] AirlineScheduleMasterDto airlineScheduleDto)
        {
            try
            {
                bool IsSuccess = await _airlineScheduleRepository.CreateUpdateSchedule(airlineScheduleDto);
                _response.Result = IsSuccess;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPut]
        [Route("Delete/{id}")]
        public async Task<object> Delete(int id)
        {
            try
            {
                bool isSuccess = await _airlineScheduleRepository.DeleteSchedule(id);
                _response.Result = isSuccess;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpGet]
        [Route("Get/{id}")]
        public async Task<object> Get(int id)
        {
            try
            {
                AirlineScheduleMasterDto airlineScheduleDto = await _airlineScheduleRepository.GetScheduleByID(id);
                _response.Result = airlineScheduleDto;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<AirlineScheduleDto> airlineScheduleDto = await _airlineScheduleRepository.GetAirlineSchedule();
                _response.Result = airlineScheduleDto;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPost]
        [Route("Search")]
        public async Task<object> GetSearchResult([FromBody] SearchInputDto searchInput)
        {
            try
            {
                List<AirlineSearchDto> airlineSearchDto = await _airlineScheduleRepository.GetSearchResults(searchInput);
                _response.Result = airlineSearchDto;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPost()]
        [Route("BookSchedule")]
        public async Task<object> BookSchedule([FromBody]BookingInputDto bookingInput)
        {
            try
            {
                //CartDto cartDto = await _cartRepository.GetCartByUserId(checkoutHeader.UserId);
                //if (cartDto == null)
                //{
                //    return BadRequest();
                //}

                //if (!string.IsNullOrEmpty(checkoutHeader.CouponCode))
                //{
                //    CouponDto coupon = await _couponRepository.GetCoupon(checkoutHeader.CouponCode);
                //    if (checkoutHeader.DiscountTotal != coupon.DiscountAmount)
                //    {
                //        _response.IsSuccess = false;
                //        _response.ErrorMessages = new List<string>() { "Coupon Price has changed, please confirm" };
                //        _response.DisplayMessage = "Coupon Price has changed, please confirm";
                //        return _response;
                //    }
                //}

                //checkoutHeader.CartDetails = cartDto.CartDetails;
                //logic to add message to process order.
                //await _messageBus.PublishMessage(checkoutHeader, "checkoutqueue");

                ////rabbitMQ
                _rabbitMQBookingMessageSender.SendMessage(bookingInput, "bookingqueue");
                //await _cartRepository.ClearCart(checkoutHeader.UserId);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
    }
}
