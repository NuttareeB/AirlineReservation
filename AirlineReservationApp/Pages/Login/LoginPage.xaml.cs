using AirlineReservationApp.AuthenticationService;
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
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            DataContext = new AuthenticationViewModel(new AuthenticationServiceClient());
            InitializeComponent();
        }

        private void FlightDetails_Button_Click(object sender, RoutedEventArgs e)
        {
                var flight = new FlightDetails();
                NavigationService.Navigate(flight);
        }
        private void Guest_Button_Click(object sender, RoutedEventArgs e)
        {
            var flight = new FlightDetails();
            NavigationService.Navigate(flight);
        }
    }
}
