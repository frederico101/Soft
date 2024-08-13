using Soft.Api.ViewModel;
using Soft.Bussiness.Core.Services;
using Soft.Bussiness.Models.Books;
using Soft.Infra.Data.Repository;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace Soft.Api.Controllers
{
    public class BooksController : ApiController
    {
        private readonly IBookRepository _bookRepository;
        private readonly IBookServices _bookServices;
        public BooksController(IBookServices bookService, IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
            _bookServices = bookService ?? throw new ArgumentNullException(nameof(bookService));
        }

        // POST: BookDetails
        [HttpGet]
        [Route("api/BooksDetails/{bookId}")]
        public async Task<IHttpActionResult> BooksDetails(Guid bookId)
        {
            var books = await _bookRepository.GetById(bookId);
            return Ok(books);
        }

        // GET: BookViewModels
        [HttpGet]
        [Route("api/GetBooks")]
        public IHttpActionResult GetBooks()
        {
            try
            {
                var books = _bookRepository.GetAll();

                var bookViewModels = books.Result.Select(b => new BookViewModel
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    Category = b.Category,
                    IsRented = b.IsRented,
                    CreatedAt = b.CreatedAt,
                    UpdatedAt = b.UpdatedAt,
                    Status = b.Status,
                    CoverPath = b.CoverPath
                }).ToList();

                return Json(new { bookViewModels });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: GetBookById
        [HttpGet]
        [Route("api/GetBookById/{bookId}")]
        public IHttpActionResult Edit(Guid bookId)
        {
            try
            {
                var book = _bookRepository.GetById(bookId).Result;

                if (book == null)
                    return NotFound();

                var bookViewModel = new BookViewModel
                {
                    Id = book.Id,
                    Title = book.Title,
                    Author = book.Author,
                    Category = book.Category,
                    IsRented = book.IsRented,
                    CreatedAt = book.CreatedAt,
                    UpdatedAt = book.UpdatedAt,
                    Status = book.Status,
                    CoverPath = book.CoverPath
                };

                return Ok(bookViewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("api/UpdateBook/{id}")]
        public async Task<IHttpActionResult> UpdateBook(Guid id, Book book)
        {
            if (id != book.Id)
            {
                return BadRequest("Book ID mismatch.");
            }

            var existingBook = await _bookRepository.GetById(book.Id);
            if (existingBook != null)
            {
                existingBook.Title = book.Title;
                existingBook.Author = book.Author;
                existingBook.Category = book.Category;
                existingBook.IsRented = book.IsRented;
                existingBook.Status = book.Status;
                existingBook.CoverPath = book.CoverPath;
                existingBook.UpdatedAt = DateTime.UtcNow;
            }
                await _bookRepository.Update(existingBook);
            return Ok();
        }



        [HttpPut]
        [Route("api/DeleteBook/{bookId}")]
        public async Task<IHttpActionResult> DeleteBook(Book book)
        {
            var existingBook = await _bookRepository.GetById(book.Id);
            if (existingBook != null)
            {
                // Update properties of the existing entity
                existingBook.Title = book.Title;
                existingBook.Author = book.Author;
                existingBook.Category = book.Category;
                existingBook.IsRented = book.IsRented;
                existingBook.Status = book.Status;
                existingBook.CoverPath = book.CoverPath;
                existingBook.UpdatedAt = DateTime.UtcNow;

            }
            await _bookRepository.Delete(existingBook);
            return Ok();
        }
      
    }
}
