using AirlineReservationApp.FlightService;
using Extensions;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace AirlineReservationApp
{
    /// <summary>
    /// Interaction logic for AddFlight.xaml
    /// </summary>
    public partial class AddFlight : Page
    {
        public string FlightNoTextbox => flightNoTextbox.Text;
        public string DepartureAirportTextbox => departureAirportTextbox.Text;
        public string ArrivalAirportTextbox => arrivalAirportTextbox.Text;
        public DateTime DepartureDateTime
        {
            get
            {
                var selectedDate = departureDate.SelectedDate;
                if (selectedDate != null) {
                    var date = (DateTime)selectedDate;
                    return new DateTime(date.Year, date.Month, date.Day, departureHoursCombobox.Text.ToIntOrDefault(), departureMinutesCombobox.Text.ToIntOrDefault(), 0);
                }
                else
                {
                    return new DateTime();
                }
            }
        }
        public DateTime ArrivalDateTime
        {
            get
            {
                var selectedDate = arrivalDate.SelectedDate;
                if (selectedDate != null)
                {
                    var date = (DateTime)selectedDate;
                    return new DateTime(date.Year, date.Month, date.Day, arrivalHoursCombobox.Text.ToIntOrDefault(), arrivalMinutesCombobox.Text.ToIntOrDefault(), 0);
                }
                else
                {
                    return new DateTime();
                }
            }
        }
        public decimal FirstClassPriceTextbox => firstClassPriceTextbox.Text.ToDecimalOrDefault();
        public decimal EconomyClassPriceTextbox => economyClassPriceTextbox.Text.ToDecimalOrDefault();
        public int? FirstClassCapacityTextbox
        {
            get
            {
                var capacity = firstClassCapacityTextbox.Text;
                if(capacity!= string.Empty)
                {
                    return firstClassCapacityTextbox.Text.ToIntOrDefault();
                }
                else
                {
                    return null;
                }
            }
        }
        public int? EconomyClassCapacityTextbox
        {
            get
            {
                var capacity = economyClassCapacityTextbox.Text;
                if (capacity != string.Empty)
                {
                    return firstClassCapacityTextbox.Text.ToIntOrDefault();
                }
                else
                {
                    return null;
                }
            }
        }
        public bool IsAvailable => isAvailableCheckbox.IsChecked ?? false;

        public AddFlight()
        {
            InitializeComponent();
            var allAvailablePlanes = GetAllAvailablePlanes();

            planeTypeCombobox.DisplayMemberPath = "PlaneType";
            planeTypeCombobox.SelectedValuePath = "PlaneType";
            planeTypeCombobox.ItemsSource = allAvailablePlanes;
            planeTypeCombobox.Text = "Choose Type";
        }

        private PlaneDetailDao[] GetAllAvailablePlanes()
        {
            var flightServiceClient = new FlightServiceClient();
            return flightServiceClient.RetrieveAllPlaneInformation();
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(DepartureDateTime);

            Console.WriteLine(ArrivalDateTime);
            bool success = false;
            try
            {
                var planeDetail = (PlaneDetailDao)planeTypeCombobox.SelectedItem;

                var flightInfo = new FlightInfo()
                {
                    FlightNo = FlightNoTextbox,
                    PlaneId = planeDetail.PlaneId,
                    DepartureAirport = DepartureAirportTextbox,
                    ArrivalAirport = ArrivalAirportTextbox,
                    DepartureTime = DepartureDateTime,
                    ArrivalTime = ArrivalDateTime,
                    FirstClassPrice = FirstClassPriceTextbox,
                    EconomyClassPrice = EconomyClassPriceTextbox,
                    FirstClassCapacity = FirstClassCapacityTextbox,
                    EcoClassCapacity = EconomyClassCapacityTextbox,
                    IsAvailable = IsAvailable,
                };

                var flightServiceClient = new FlightServiceClient();
                success = flightServiceClient.InsertFlightInfo(flightInfo);
            }
            catch(Exception)
            {
                
            }


            if (success)
            {
                var flightDetails = new FlightDetails();
                NavigationService.Navigate(flightDetails);
            }
            else
            {
                ErrorDisplay.Text = "Cannot add flight information. Invalid input.";
            }
        }
    }
}
