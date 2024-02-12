using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservoom.Models
{
    public class RoomID
    {
        public int FloorNumber{get;}
        public int RoomNumber{get;}
        public RoomID(int floorNumber, int roomNumber)
        {
            FloorNumber = floorNumber;
            RoomNumber = roomNumber;
        }
        public override bool Equals(object? obj)
        {
            return obj is RoomID roomID && FloorNumber == roomID.FloorNumber && RoomNumber == roomID.RoomNumber  ;
        }
        public override int GetHashCode()
        {
           return HashCode.Combine(FloorNumber, RoomNumber);
        }
        public override string ToString()
        {
            return $"{FloorNumber}{RoomNumber}";
        }
        public static bool operator ==(RoomID roomid1, RoomID roomid2)
        {
            if(roomid1 is null && roomid2 is null)
            {
                return true;
            }
            return !(roomid1 is null )&& roomid1.Equals(roomid2);
        }
        public static bool operator !=(RoomID roomid1, RoomID roomid2)
        {
            return !(roomid1 == roomid2);
        }



    }
}
