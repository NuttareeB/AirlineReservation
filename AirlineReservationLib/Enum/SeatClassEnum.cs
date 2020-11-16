using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Enum
{
    [DataContract(Name = "SeatClass")]
    public enum SeatClass
    {
        [EnumMember]
        FirstClass = 1,
        [EnumMember]
        Economy = 2
    }
}
