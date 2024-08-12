using Soft.Api.ViewModel;
using Soft.Bussiness.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
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
    }
}
