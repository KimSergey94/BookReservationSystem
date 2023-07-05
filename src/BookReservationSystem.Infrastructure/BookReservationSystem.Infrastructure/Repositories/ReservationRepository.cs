using BookReservationSystem.Core.Entities;
using BookReservationSystem.Core.Interfaces.Repositories;
using BookReservationSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReservationSystem.Infrastructure.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly BookReservationSystemContext _bookReservationSystemContext;

        public async Task<Reservation> GetByBookIdAsync(int bookId)
        {
            return await _bookReservationSystemContext.Reservations.FirstOrDefaultAsync(reservation => reservation.BookId == bookId);
        }
    }
}
