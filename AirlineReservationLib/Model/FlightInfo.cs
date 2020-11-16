using DataAccess;
using System.Reflection;
using System.Runtime.Serialization;

namespace Model
{
    [DataContract]
    public class FlightInfo : FlightAndPlaneDetailDao
    {
        public FlightInfo() { }

        public FlightInfo(FlightAndPlaneDetailDao flightDetail)
        {
            foreach (PropertyInfo prop in flightDetail.GetType().GetProperties())
                GetType().GetProperty(prop.Name).SetValue(this, prop.GetValue(flightDetail, null), null);
        }

        [DataMember]
        public int CalculatedFirstClassCapacity { get; set; }

        [DataMember]
        public int CalculatedEconomyClassCapacity { get; set; }
    }
}
