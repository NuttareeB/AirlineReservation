using AirlineReservationApp.AuthenticationService;
using System;
using System.Linq;
using System.Security.Principal;

namespace AirlineReservationApp
{
    public class CustomPrincipal : IPrincipal
    {
        private CustomIdentity _identity;

        public CustomIdentity Identity
        {
            get { return _identity ?? new AnonymousIdentity(); }
            set { _identity = value; }
        }

        #region IPrincipal Members
        IIdentity IPrincipal.Identity
        {
            get { return Identity; }
        }

        public bool IsInRole(string role)
        {
            if (_identity == null || _identity.Roles == null)
            {
                return false;
            }
            if (Enum.TryParse(role, out Role currentRole))
            {
                return _identity.Roles.Contains(currentRole);
            }

            return false;
        }
        #endregion
    }
}
