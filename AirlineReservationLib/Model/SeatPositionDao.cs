using Enum;
using System.Runtime.Serialization;

namespace Model
{
    [DataContract]
    public class SeatPositionDao
    {
        [DataMember]
        public short SeatRow { get; set; }
        [DataMember]
        public short SeatCol { get; set; }
        [DataMember]
        public SeatClass Class { get; set; }
    }
}
