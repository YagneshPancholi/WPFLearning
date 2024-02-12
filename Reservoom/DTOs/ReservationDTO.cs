using Reservoom.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservoom.DTOs
{
    public class ReservationDTO 
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public int FloorNumber { get; set; }
        [Required]
        public int RoomNumber { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }
    }
}
