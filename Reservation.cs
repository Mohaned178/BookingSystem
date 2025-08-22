using System;
using System.ComponentModel.DataAnnotations;

namespace BookingSystem
{
    public class Reservation
    {
        public int Id { get; set; }   // PK

        [Required]
        public int UserId { get; set; }   // FK → User
        public User User { get; set; }

        [Required]
        public int ResourceId { get; set; }   // FK → Resource
        public Resource Resource { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        [Required]
        [MaxLength(20)]
        public string Status { get; set; } // Pending, Confirmed, Cancelled
    }
}
