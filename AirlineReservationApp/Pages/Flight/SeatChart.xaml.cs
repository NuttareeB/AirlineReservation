using AirlineReservationApp.AuthenticationService;
using AirlineReservationApp.BookingService;
using AirlineReservationApp.FlightService;
using Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace AirlineReservationApp
{
    /// <summary>
    /// Interaction logic for SeatChart.xaml
    /// </summary>
    public partial class SeatChart : Page
    {
        public FlightInfo FlightInformation { get; set; }
        public User UserInput { get; set; }
        public SeatClass SeatClass { get; set; }
        public int SelectedRow { get; set; }
        public int SelectedCol { get; set; }

        public SeatChart()
        {
            InitializeComponent();
        }

        public SeatChart(object flightInfoData) : this()
        {
            var flightInfo = (FlightInfo)flightInfoData;
            var client = new BookingServiceClient();
            var seatInfos = client.RetrieveOccupiedSeatsMatrixFromFlightId(flightInfo.FlightId).ToList();
            MapSeatData(seatInfos, SeatClass.FirstClass, firstClassSeatChartDataGrid);
            MapSeatData(seatInfos, SeatClass.Economy, economyClassSeatChartDataGrid);
        }

        public SeatChart(object flightInfoData, User user, SeatClass seatClass) : this()
        {
            var flightInfo = (FlightInfo)flightInfoData;

            FlightInformation = flightInfo;
            UserInput = user;
            SeatClass = seatClass;

            var client = new BookingServiceClient();
            var seatInfos = client.RetrieveOccupiedSeatsMatrixFromFlightId(flightInfo.FlightId).ToList();

            var dataGrid = seatClass == SeatClass.FirstClass ? firstClassSeatChartDataGrid : economyClassSeatChartDataGrid;
            //// implement the seat selection
            MapSeatData(seatInfos, seatClass, dataGrid);
            var vm = new SeatChartViewModel(true);
            DataContext = vm;
        }

        private void MapSeatData(List<FlightSeatInfo> seatInfos, SeatClass seatClass, DataGrid dataGrid)
        {
            var seats = seatInfos.Where(s => s.SeatClass == seatClass).FirstOrDefault()?.SeatMatrix;
            var dataGridLength = new DataGridLength(seats.Length, DataGridLengthUnitType.Star);
            dataGrid.ItemsSource = GenerateDataTableForSeat(seats);
            dataGrid.ColumnWidth = dataGridLength;
        }

        private DataView GenerateDataTableForSeat(int[][] seatMatrix)
        {
            var seatChartData = new DataTable();
            if (seatMatrix != null && seatMatrix.Length > 0)
            {
                seatChartData.Columns.Add("---");
                for (var i = 0; i < seatMatrix[0].Length; i++)
                {
                    int columnName = i + 1;
                    seatChartData.Columns.Add(columnName.ToString());
                }

                int index = 0;

                foreach (var row in seatMatrix)
                {
                    var tmp = new string[1 + row.Length];
                    row.Select(x => x == 0 ? "O" : "X").ToArray().CopyTo(tmp, 1);
                    tmp[0] = index.ToAlphabet();
                    seatChartData.Rows.Add(tmp);
                    index++;
                }
            }
            return seatChartData.DefaultView;
        }

        private void FirstClass_DG_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            SelectedRow = firstClassSeatChartDataGrid.SelectedIndex;
            SelectedCol = firstClassSeatChartDataGrid.CurrentColumn.DisplayIndex - 1;
            userSelectedRowTextbox.Text = SelectedRow.ToAlphabet();
            userSelectedColTextbox.Text = (SelectedCol+1).ToString();
        }

        private void EcoClass_DG_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            SelectedRow = economyClassSeatChartDataGrid.SelectedIndex;
            SelectedCol = economyClassSeatChartDataGrid.CurrentColumn.DisplayIndex - 1;
            userSelectedRowTextbox.Text = SelectedRow.ToAlphabet();
            userSelectedColTextbox.Text = (SelectedCol + 1).ToString();
        }

        private void Book_Button_Click(object sender, RoutedEventArgs e)
        {
            var bookingClient = new BookingServiceClient();
            var bookingDetail = new BookingDetailRequest()
            {
                BookingDetailDao = new BookingDetailDao()
                {
                    FlightId = FlightInformation.FlightId,
                    CustomerId = UserInput.UserDao.Id,
                    Class = SeatClass,
                    SeatRow = (short)userSelectedRowTextbox.Text.FromAlphabetToInt(),
                    SeatCol = (short)(userSelectedColTextbox.Text.ToIntOrDefault() - 1)
                },
                FirstName = UserInput.UserDao.FirstName,
                LastName = UserInput.UserDao.LastName,
                Age = UserInput.UserDao.Age
            };
            var bookingId = bookingClient.BookTicket(bookingDetail);

            if (string.IsNullOrEmpty(bookingId))
            {
                // bind text
                var vm = DataContext as SeatChartViewModel;
                vm.IsShowInvalidBookingText = true;
                vm.NotifyPropertyChanged("IsShowInvalidBookingText");
            }
            else
            {
                NavigationService.Navigate(new ThankYou(bookingId, FlightInformation, UserInput, SeatClass, userSelectedRowTextbox.Text.FromAlphabetToInt(), userSelectedColTextbox.Text.ToIntOrDefault() - 1));
            }
        }
    }
}
