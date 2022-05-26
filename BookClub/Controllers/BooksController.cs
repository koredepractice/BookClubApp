using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Bookclub.Models;
using BookClubApp.Services;

namespace BookClubApp.Controllers
{
    [ApiController]
    [Route("[controller]")]//URL: https://localhost:7167/
    public class BooksController : ControllerBase
    {
        private readonly ICrudService<Book, int> _booksService;
        public BooksController(ICrudService<Book, int> booksService)
        {
            _booksService = booksService;
        }

        // GET all action
        [HttpGet] // auto returns data with a Content-Type of application/json
        public ActionResult<List<Book>> GetAll() => _booksService.GetAll().ToList();

        // GET by Id action
        [HttpGet("{id}")]
        public ActionResult<Book> Get(int id)
        {
            var book = _booksService.Get(id);
            if (book is null) return NotFound();
            else return book;
        }

        // POST action
        [HttpPost]
        public IActionResult Create(Book book)
        {
            // Runs validation against model using data validation attributes
            if (ModelState.IsValid)
            {
                _booksService.Add(book);
                return CreatedAtAction(nameof(Create), new { id = book.BookId },book);
            }
            return BadRequest();
        }

        // PUT action
        [HttpPut("{id}")]
        public IActionResult Update(int id, Book book)
        {
            var existingBooks = _booksService.Get(id);
            if (existingBooks is null || existingBooks.BookId != id)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                _booksService.Update(existingBooks, book);
                return NoContent();
            }
            return BadRequest();
        }

        // DELETE action
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var book = _booksService.Get(id);
            if (book is null) return NotFound();
            _booksService.Delete(id);
            return NoContent();
        }
    }
}
