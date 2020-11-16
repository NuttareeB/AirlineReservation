using AirlineReservationLib;
using System;
using System.Runtime.Serialization;

namespace Model
{
    [DataContract]
    public class FlightAndPlaneDetailDao : PlaneDetailDao
    {

        [DataMember]
        public Guid FlightId { get; set; }

        [DataMember]
        public string FlightNo { get; set; }

        [DataMember]
        public string DepartureAirport { get; set; }

        [DataMember]
        public string ArrivalAirport { get; set; }

        [DataMember]
        public DateTime DepartureTime { get; set; }

        [DataMember]
        public DateTime ArrivalTime { get; set; }

        [DataMember]
        public decimal FirstClassPrice { get; set; }

        [DataMember]
        public decimal EconomyClassPrice { get; set; }

        [DataMember]
        public bool IsAvailable { get; set; }

        [DataMember]
        public int? FirstClassCapacity { get; set; }

        [DataMember]
        public int? EcoClassCapacity { get; set; }
    }
}
