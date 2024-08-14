using Soft.Api.ViewModel;
using Soft.Bussiness.Core.Services;
using Soft.Bussiness.Models.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Soft.Api.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly IBookServices _bookService;

        public HomeController(IBookServices bookService)
        {
            _bookService = bookService ?? throw new ArgumentNullException(nameof(bookService));
        }

        public async Task<ActionResult> Index()
        {
            var books = await _bookService.GetBooksAsync();

            List<BookViewModel> bookViewModels = books.Select(b => new BookViewModel
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

            return View(bookViewModels);
        }

        [HttpGet]
        public async Task<ActionResult> CreateBook()
        {
            return View("Create");
        }


        [HttpPost]
        public async Task<ActionResult> CreateBook(BookViewModel book)
        {

            var resultBook = new Book
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

            await _bookService.CreateBookHttp(resultBook);
            var result = new BookViewModel
            {
                Id = resultBook.Id,
                Title = resultBook.Title,
                Author = resultBook.Author,
                Category = resultBook.Category,
                IsRented = resultBook.IsRented,
                CreatedAt = resultBook.CreatedAt,
                UpdatedAt = resultBook.UpdatedAt,
                Status = resultBook.Status,
                CoverPath = resultBook.CoverPath
            };
            return View("Details", result);
        }

        public async Task<ActionResult> Detail(Guid id)
        {
            var resultBook = await _bookService.GetBookByIdAsync(id);

            if (resultBook == null)
            {
                return HttpNotFound();
            }

            var bookViewModel = new BookViewModel
            {
                Id = resultBook.Id,
                Title = resultBook.Title,
                Author = resultBook.Author,
                Category = resultBook.Category,
                IsRented = resultBook.IsRented,
                CreatedAt = resultBook.CreatedAt,
                UpdatedAt = resultBook.UpdatedAt,
                Status = resultBook.Status,
                CoverPath = resultBook.CoverPath
            };

            return View("Details", bookViewModel);
        }

        public async Task<ActionResult> EditBook(Book book)
        {
            if (book.Id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            var resultBook = await _bookService.GetBookByIdAsync(book.Id);

            if (resultBook == null)
            {
                return HttpNotFound();
            }

            var bookViewModel = new BookViewModel
            {
                Id = resultBook.Id,
                Title = resultBook.Title,
                Author = resultBook.Author,
                Category = resultBook.Category,
                IsRented = resultBook.IsRented,
                CreatedAt = resultBook.CreatedAt,
                UpdatedAt = resultBook.UpdatedAt,
                Status = resultBook.Status,
                CoverPath = resultBook.CoverPath
            };

            return View("Edit", bookViewModel);
        }

   

        public async Task<ActionResult> UpdateBook(BookViewModel updatedBookViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", updatedBookViewModel);
            }

            try
            {
                var updatedBook = new Book
                {
                    Id = updatedBookViewModel.Id,
                    Title = updatedBookViewModel.Title,
                    Author = updatedBookViewModel.Author,
                    Category = updatedBookViewModel.Category,
                    IsRented = updatedBookViewModel.IsRented,
                    CreatedAt = updatedBookViewModel.CreatedAt,
                    UpdatedAt = DateTime.Now,
                    Status = updatedBookViewModel.Status,
                    CoverPath = updatedBookViewModel.CoverPath
                };

                var book = await _bookService.UpdateBookAsync(updatedBookViewModel.Id, updatedBook);


                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(500, ex.Message);
            }
        }
        public async Task<ActionResult> DeleteBookQuestion(Guid id)
        {
            var book = await _bookService.GetBookByIdAsync(id);

            if (book == null)
            {
                return HttpNotFound();
            }

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

            return View("Delete", bookViewModel);
        }

        public async Task<ActionResult> DeleteBook(BookViewModel BookViewModel)
        {
            try
            {
                var toDeleteBook = new Book
                {
                    Id = BookViewModel.Id,
                    Title = BookViewModel.Title,
                    Author = BookViewModel.Author,
                    Category = BookViewModel.Category,
                    IsRented = BookViewModel.IsRented,
                    CreatedAt = BookViewModel.CreatedAt,
                    UpdatedAt = DateTime.Now,
                    Status = BookViewModel.Status,
                    CoverPath = BookViewModel.CoverPath
                };


                await _bookService.DeleteBookHttpAsync(toDeleteBook);

               
                return RedirectToAction("index");
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(500, ex.Message);
            }
        }


    }
}
