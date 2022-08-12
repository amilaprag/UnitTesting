using BaseAPI.Data.Models;

namespace BaseAPI.Services
{
    public interface IBookService
    {
        IEnumerable<Book> GetAll();

        Book Add(Book newBook);

        Book GetById(Guid id);

        void Remove(Guid id);
    }
}