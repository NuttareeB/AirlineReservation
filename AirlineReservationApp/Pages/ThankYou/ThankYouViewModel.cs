using AirlineReservationApp.BookingService;
using Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineReservationApp
{
    public class ThankYouViewModel
    {
        public ThankYouViewModel(string bookingId, SeatClass seatClass, int selectedRow, int selectedCol)
        {
            SelectedClass = seatClass.ToString();
            SelectedRow = selectedRow.ToAlphabet();
            SelectedCol = (selectedCol+1).ToString();
            BookingSucceedText = "Congraduration! Your booking id is " + bookingId + ".";
        }
        public string BookingSucceedText { get; private set; }
        public string SelectedClass { get; set; }
        public string SelectedRow { get; set; }
        public string SelectedCol { get; set; }
    }
}
