using Reservoom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservoom.Exceptions
{

    public class ReservationConflicException : System.Exception
    {
       
        public Reservation ExistingReservation { get; }
        public Reservation IncomingReservation { get; }

        public ReservationConflicException() { }
        public ReservationConflicException(string message) : base(message) {
            }
        public ReservationConflicException(string message, System.Exception inner) : base(message, inner) { }
        protected ReservationConflicException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

        public ReservationConflicException(Reservation existingReservation, Reservation incomingReservation)
        {
            ExistingReservation = existingReservation;
            IncomingReservation = incomingReservation;
        }
        public static ReservationConflicException conflicException(Reservation currentReservation)
        {
            string ExceptionMessage = $"Room {currentReservation.RoomID} is not avaliable until {currentReservation.EndTime.ToString("dd MMM yyyy hh:mm tt")} ... ";
            return new ReservationConflicException(ExceptionMessage);
        }
    }

}
