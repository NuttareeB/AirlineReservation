using Enum;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Model
{
    [DataContract]
    public class FlightSeatInfo
    {
        [DataMember]
        public SeatClass SeatClass { get; set; }

        [DataMember]
        public List<List<int>> SeatMatrix { get; set; }
    }
}
