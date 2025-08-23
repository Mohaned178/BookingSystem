using EfCore.Data;
using EfCore.Models;
using System.Collections.Generic;
using System.Linq;

namespace EfCore.Services
{
    public class ReservationService : IReservationService
    {
        private readonly ApplicationDbContext _context;

        public ReservationService()
        {
            _context = new ApplicationDbContext();
        }

        public void AddReservation(Reservation reservation)
        {
            _context.Reservations.Add(reservation);
            _context.SaveChanges();
        }

        public Reservation GetReservationById(int id)
        {
            return _context.Reservations.Find(id);
        }

        public IEnumerable<Reservation> GetAllReservations()
        {
            return _context.Reservations.ToList();
        }

        public void UpdateReservation(Reservation reservation)
        {
            _context.Reservations.Update(reservation);
            _context.SaveChanges();
        }

        public void DeleteReservation(int id)
        {
            var reservation = _context.Reservations.Find(id);
            if (reservation != null)
            {
                _context.Reservations.Remove(reservation);
                _context.SaveChanges();
            }
        }
    }
}
