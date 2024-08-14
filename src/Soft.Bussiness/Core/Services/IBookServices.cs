using Soft.Bussiness.Models.Books;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Soft.Bussiness.Core.Services
{
    public interface IBookServices
    {
        Task<IEnumerable<Book>> GetBooksAsync();
        Task<IEnumerable<Book>> CreateBookHttp(Book book);
        Task<Book> GetBookByIdAsync(Guid bookId);
        Task<Book> UpdateBookAsync(Guid bookId, Book updatedBook);
        Task<Book> DeleteBookHttpAsync(Book book);
    }
}
