using Reservoom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservoom.Stores
{
    public class HotelStore
    {
        private readonly List<Reservation> _reservations;
        private readonly Hotel _hotel;
        private readonly Lazy<Task> _intializeLazy;
        public IEnumerable<Reservation> Reservations => _reservations;
        public event Action<Reservation> ReservationMade;

        public HotelStore(Hotel hotel)
        {
            _reservations = new List<Reservation>();
            _hotel = hotel;
            _intializeLazy = new Lazy<Task>(Initialize);
        }
        public string GetHotelName()
        {
            return _hotel.Name;
        }
     

        public async Task Load()
        {
            await _intializeLazy.Value;
        }
        public async Task MakeReservation(Reservation reservation)
        {
            await _hotel.MakeReservation(reservation);
            _reservations.Add(reservation);
            OnReservationMade(reservation);
        }

        private void OnReservationMade(Reservation reservation)
        {
            ReservationMade?.Invoke(reservation);
        }

        private async Task Initialize()
        {
            IEnumerable<Reservation> reservations = await _hotel.GetAllReservations();
            _reservations.Clear();
            _reservations.AddRange(reservations);
        }
    }
}
