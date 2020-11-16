using DataAccess;
using System.ServiceModel;

namespace AirlineReservationLib
{
    [ServiceContract(Namespace = "http://AirplaneReservationLib")]
    public interface IAuthenticationService
    {
        [OperationContract]
        User AuthenticateUser(string username, string clearTextPassword);
    }
}