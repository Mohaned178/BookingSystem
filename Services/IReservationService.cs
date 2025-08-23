using EfCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore.Services
{
    public interface IReservationService
    {
        void AddReservation(Reservation reservation);
        Reservation GetReservationById(int id);
        IEnumerable<Reservation> GetAllReservations();
        void UpdateReservation(Reservation reservation);
        void DeleteReservation(int id);
    }
}
