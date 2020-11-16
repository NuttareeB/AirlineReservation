using AirlineReservationApp.AuthenticationService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineReservationApp
{
    public class AnonymousIdentity : CustomIdentity
    {
        public AnonymousIdentity()
            : base(string.Empty, string.Empty, 0, new List<Role> { })
        { }
    }
}
