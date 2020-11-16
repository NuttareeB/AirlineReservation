using DataAccess;
using Model;
using System.Collections.Generic;
using System.ServiceModel;

namespace AirlineReservationLib
{
    [ServiceContract(Namespace = "http://AirplaneReservationLib")]
    public interface IFlightService
    {
        [OperationContract]
        bool InsertFlightInfo(FlightInfo flightInfo);

        [OperationContract]
        List<FlightInfo> RetrieveAllFlightInformation();

        [OperationContract]
        List<PlaneDetailDao> RetrieveAllPlaneInformation();

        [OperationContract]
        List<FlightInfo> RetrieveAvailableFlightInformation();
    }
}