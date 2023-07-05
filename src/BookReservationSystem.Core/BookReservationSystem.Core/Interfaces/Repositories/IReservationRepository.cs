using BookReservationSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReservationSystem.Core.Interfaces.Repositories
{
    public interface IReservationRepository
    {
        Task<Reservation> GetByBookIdAsync(int bookId);
    }
}
