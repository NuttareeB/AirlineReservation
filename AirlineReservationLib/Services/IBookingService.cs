using DataAccess;
using Enum;
using Model;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace AirlineReservationLib
{
    [ServiceContract(Namespace = "http://AirplaneReservationLib")]
    public interface IBookingService
    {
        [OperationContract]
        List<FlightSeatInfo> RetrieveOccupiedSeatsMatrixFromFlightId(Guid flightId);
        [OperationContract]
        string BookTicket(BookingDetailRequest bookingDetail);
    }
}