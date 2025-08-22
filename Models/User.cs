using EfCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EfCore.Models
{
    public class User
    {
        public int Id { get; set; }   // PK

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Role { get; set; } // Client / Admin

        // Navigation Property
        public ICollection<Reservation> Reservations { get; set; }
    }
}
