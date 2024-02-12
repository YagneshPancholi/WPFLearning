using Reservoom.Exceptions;
using Reservoom.Models;
using Reservoom.Services;
using Reservoom.Stores;
using Reservoom.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Reservoom.Commands
{
    public class MakeReservationCommand : AsyncCommandBase
    {
        private readonly MakeReservationViewModel _makeReservationViewModel;
        private readonly HotelStore _hotelStore;
        private readonly NavigationService _reservationViewNavigationService;

        public MakeReservationCommand(MakeReservationViewModel makeReservationViewModel, HotelStore hotelStore, NavigationService reservationViewNavigationService)
        {
            _makeReservationViewModel = makeReservationViewModel;
            _hotelStore = hotelStore;
            _reservationViewNavigationService = reservationViewNavigationService;
            _makeReservationViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }



        public override bool CanExecute(object parameter)
        {
            bool IsValidUsername = !string.IsNullOrEmpty(_makeReservationViewModel.Username);
            bool IsValidFloorNumber = _makeReservationViewModel.FloorNumber <= 10 && _makeReservationViewModel.FloorNumber >= 1;
            bool IsValidRoomNumber = _makeReservationViewModel.RoomNumber <= 10 && _makeReservationViewModel.RoomNumber >= 1;
            bool IsValidDateTimePerios = _makeReservationViewModel.StartDate < _makeReservationViewModel.EndDate;
            return IsValidUsername && IsValidFloorNumber && IsValidRoomNumber && IsValidDateTimePerios && base.CanExecute(parameter);
        }
        public override async Task ExecuteAsync(object parameter)
        {
            Reservation reservation = new Reservation(
                new RoomID(_makeReservationViewModel.FloorNumber, _makeReservationViewModel.RoomNumber),
                _makeReservationViewModel.StartDate,
                _makeReservationViewModel.EndDate,
                _makeReservationViewModel.Username
                );

            try
            {
                await _hotelStore.MakeReservation(reservation);
                MessageBox.Show("Successfully Added Reservation..", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                _reservationViewNavigationService.Navigate();
            }
            catch (ReservationConflicException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                MessageBox.Show("Failde To Make Reservation!!!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(MakeReservationViewModel.Username) ||
                e.PropertyName == nameof(MakeReservationViewModel.FloorNumber) ||
                e.PropertyName == nameof(MakeReservationViewModel.RoomNumber)||
                e.PropertyName == nameof(MakeReservationViewModel.StartDate)||
                e.PropertyName == nameof(MakeReservationViewModel.EndDate)
            )
            {
                OnCanExecutedChanged();
            }
        }
    }
}
