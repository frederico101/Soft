using Newtonsoft.Json;
using Soft.Bussiness.Models.Books;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Bussiness.Core.Services
{
    public class BookServices : IBookServices
    {
        private readonly HttpClient _httpClient;
        private readonly IBookRepository _bookRepository;
        public BookServices(IBookRepository bookRepository, HttpClient httpClient)
        {
            _bookRepository = bookRepository;
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            //_httpClient.BaseAddress = new Uri("http://localhost:50547/");
        }


        public async Task<IEnumerable<Book>> CreateBookHttp(Book book)
        {
            try
            {
                var jsonContent = new StringContent(JsonConvert.SerializeObject(book), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("http://localhost:50547/api/CreateBooks", jsonContent);
                response.EnsureSuccessStatusCode();
                var bookResponse = await response.Content.ReadAsAsync<BookResponse>();
                return bookResponse.BookViewModels;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error fetching books", ex);
            }
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
                throw new InvalidOperationException("Error fetching books", ex);
            }
        }


        public async Task<Book> GetBookByIdAsync(Guid bookId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"http://localhost:50547/api/BooksDetails/{bookId}");
                response.EnsureSuccessStatusCode();
                var bookResponse = await response.Content.ReadAsAsync<Book>();
                return bookResponse;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error fetching books", ex);
            }
        }


        public async Task<Book> UpdateBookAsync(Guid bookId, Book updatedBook)
        {
            try
            {
                var jsonContent = new StringContent(JsonConvert.SerializeObject(updatedBook), Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync($"http://localhost:50547/api/UpdateBook/{bookId}", jsonContent);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsAsync<Book>();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error updating book", ex);
            }
        }


        public async Task<Book> DeleteBookHttpAsync(Book book)
        {
            try
            {
                var jsonContent = new StringContent(JsonConvert.SerializeObject(book), Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync($"http://localhost:50547/api/DeleteBook/{book.Id}", jsonContent);
                response.EnsureSuccessStatusCode();
                var bookResponse = await response.Content.ReadAsAsync<Book>();
                return bookResponse;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error fetching books", ex);
            }

        }

    }
}
