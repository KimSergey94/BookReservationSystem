using BookReservationSystem.Core.Entities;
using BookReservationSystem.Core.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookReservationSystem.API.Controllers
{
    public class BookController : ApiControllerBase
    {
        private readonly IBookCRUDService _bookCRUDService;

        public BookController(IBookCRUDService bookCRUDService)
        {
            _bookCRUDService = bookCRUDService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int bookId)
        {
            return Ok(await Task.Run(() => _bookCRUDService.Get(bookId)));
        }

        [HttpPost]
        public async Task<IActionResult> Create(Book book)
        {
            return Ok(await Task.Run(() => _bookCRUDService.Create(book)));
        }

        [HttpPut]
        public async Task<IActionResult> Update(Book book)
        {
            return Ok(await Task.Run(() => _bookCRUDService.Update(book)));
        }

        [HttpDelete("{bookId}")]
        public async Task<IActionResult> Delete(int bookId)
        {
            return Ok(await Task.Run(() => _bookCRUDService.Delete(bookId)));
        }
    }
}
