using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [DataContract]
    public class PlaneDetailDao
    {
        [DataMember]
        public Guid PlaneId { get; set; }

        [DataMember]
        public string PlaneType { get; set; }

        [DataMember]
        public short NoRow_FirstClass { get; set; }

        [DataMember]
        public short NoCol_FirstClass { get; set; }

        [DataMember]
        public short NoRow_EcoClass { get; set; }

        [DataMember]
        public short NoCol_EcoClass { get; set; }
    }
}
