using DataAccess;
using Enum;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineReservationLib
{
    public class BookingService : IBookingService
    {
        public List<FlightSeatInfo> RetrieveOccupiedSeatsMatrixFromFlightId(Guid flightId)
        {
            try
            {
                var bookingProvider = new BookingDataProvider();
                var occupiedSeats = bookingProvider.GetOccupiedSeatsFromFlightId(flightId);
                var flightProvider = new FlightDataProvider();
                var flightInfo = flightProvider.GetFlightAndPlaneDetailsByFlightId(flightId);

                if (flightInfo == null || occupiedSeats == null)
                {
                    return new List<FlightSeatInfo>();
                }

                var seatInfos = new List<FlightSeatInfo>();


                var firstClassSeatInfo = new FlightSeatInfo
                {
                    SeatClass = SeatClass.FirstClass,
                    SeatMatrix = new List<List<int>>()
                };

                for (int i = 0; i < flightInfo.NoRow_FirstClass; i++)
                {
                    firstClassSeatInfo.SeatMatrix.Add(new List<int>());
                    for (int j = 0; j < flightInfo.NoCol_FirstClass; j++)
                    {
                        firstClassSeatInfo.SeatMatrix[i].Add(0);
                    }
                }
                seatInfos.Add(firstClassSeatInfo);

                var economyClassSeatInfo = new FlightSeatInfo
                {
                    SeatClass = SeatClass.Economy,
                    SeatMatrix = new List<List<int>>()
                };

                for (int i = 0; i < flightInfo.NoRow_EcoClass; i++)
                {
                    economyClassSeatInfo.SeatMatrix.Add(new List<int>());
                    for (int j = 0; j < flightInfo.NoCol_EcoClass; j++)
                    {
                        economyClassSeatInfo.SeatMatrix[i].Add(0);
                    }
                }
                seatInfos.Add(economyClassSeatInfo);

                foreach (SeatPositionDao seat in occupiedSeats)
                {
                    //First Class seat
                    if (seat.Class == SeatClass.FirstClass
                        && seat.SeatRow < flightInfo.NoRow_FirstClass
                        && seat.SeatCol < flightInfo.NoCol_FirstClass)
                    {
                        var firstClassSeatMatrix = seatInfos.Where(s => s.SeatClass == SeatClass.FirstClass).FirstOrDefault();
                        if (firstClassSeatMatrix != null)
                        {
                            firstClassSeatMatrix.SeatMatrix[seat.SeatRow][seat.SeatCol] = 1;
                        }
                    }
                    else if (seat.Class == SeatClass.Economy
                        && seat.SeatRow < flightInfo.NoRow_EcoClass
                        && seat.SeatCol < flightInfo.NoCol_EcoClass)
                    {
                        //Economy Class seat
                        var economyClassSeatMatrix = seatInfos.Where(s => s.SeatClass == SeatClass.Economy).FirstOrDefault();
                        if (economyClassSeatMatrix != null)
                        {
                            economyClassSeatMatrix.SeatMatrix[seat.SeatRow][seat.SeatCol] = 1;
                        }
                    }
                }

                return seatInfos;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string BookTicket(BookingDetailRequest bookingDetail)
        {
            try
            {
                var bookingProvider = new BookingDataProvider();
                var bookingId = bookingProvider.InsertBookingDetails(bookingDetail);
                return bookingId;
            }
            catch (Exception)
            {
                return "";
            }
        }
    }
}
