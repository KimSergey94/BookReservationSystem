using BookReservationSystem.Core.DTOs;
using BookReservationSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReservationSystem.Core.Interfaces.Services
{
    public interface IBookReservationService
    {
        Task<bool> ReserveBook(int bookId, string comment);
        Task<bool> CancelBookReservation(int bookId);
        Task<IList<GetReservedBooksDTO>> GetReservedBooks();
        Task<IList<GetAvailableBooksDTO>> GetAvailableBooks();
        Task<IList<GetReservationHistoryDTO>> GetReservationHistory(int bookId);
    }
}
