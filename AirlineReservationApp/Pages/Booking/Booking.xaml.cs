using AirlineReservationApp.AuthenticationService;
using AirlineReservationApp.FlightService;
using AirlineReservationApp.BookingService;
using Extensions;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Threading;

namespace AirlineReservationApp
{
    /// <summary>
    /// Interaction logic for Booking.xaml
    /// </summary>
    public partial class Booking : Page
    {
        public FlightInfo BookingFlightInfo { get; set; }
        public string FirstNameTextbox => firstNameTextbox.Text;
        public string LastNameTextbox => lastNameTextbox.Text;
        public string AgeTextbox => ageTextbox.Text;
        public string TicketClassCombobox => ((ComboBoxItem)ticketClassCombobox.SelectedItem).Tag.ToString();

        public Booking()
        {
            InitializeComponent();
            firstNameTextbox.Text = Thread.CurrentPrincipal.Identity.Name;
        }

        public Booking(object flightInfoData) : this()
        {
            BookingFlightInfo = (FlightInfo)flightInfoData;
            flightDetailGrid.DataContext = BookingFlightInfo;
        }

        private void SelectSeat_Button_Click(object sender, RoutedEventArgs e)
        {
            if (!Enum.TryParse(TicketClassCombobox, out SeatClass ticketClass))
            {
                ticketClass = SeatClass.Economy;
            }
            var user = new User()
            {
                UserDao = new UserDao()
                {
                    FirstName = FirstNameTextbox,
                    LastName = LastNameTextbox,
                    Age = AgeTextbox.ToShortOrDefault()
                }
            };
            var seatChart = new SeatChart(BookingFlightInfo, user, ticketClass);
            NavigationService.Navigate(seatChart);
        }
    }
}
