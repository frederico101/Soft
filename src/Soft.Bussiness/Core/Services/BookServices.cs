using Soft.Bussiness.Core.Notifications;
using Soft.Bussiness.Models.Books;
using System.Threading.Tasks;

namespace Soft.Bussiness.Core.Services
{
    public class BookServices: IBookServices
    {
        private readonly IBookRepository _bookRepository;
        private readonly INotification _notification;
        public BookServices(IBookRepository bookRepository, INotification notification)
        {
            _bookRepository = bookRepository;
            _notification = notification;
        }
        public async Task AddBookServices(Book book) 
        {
            var validationResult = book.Validate();
            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    _notification.AddNotification(error.ErrorMessage);
                }
                return;
            }

            await _bookRepository.Add(book);
        }

        public async Task UpdateBookServices(Book book)
        {
            var validationResult = book.Validate();
            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    _notification.AddNotification(error.ErrorMessage);
                }
                return;
            }
            await _bookRepository.Update(book);
        }

        public async Task DeleteBookServices(Book book)
        {
            var bookResult = await _bookRepository.GetById(book.Id);
            if (bookResult == null) return;
                // if (bookResult.IsRented) return; TODO envia um alerta avisando que o livro esta alugado
                await _bookRepository.Delete(book.Id);
            
        }
    }
}
