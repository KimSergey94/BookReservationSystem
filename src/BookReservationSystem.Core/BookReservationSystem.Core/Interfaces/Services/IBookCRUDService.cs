using BookReservationSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReservationSystem.Core.Interfaces.Services
{
    public interface IBookCRUDService
    {
        Task<Book> Get(int Id);
        Task<Book> Create(Book book);
        Task<Book> Update(Book book);
        Task<bool> Delete(int bookId);
    }
}
