using InventoryManagementAPI.Models.Dto;
using InventoryManagementAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementAPI.Controllers
{
    [Route("api/airline")]
    public class AirlineManagementController : ControllerBase
    {
        protected ResponseDto _response;
        private IAirlineRepository _airlineRepository;

        public AirlineManagementController(IAirlineRepository airlineRepository)
        {
            _airlineRepository = airlineRepository;
            this._response = new ResponseDto();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("Get")]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<AirlineDto> airlineDto = await _airlineRepository.GetAirlines();
                _response.Result = airlineDto;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("Get/{id}")]
        public async Task<object> Get(int id)
        {
            try
            {
                AirlineDto airlineDto = await _airlineRepository.GetAirlineById(id);
                _response.Result = airlineDto;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("Add")]
        public async Task<object> Post([FromBody] AirlineDto airlineDto)
        {
            try
            {
                AirlineDto model = await _airlineRepository.CreateUpdateAirline(airlineDto);
                _response.Result = model;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        [Route("Update")]
        public async Task<object> Put([FromBody] AirlineDto airlineDto)
        {
            try
            {
                AirlineDto model = await _airlineRepository.CreateUpdateAirline(airlineDto);
                _response.Result = model;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        /// <summary>
        /// Block an airline
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpPut]
        [Route("Block/{id}")]
        public async Task<object> Block(int id)
        {
            try
            {
                bool isSuccess = await _airlineRepository.BlockAirline(id);
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

        [AllowAnonymous]
        [HttpGet]
        [Route("GetAirports")]
        public async Task<object> GetAirports()
        {
            try
            {
                IEnumerable<AirportDto> airportDto = await _airlineRepository.GetAirports();
                _response.Result = airportDto;
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
