using Soft.Bussiness.Models.Books;
using System.Threading.Tasks;

namespace Soft.Bussiness.Core.Services
{
    public interface IBookServices
    {
        Task AddBookServices(Book book);
        Task UpdateBookServices(Book book);
        Task DeleteBookServices(Book book);
    }
}
