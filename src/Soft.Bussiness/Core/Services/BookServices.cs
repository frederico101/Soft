using Soft.Bussiness.Models.Books;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Soft.Bussiness.Core.Services
{
    public class BookServices : IBookServices
    {
        private readonly HttpClient _httpClient;

        public BookServices(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            //_httpClient.BaseAddress = new Uri("https://localhost:50547/"); // Ensure this is the correct base address
        }

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("http://localhost:50547/api/GetBooks");
                response.EnsureSuccessStatusCode();
                var bookResponse = await response.Content.ReadAsAsync<BookResponse>();
                return bookResponse.BookViewModels;
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                throw new InvalidOperationException("Error fetching books", ex);
            }
        }

        // Uncomment and implement additional methods as needed

        //public async Task AddBookServices(Book book) 
        //{
        //    var validationResult = book.Validate();
        //    if (!validationResult.IsValid)
        //    {
        //        foreach (var error in validationResult.Errors)
        //        {
        //            _notification.AddNotification(error.ErrorMessage);
        //        }
        //        return;
        //    }

        //    await _bookRepository.Add(book);
        //}

        //public async Task UpdateBookServices(Book book)
        //{
        //    var validationResult = book.Validate();
        //    if (!validationResult.IsValid)
        //    {
        //        foreach (var error in validationResult.Errors)
        //        {
        //            _notification.AddNotification(error.ErrorMessage);
        //        }
        //        return;
        //    }
        //    await _bookRepository.Update(book);
        //}

        //public async Task DeleteBookServices(Book book)
        //{
        //    var bookResult = await _bookRepository.GetById(book.Id);
        //    if (bookResult == null) return;
        //        // if (bookResult.IsRented) return; TODO envia um alerta avisando que o livro esta alugado
        //        await _bookRepository.Delete(book.Id);

        //}
    }
}
