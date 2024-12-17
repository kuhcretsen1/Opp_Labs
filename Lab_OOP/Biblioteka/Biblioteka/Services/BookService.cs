using Biblioteka.Models;
using System.Net.Mail;

namespace Biblioteka.Services
{
    public class BookService : IBookService
    {
        private readonly List<Book> _books = new List<Book>();
        private readonly ICategoryService _categoryService;
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;

        public BookService(ICategoryService categoryService, IUserService userService, IEmailService emailService)
        {
            _categoryService = categoryService;
            _userService = userService;
            _emailService = emailService;
        }

        public void AddBook(Book book)
        {
            book.Id = _books.Count > 0 ? _books.Max(b => b.Id) + 1 : 1;
            _books.Add(book);
            var category = _categoryService.GetCategoryById(book.Category.Id);
            if (category != null)
            {
                category.Books.Add(book);
                NotifyUsers(category, book);
            }
        }

        private void NotifyUsers(Category category, Book book)
        {
            var users = _userService.GetUsers();
            foreach (var user in users)
            {
                if (user.FavoriteCategories.Any(c => c.Name == category.Name))
                {
                    _emailService.Send(user.Email, $"New Book in {category.Name}",
                        $"Нова книга '{book.Title}' написана {book.Author} прибула до бібліотеки в  {category.Name} категорії.");
                }
            }
        }

        public void EditBook(Book book)
        {
            var existingBook = _books.FirstOrDefault(b => b.Id == book.Id);
            if (existingBook != null)
            {
                existingBook.Title = book.Title;
                existingBook.Author = book.Author;
                existingBook.Category = book.Category;
            }
        }

        public void DeleteBook(int bookId)
        {
            var book = _books.FirstOrDefault(b => b.Id == bookId);
            if (book != null)
            {
                _books.Remove(book);
            }
        }

        public List<Book> GetBooks()  
        {
            return _books;
        }
    }
}
