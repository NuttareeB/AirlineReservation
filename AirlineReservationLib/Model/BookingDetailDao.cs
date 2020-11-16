using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [DataContract]
    public class BookingDetailDao : SeatPositionDao
    {
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public Guid FlightId { get; set; }
        [DataMember]
        public Guid CustomerId { get; set; }
    }
}
