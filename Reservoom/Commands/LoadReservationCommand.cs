using Reservoom.Stores;
using Reservoom.ViewModels;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace Reservoom.Commands
{
    public class LoadReservationCommand : AsyncCommandBase
    {
        private readonly ReservationListingViewModel _reservationListingViewModel;
        private readonly HotelStore _hotelStore;

        public LoadReservationCommand(ReservationListingViewModel reservationListingViewModel, HotelStore hotelStore)
        {
            _reservationListingViewModel = reservationListingViewModel;
            _hotelStore = hotelStore;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                await _hotelStore.Load();
                _reservationListingViewModel.UpdateReservations(_hotelStore.Reservations);
            }
            catch (Exception)
            {

                MessageBox.Show($"Failde To Load Reservations of The Hotel{_hotelStore.GetHotelName()}!!!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
