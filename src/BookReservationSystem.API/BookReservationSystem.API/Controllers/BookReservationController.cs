using BookReservationSystem.Core.DTOs;
using BookReservationSystem.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookReservationSystem.API.Controllers
{
    public class BookReservationController : ApiControllerBase
    {
        private readonly IBookReservationService _bookReservationService;

        public BookReservationController(IBookReservationService bookReservationService)
        {
            _bookReservationService = bookReservationService;
        }

        [HttpGet]
        public async Task<IActionResult> ReserveBook(int bookId, string comment)
        {
            return Ok(await Task.Run(() => _bookReservationService.ReserveBook(bookId, comment)));
        }

        [HttpGet]
        public async Task<IActionResult> CancelBookReservation(int bookId)
        {
            return Ok(await Task.Run(() => _bookReservationService.CancelBookReservation(bookId)));
        }

        [HttpGet]
        public async Task<IActionResult> GetReservedBooks()
        {
            return Ok(await Task.Run(() => _bookReservationService.GetReservedBooks()));
        }

        [HttpGet]
        public async Task<IActionResult> GetAvailableBooks()
        {
            return Ok(await Task.Run(() => _bookReservationService.GetAvailableBooks()));
        }

        [HttpGet]
        public async Task<IActionResult> GetReservationHistory(int bookId)
        {
            return Ok(await Task.Run(() => _bookReservationService.GetReservationHistory(bookId)));
        }
    }
}
