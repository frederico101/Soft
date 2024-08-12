using Soft.Api.ViewModel;
using Soft.Bussiness.Core.Notifications;
using Soft.Bussiness.Core.Services;
using Soft.Bussiness.Models.Books;
using Soft.Infra.Data.Repository;
using System;
using System.Linq;
using System.Web.Http;

namespace Soft.Api.Controllers
{
    public class BookViewModelsController : ApiController
    {
        private readonly IBookRepository _bookRepository;
        private readonly IBookServices _bookServices;

        public BookViewModelsController(IBookRepository bookRepository, IBookServices bookServices)
        {
            _bookRepository = bookRepository;
            _bookServices = bookServices;
        }

        // GET: BookViewModels
        [HttpGet]
        [Route("api/GetBooks")]
        public IHttpActionResult Index()
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

                return Ok(bookViewModels);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: BookViewModels/Details/5
        //public async Task<ActionResult> Details(Guid? id)
        //{
        //    //if (id == null)
        //    //{
        //    //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    //}
        //    //var bookViewModel = await db.Books.FindAsync(id);
        //    //if (bookViewModel == null)
        //    //{
        //    //    return HttpNotFound();
        //    //}
        //    return null;
        //}

        // GET: BookViewModels/Create
        //public ActionResult Create()
        //{
        //    return null;
        //}

        // POST: BookViewModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Create([Bind(Include = "Id,Title,Author,Category,IsRented,CreatedAt,UpdatedAt,Status,CoverPath")] BookViewModel bookViewModel)
        //{
        //    //if (ModelState.IsValid)
        //    //{
        //    //    bookViewModel.Id = Guid.NewGuid();
        //    //    db.Books.Add(bookViewModel);
        //    //    await db.SaveChangesAsync();
        //    //    return RedirectToAction("Index");
        //    //}

        //    return null;
        //}

        // GET: BookViewModels/Edit/5
        //public async Task<ActionResult> Edit(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    BookViewModel bookViewModel = await db.BookViewModels.FindAsync(id);
        //    if (bookViewModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(bookViewModel);
        //}

        // POST: BookViewModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Edit([Bind(Include = "Id,Title,Author,Category,IsRented,CreatedAt,UpdatedAt,Status,CoverPath")] BookViewModel bookViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(bookViewModel).State = EntityState.Modified;
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }
        //    return View(bookViewModel);
        //}

        // GET: BookViewModels/Delete/5
        //public async Task<ActionResult> Delete(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    BookViewModel bookViewModel = await db.BookViewModels.FindAsync(id);
        //    if (bookViewModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(bookViewModel);
        //}

        // POST: BookViewModels/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> DeleteConfirmed(Guid id)
        //{
        //    BookViewModel bookViewModel = await db.BookViewModels.FindAsync(id);
        //    db.BookViewModels.Remove(bookViewModel);
        //    await db.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
