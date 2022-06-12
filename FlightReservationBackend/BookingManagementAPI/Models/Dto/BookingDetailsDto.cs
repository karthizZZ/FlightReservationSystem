﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookingManagementAPI.Models
{
    public class BookingDetailsDto
    {
        public int BookingID { get; set; }

        public int AirlineID { get; set; }

        public int FlightNumber { get; set; }

        public string AirlineName { get; set; }

        public DateTime BookingDate { get; set; }

        public string MealType { get; set; }

        public int NoOfPassengers { get; set; }

        public string Email { get; set; }

        public string SeatType { get; set; }

        public string PNR { get; set; }

        public string PaymentStatus { get; set; }

        public bool IsCancelled { get; set; }

        public int CreatedUserID { get; set; }

        public DateTime CreatedDate { get; set; }

        public List<BookingPassengerRelnDto> PassengerList { get; set; }

        public List<BookingSeatNoRelnDto> BookedSeatList { get; set; }
    }
}