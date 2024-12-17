using Microsoft.Extensions.DependencyInjection;
using Biblioteka.Models;
using Biblioteka.Services;

public class Program
{
    private static IBookService _bookService;
    private static IUserService _userService;
    private static ICategoryService _categoryService;

    public enum MenuOptions
    {
        ViewAllBooks = 1,
        AddNewBook,
        RegisterUser,
        ViewAllCategories,
        AddNewCategory,
        ViewAllUsers,
        Exit
    }

    private static ServiceProvider ConfigureServices()
    {
        var serviceCollection = new ServiceCollection();

        serviceCollection.AddSingleton<IEmailService, EmailService>();
        serviceCollection.AddSingleton<IUserService, UserService>();
        serviceCollection.AddSingleton<ICategoryService, CategoryService>();
        serviceCollection.AddSingleton<IBookService, BookService>();

        return serviceCollection.BuildServiceProvider();
    }
    public static void Main(string[] args)
    {
        var serviceProvider = ConfigureServices();

        _bookService = serviceProvider.GetService<IBookService>();
        _userService = serviceProvider.GetService<IUserService>();
        _categoryService = serviceProvider.GetService<ICategoryService>();

        SeedData();

        while (true)
        {
            ShowMenu();

            Console.Write("Enter your choice: ");
            if (Enum.TryParse(Console.ReadLine(), out MenuOptions choice))
            {
                HandleMenuOption(choice);
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }
    }

    private static void ShowMenu()
    {
        Console.WriteLine("Library Management System");
        Console.WriteLine($"{(int)MenuOptions.ViewAllBooks}. View All Books");
        Console.WriteLine($"{(int)MenuOptions.AddNewBook}. Add New Book");
        Console.WriteLine($"{(int)MenuOptions.RegisterUser}. Register User");
        Console.WriteLine($"{(int)MenuOptions.ViewAllCategories}. View All Categories");
        Console.WriteLine($"{(int)MenuOptions.AddNewCategory}. Add New Category");
        Console.WriteLine($"{(int)MenuOptions.ViewAllUsers}. View All Users");
        Console.WriteLine($"{(int)MenuOptions.Exit}. Exit");
    }

    private static void HandleMenuOption(MenuOptions choice)
    {
        switch (choice)
        {
            case MenuOptions.ViewAllBooks:
                ViewAllBooks();
                break;
            case MenuOptions.AddNewBook:
                AddBook();
                break;
            case MenuOptions.RegisterUser:
                RegisterUser();
                break;
            case MenuOptions.ViewAllCategories:
                ViewAllCategories();
                break;
            case MenuOptions.AddNewCategory:
                AddCategory();
                break;
            case MenuOptions.ViewAllUsers:
                ViewAllUsers();
                break;
            case MenuOptions.Exit:
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Invalid choice. Please try again.");
                break;
        }
    }

    private static void SeedData()
    {
        _categoryService.AddCategory(new Category { Name = "Science Fiction" });
        _categoryService.AddCategory(new Category { Name = "Fantasy" });
        _categoryService.AddCategory(new Category { Name = "Mystery" });
    }

    private static void ViewAllBooks()
    {
        List<Book> books = _bookService.GetBooks();
        Console.WriteLine("All Books:");
        foreach (var book in books)
        {
            Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, Category: {book.Category.Name}");
        }
    }

    private static void AddBook()
    {
        Console.Write("Enter book title: ");
        string title = Console.ReadLine();
        Console.Write("Enter book author: ");
        string author = Console.ReadLine();
        Console.WriteLine("Select book category:");
        List<Category> categories = _categoryService.GetCategories();
        for (int i = 0; i < categories.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {categories[i].Name}");
        }
        int choice;
        if (int.TryParse(Console.ReadLine(), out choice) && choice > 0 && choice <= categories.Count)
        {
            Category selectedCategory = categories[choice - 1];
            Book book = new Book { Title = title, Author = author, Category = selectedCategory };
            _bookService.AddBook(book);
            Console.WriteLine("Book added successfully.");
        }
        else
        {
            Console.WriteLine("Invalid category choice.");
        }
    }

    private static void RegisterUser()
    {
        Console.Write("Enter user name: ");
        var name = Console.ReadLine();
        Console.Write("Enter user email: ");
        var email = Console.ReadLine();

        var categories = _categoryService.GetCategories();
        if (categories.Count == 0)
        {
            Console.WriteLine("No categories available. Please add categories first.");
            return;
        }

        Console.WriteLine("Select favorite categories (comma separated):");
        for (int i = 0; i < categories.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {categories[i].Name}");
        }

        var categoryChoices = Console.ReadLine().Split(',');
        var favoriteCategories = new List<Category>();
        foreach (var choice in categoryChoices)
        {
            if (int.TryParse(choice.Trim(), out int categoryId) && categoryId > 0 && categoryId <= categories.Count)
            {
                favoriteCategories.Add(categories[categoryId - 1]);
            }
        }

        var user = new User { Name = name, Email = email, FavoriteCategories = favoriteCategories };
        _userService.RegisterUser(user);
        Console.WriteLine("User registered successfully.");
    }

    private static void ViewAllCategories()
    {
        List<Category> categories = _categoryService.GetCategories();
        Console.WriteLine("All Categories:");
        foreach (var category in categories)
        {
            Console.WriteLine($"Name: {category.Name}");
        }
    }

    private static void AddCategory()
    {
        Console.Write("Enter category name: ");
        string name = Console.ReadLine();
        _categoryService.AddCategory(new Category { Name = name });
        Console.WriteLine("Category added successfully.");
    }

    private static void ViewAllUsers()
    {
        List<User> users = _userService.GetUsers();
        Console.WriteLine("All Users:");
        foreach (var user in users)
        {
            Console.WriteLine($"Name: {user.Name}, Email: {user.Email}");
        }
    }
}
