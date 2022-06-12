﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementAPI.MessageBus
{
    public class BookingInputDto: BaseMessage
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

        public List<PassengerDetailsDto> PassengerList { get; set; }

        public List<SeatNoDetailsDto> BookedSeatList { get; set; }
    }
}
