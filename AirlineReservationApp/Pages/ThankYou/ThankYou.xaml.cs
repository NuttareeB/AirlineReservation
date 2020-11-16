using AirlineReservationApp.AuthenticationService;
using AirlineReservationApp.BookingService;
using AirlineReservationApp.FlightService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AirlineReservationApp
{
    /// <summary>
    /// Interaction logic for Thankyou.xaml
    /// </summary>
    public partial class ThankYou : Page
    {
        public ThankYou()
        {
            InitializeComponent();
        }
        public ThankYou(string bookingId, FlightInfo flightInfo, User user, SeatClass seatClass, int selectedRow, int selectedCol) : this()
        {
            flightDetailGrid.DataContext = flightInfo;
            userDetailGrid.DataContext = user.UserDao;
            DataContext = new ThankYouViewModel(bookingId, seatClass, selectedRow, selectedCol);
        }
    }
}
