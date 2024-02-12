using Reservoom.Commands;
using Reservoom.Models;
using Reservoom.Services;
using Reservoom.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Reservoom.ViewModels
{
    public class ReservationListingViewModel : ViewModelBase
    {
        public ICommand LoadReservationCommand { get; }
        public ICommand MakeReservationCommand { get; }
        private readonly ObservableCollection<ReservationViewModel> _reservations;
        private readonly HotelStore _hotelStore;

        public IEnumerable<ReservationViewModel> Reservations => _reservations;
        public ReservationListingViewModel(HotelStore hotelStore, NavigationService makeReservationNavigaionService)
        {
            _reservations = new ObservableCollection<ReservationViewModel>();
            _hotelStore = hotelStore;
            MakeReservationCommand = new NavigateCommand(makeReservationNavigaionService);
            LoadReservationCommand = new LoadReservationCommand(this, hotelStore);
            _hotelStore.ReservationMade += OnReservationMade;

        }
        public override void Dispose()
        {
            _hotelStore.ReservationMade -= OnReservationMade;
            base.Dispose();
        }

        private void OnReservationMade(Reservation reservation)
        {
            ReservationViewModel reservationView = new ReservationViewModel(reservation);
            _reservations.Add(reservationView);

        }

        public static ReservationListingViewModel LoadViewModel(HotelStore hotel, NavigationService makeReservationNavigaionService)
        {
            ReservationListingViewModel viewModel = new ReservationListingViewModel(hotel, makeReservationNavigaionService);
            viewModel.LoadReservationCommand.Execute(null);
            return viewModel;
        }
        public void UpdateReservations(IEnumerable<Reservation> reservations)
        {
            _reservations.Clear();
            foreach (Reservation reservation in reservations)
            {
                ReservationViewModel reservationViewModel = new ReservationViewModel(reservation);
                _reservations.Add(reservationViewModel);
            }

        }
    }
}
