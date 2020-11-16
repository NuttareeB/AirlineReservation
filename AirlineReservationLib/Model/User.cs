using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    [DataContract]
    public class User
    {
        [DataMember]
        public UserDao UserDao { get; set; }
    }
}
