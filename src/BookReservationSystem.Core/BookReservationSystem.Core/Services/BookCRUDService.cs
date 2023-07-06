using BookReservationSystem.Core.Common;
using BookReservationSystem.Core.Entities;
using BookReservationSystem.Core.Interfaces.Repositories;
using BookReservationSystem.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BookReservationSystem.Core.Services
{
    public class BookCRUDService : IBookCRUDService
    {
        private readonly IUnitOfWork _unitOfWork;
        public BookCRUDService(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Book> Get(int bookId)
        {
            return await _unitOfWork.Repository<Book>().GetByIdAsync(bookId);
        }

        public async Task<Book> Create(Book book)
        {
            var result = await _unitOfWork.Repository<Book>().AddAsync(book);
            await _unitOfWork.Complete();
            return result;
        }

        public async Task<Book> Update(Book book)
        {
            var dbBook = await _unitOfWork.Repository<Book>().GetByIdAsync(book.Id);
            dbBook.Author = book.Author;
            dbBook.Title = book.Title;
            return await _unitOfWork.Repository<Book>().UpdateAsync(dbBook);
        }

        public async Task<bool> Delete(int bookId)
        {
            var book = await _unitOfWork.Repository<Book>().GetByIdAsync(bookId);
            var result = await _unitOfWork.Repository<Book>().DeleteAsync(book);
            try
            {
                await _unitOfWork.Complete();
            }
            catch { throw; }
            return result;
        }
    }
}
