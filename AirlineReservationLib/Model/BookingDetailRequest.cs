using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [DataContract]
    public class BookingDetailRequest
    {
        [DataMember]
        public BookingDetailDao BookingDetailDao { get; set; }
        [DataMember]
        public string FirstName { get; private set; }
        [DataMember]
        public string LastName { get; private set; }
        [DataMember]
        public short Age { get; private set; }
    }
}
