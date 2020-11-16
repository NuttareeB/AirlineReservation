using AirlineReservationApp.AuthenticationService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AirlineReservationApp
{
    public class FlightDetailsViewModel
    {
        public bool IsShow
        {
            get
            {
                return Thread.CurrentPrincipal.IsInRole(Role.Admin.ToString());
            }
        }

    }
}
