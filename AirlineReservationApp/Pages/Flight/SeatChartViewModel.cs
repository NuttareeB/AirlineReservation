using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineReservationApp
{
    public class SeatChartViewModel : INotifyPropertyChanged
    {
        public SeatChartViewModel(bool isShow)
        {
            IsShow = isShow;
        }
        public bool IsShow { get; set; }

        public string InvalidBookingText => "Invalid booking request!";

        public bool IsShowInvalidBookingText { get; set; }

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
