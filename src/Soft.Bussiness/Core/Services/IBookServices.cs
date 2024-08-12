using Soft.Bussiness.Models.Books;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Soft.Bussiness.Core.Services
{
    public interface IBookServices
    {
        Task<IEnumerable<Book>> GetBooksAsync();
    }
}
