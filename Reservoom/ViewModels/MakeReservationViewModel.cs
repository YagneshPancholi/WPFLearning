using Reservoom.Commands;
using Reservoom.Models;
using Reservoom.Services;
using Reservoom.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Reservoom.ViewModels
{
    public class MakeReservationViewModel : ViewModelBase
    {
        private string _username;
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }
        private int _roomNumber;
        public int RoomNumber
        {
            get
            {
                return _roomNumber;
            }
            set
            {
                _roomNumber = value;
                OnPropertyChanged(nameof(RoomNumber));
            }
        }
        private int _floorNumber;
        public int FloorNumber
        {
            get
            {
                return _floorNumber;
            }
            set
            {
                _floorNumber = value;
                OnPropertyChanged(nameof(FloorNumber));
            }
        }
        private DateTime _startDate = DateTime.Now;
        public DateTime StartDate
        {
            get
            {
                return _startDate;
            }
            set
            {
                if (value >= DateTime.Now)
                {
                    _startDate = value;
                    OnPropertyChanged(nameof(StartDate));
                }
                else
                {
                    MessageBox.Show("Enter Correct Start Date", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
        }
        private DateTime _endDate = DateTime.Now.AddDays(7);
        public DateTime EndDate
        {
            get
            {
                return _endDate;
            }
            set
            {
                if (value > StartDate)
                {
                    _endDate = value;
                    OnPropertyChanged(nameof(EndDate));
                }
                else
                {
                    MessageBox.Show("Enter Correct End Date", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
        }

        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }
        public MakeReservationViewModel(HotelStore hotelStore, NavigationService reservationListingViewNavigationService)
        {
            SubmitCommand = new MakeReservationCommand(this, hotelStore, reservationListingViewNavigationService);
            CancelCommand = new NavigateCommand(reservationListingViewNavigationService);
        }
    }
}
