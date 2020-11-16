using AirlineReservationApp.AuthenticationService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace AirlineReservationApp
{
    public class CustomIdentity : IIdentity
    {
        public CustomIdentity(string firstName, string lastName, short age, List<Role> roles)
        {
            Name = firstName;
            LastName = lastName;
            Age = age;
            Roles = roles;
        }

        public short Age { get; private set; }
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public List<Role> Roles { get; private set; }

        #region IIdentity Members
        public string AuthenticationType { get { return "Custom authentication"; } }

        public bool IsAuthenticated { get { return !string.IsNullOrEmpty(Name); } }
        #endregion
    }
}
