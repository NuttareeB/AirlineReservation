using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Enum
{
    [DataContract(Name = "Role")]
    public enum Role
    {
        [EnumMember]
        Admin = 1,
        [EnumMember]
        User = 2
    }
}
