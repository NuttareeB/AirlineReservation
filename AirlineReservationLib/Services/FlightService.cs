using DataAccess;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AirlineReservationLib
{
    public class FlightService : IFlightService
    {
        public List<PlaneDetailDao> RetrieveAllPlaneInformation()
        {
            try
            {
                var planeDataProvider = new PlaneDataProvider();
                return planeDataProvider.GetPlaneDetails();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<FlightInfo> RetrieveAllFlightInformation()
        {
            var flightInfos = new List<FlightInfo>();
            try {
                var flightDataProvider = new FlightDataProvider();
                var flightDetails = flightDataProvider.GetAllFlightAndPlaneDetails();

                foreach (var detail in flightDetails)
                {
                    var flightInfo = new FlightInfo(detail);
                    flightInfo.CalculatedFirstClassCapacity = detail.FirstClassCapacity ?? detail.NoRow_FirstClass * detail.NoCol_FirstClass;
                    flightInfo.CalculatedEconomyClassCapacity = detail.EcoClassCapacity ?? detail.NoRow_EcoClass * detail.NoCol_EcoClass;
                    flightInfos.Add(flightInfo);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return flightInfos;
        }

        public List<FlightInfo> RetrieveAvailableFlightInformation()
        {
            try
            {
                return RetrieveAllFlightInformation().Where(flight => flight.IsAvailable == true).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool InsertFlightInfo(FlightInfo flightInfo)
        {
            try
            {
                var flightDataProvider = new FlightDataProvider();

                flightDataProvider.InsertFlightDetails(flightInfo);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
