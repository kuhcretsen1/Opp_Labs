using Biblioteka.Models;

namespace Biblioteka.Services
{
    public interface IBookService
    {
        void AddBook(Book book);
        void EditBook(Book book);
        void DeleteBook(int bookId);
        List<Book> GetBooks();
    }
}
