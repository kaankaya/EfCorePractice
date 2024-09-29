using Library.Data;
using Library.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly LibraryContext _context;

        public BooksController(LibraryContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult<Book> Post([FromBody] Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();

            return Ok(book);
        }

        [HttpPut]
        public IActionResult Put(int id, [FromBody] Book book)
        {
            var current = _context.Books.FirstOrDefault(b => b.Id == id);
            if(current == null)
            {
                return NotFound();
            }
            current.Title = book.Title;
            current.LastBorrowedDate = book.LastBorrowedDate;
            current.Price = book.Price;
            current.CategoryId = book.CategoryId;


            _context.SaveChanges();
            return NoContent();
        }

        [HttpGet]
        public ActionResult<List<Book>> GetAll()
        {
            //var recentBooks = _context.Books
            //                  .Where(b => b.PublicationYear>2020)
            //                  .OrderByDescending(b => b.PublicationYear)
            //                  .Take(10)
            //                  .ToList();

            var books = _context.Books.FromSqlRaw("SELECT * FROM Books where PublicationYear > {0}",2020).ToList();
            return Ok(books);

            //return Ok(_context.Books.ToList());
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var cu = _context.Books.FirstOrDefault(c => c.Id == id);
            if (cu == null)
            {
                return NotFound();
            }
            _context.Books.Remove(cu);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
