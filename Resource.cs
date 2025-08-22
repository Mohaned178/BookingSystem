using EfCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookingSystem
{
    public class Resource
    {
        public int Id { get; set; }   // PK

        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        [Required]
        public string Type { get; set; } // Room, Clinic, Course

        [Range(1, 1000)]
        public int Capacity { get; set; }

        // Navigation Property
        public ICollection<Reservation> Reservations { get; set; }
    }
}
