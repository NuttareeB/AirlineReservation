using AirlineReservationApp.AuthenticationService;
using AirlineReservationApp.FlightService;
using System;
using System.ComponentModel;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace AirlineReservationApp
{
    /// <summary>
    /// Interaction logic for FlightDetails.xaml
    /// </summary>
    public partial class FlightDetails : Page
    {
        public FlightDetails()
        {
            InitializeComponent();
            DataContext = new FlightDetailsViewModel();

            var client = new FlightServiceClient();
            flightDataGrid.ItemsSource =  client.RetrieveAvailableFlightInformation();
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            var addFlight = new AddFlight();
            NavigationService.Navigate(addFlight);
        }

        private void Seat_Button_Click(object sender, RoutedEventArgs e)
        {
            if(flightDataGrid.SelectedItems != null && flightDataGrid.SelectedItems.Count > 0)
            {
                var seatChart = new SeatChart(flightDataGrid.SelectedItems[0]);
                NavigationService.Navigate(seatChart);
            }
        }

        private void BuyTicket_Button_Click(object sender, RoutedEventArgs e)
        {
            if (flightDataGrid.SelectedItems != null && flightDataGrid.SelectedItems.Count > 0)
            {
                var booking = new Booking(flightDataGrid.SelectedItems[0]);
                NavigationService.Navigate(booking);
            }
        }
    }
}
