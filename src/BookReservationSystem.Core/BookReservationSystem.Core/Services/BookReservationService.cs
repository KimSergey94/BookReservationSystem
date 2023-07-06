using BookReservationSystem.Core.Common;
using BookReservationSystem.Core.DTOs;
using BookReservationSystem.Core.Entities;
using BookReservationSystem.Core.Interfaces.Repositories;
using BookReservationSystem.Core.Interfaces.Services;
using BookReservationSystem.Core.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BookReservationSystem.Core.Services
{
    public class BookReservationService : IBookReservationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IReservationRepository _reservationRepository;
        public BookReservationService(IUnitOfWork unitOfWork, IReservationRepository reservationRepository)
        {
            _unitOfWork = unitOfWork;
            _reservationRepository = reservationRepository;
        }

        public async Task<bool> CancelBookReservation(int bookId)
        {
            var reservation = await _reservationRepository.GetByBookIdAsync(bookId);
            var result = await _unitOfWork.Repository<Reservation>().DeleteAsync(reservation);
            await _unitOfWork.Complete();
            return result;
        }

        public async Task<IList<GetAvailableBooksDTO>> GetAvailableBooks()
        {
            var reservations = await _unitOfWork.Repository<Reservation>().GetAllAsync();
            var reservedBooksIds = reservations.Select(x => x.BookId).ToList();
            var books = await _unitOfWork.Repository<Book>().GetAllAsync();
            return await Task.Run(() => MapperUtil.MapToGetAvailableBooksDTOList(books.Where(book => !reservedBooksIds.Contains(book.Id)).ToList()).ToList());
        }

        public async Task<IList<GetReservationHistoryDTO>> GetReservationHistory(int bookId)
        {
            try
            {
                var book = await _unitOfWork.Repository<Book>().GetByIdAsync(bookId);

                var reservationStatuses = await _unitOfWork.Repository<ReservationStatus>().GetAllAsync();
                var bookReservationStatuses = reservationStatuses.Where(reservationStatus => reservationStatus.BookId == bookId);
                return MapperUtil.MapToGetReservationHistoryDTOList(bookReservationStatuses).ToList();
            }
            catch
            {
                throw;
            }
        }

        public async Task<IList<GetReservedBooksDTO>> GetReservedBooks()
        {
            var reservations = await _unitOfWork.Repository<Reservation>().GetAllAsync();
            var reservedBooksIds = reservations.Select(x => x.BookId).ToList();
            var books = await _unitOfWork.Repository<Book>().GetAllAsync();
            return await Task.Run(() => MapperUtil.MapToGetReservedBooksDTOList(books.Where(book => reservedBooksIds.Contains(book.Id)).ToList()).ToList());
        }

        public async Task<bool> ReserveBook(int bookId, string comment)
        {
            var result = false;
            try
            {
                var reservationStatus = await _unitOfWork.Repository<ReservationStatus>().AddAsync(new ReservationStatus(bookId, "reserved", comment));
                await _unitOfWork.Repository<Reservation>().AddAsync(new Reservation(bookId, reservationStatus.Id));
                await _unitOfWork.Complete();
                result = true;
            }
            catch
            {
                throw;
            }
            return await Task.Run(()=> result);
        }
    }
}
