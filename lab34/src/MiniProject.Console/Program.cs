using MiniProject.Application.Services;
using MiniProject.Infrastructure.Repositories;

namespace MiniProject.Console;

public class Program
{
    private static LibraryService _libraryService = null!;

    public static void Main(string[] args)
    {
        InitializeServices();
        RunMenu();
    }

    private static void InitializeServices()
    {
        var bookRepository = new InMemoryBookRepository();
        var readerRepository = new InMemoryReaderRepository();
        _libraryService = new LibraryService(bookRepository, readerRepository);
    }

    private static void RunMenu()
    {
        var running = true;

        while (running)
        {
            System.Console.Clear();
            System.Console.WriteLine("Library Management System");
            System.Console.WriteLine("1. Add Book");
            System.Console.WriteLine("2. Register Reader");
            System.Console.WriteLine("3. Borrow Book");
            System.Console.WriteLine("4. Return Book");
            System.Console.WriteLine("5. Show Books");
            System.Console.WriteLine("6. Exit");
            System.Console.Write("Select option: ");

            var choice = System.Console.ReadLine();

            try
            {
                switch (choice)
                {
                    case "1":
                        AddBook();
                        break;
                    case "2":
                        RegisterReader();
                        break;
                    case "3":
                        BorrowBook();
                        break;
                    case "4":
                        ReturnBook();
                        break;
                    case "5":
                        ShowBooks();
                        break;
                    case "6":
                        running = false;
                        break;
                    default:
                        PauseWithMessage("Invalid option.");
                        break;
                }
            }
            catch (Exception ex)
            {
                PauseWithMessage($"Error: {ex.Message}");
            }
        }
    }

    private static void AddBook()
    {
        System.Console.Clear();
        System.Console.WriteLine("--- Add Book ---");

        System.Console.Write("Title: ");
        var title = System.Console.ReadLine() ?? string.Empty;

        System.Console.Write("ISBN: ");
        var isbn = System.Console.ReadLine() ?? string.Empty;

        System.Console.Write("Author Name: ");
        var authorName = System.Console.ReadLine() ?? string.Empty;

        System.Console.Write("Publication Year: ");
        if (!int.TryParse(System.Console.ReadLine(), out var year))
        {
            throw new ArgumentException("Invalid year format.");
        }

        System.Console.Write("Pages: ");
        if (!int.TryParse(System.Console.ReadLine(), out var pages))
        {
            throw new ArgumentException("Invalid pages format.");
        }

        var book = _libraryService.AddBook(title, isbn, authorName, year, pages);
        PauseWithMessage($"Book added successfully. ID: {book.Id}");
    }

    private static void RegisterReader()
    {
        System.Console.Clear();
        System.Console.WriteLine("--- Register Reader ---");

        System.Console.Write("Full Name: ");
        var fullName = System.Console.ReadLine() ?? string.Empty;

        System.Console.Write("Email: ");
        var email = System.Console.ReadLine() ?? string.Empty;

        System.Console.Write("Phone Number: ");
        var phone = System.Console.ReadLine() ?? string.Empty;

        var reader = _libraryService.RegisterReader(fullName, email, phone);
        PauseWithMessage($"Reader registered successfully. ID: {reader.Id}");
    }

    private static void BorrowBook()
    {
        System.Console.Clear();
        System.Console.WriteLine("--- Borrow Book ---");

        var availableBooks = _libraryService.GetAvailableBooks();
        if (availableBooks.Count == 0)
        {
            PauseWithMessage("No books available for borrowing.");
            return;
        }

        System.Console.WriteLine("Available Books:");
        foreach (var book in availableBooks)
        {
            System.Console.WriteLine($"  ID: {book.Id}, Title: {book.Title}, Author: {book.Author.Name}");
        }

        System.Console.Write("Enter Book ID: ");
        if (!int.TryParse(System.Console.ReadLine(), out var bookId))
        {
            throw new ArgumentException("Invalid book ID format.");
        }

        var readers = _libraryService.GetAllReaders();
        if (readers.Count == 0)
        {
            PauseWithMessage("No readers registered in the system.");
            return;
        }

        System.Console.WriteLine();
        System.Console.WriteLine("Readers:");
        foreach (var reader in readers)
        {
            System.Console.WriteLine($"  ID: {reader.Id}, Name: {reader.FullName}");
        }

        System.Console.Write("Enter Reader ID: ");
        if (!int.TryParse(System.Console.ReadLine(), out var readerId))
        {
            throw new ArgumentException("Invalid reader ID format.");
        }

        System.Console.Write("Borrow days (default 14): ");
        var borrowDays = 14;
        if (int.TryParse(System.Console.ReadLine(), out var parsedDays))
        {
            borrowDays = parsedDays;
        }

        var loan = _libraryService.BorrowBook(bookId, readerId, borrowDays);
        PauseWithMessage($"Book borrowed successfully. Loan ID: {loan.Id}, Due: {loan.DueDate:yyyy-MM-dd}");
    }

    private static void ReturnBook()
    {
        System.Console.Clear();
        System.Console.WriteLine("--- Return Book ---");

        var activeLoans = _libraryService.GetActiveLoans();
        if (activeLoans.Count == 0)
        {
            PauseWithMessage("No active loans.");
            return;
        }

        System.Console.WriteLine("Active Loans:");
        foreach (var loan in activeLoans)
        {
            System.Console.WriteLine($"  Loan ID: {loan.Id}, Book ID: {loan.BookId}, Reader ID: {loan.ReaderId}, Due: {loan.DueDate:yyyy-MM-dd}");
        }

        System.Console.Write("Enter Loan ID: ");
        if (!int.TryParse(System.Console.ReadLine(), out var loanId))
        {
            throw new ArgumentException("Invalid loan ID format.");
        }

        _libraryService.ReturnBook(loanId);
        PauseWithMessage("Book returned successfully.");
    }

    private static void ShowBooks()
    {
        System.Console.Clear();
        System.Console.WriteLine("--- All Books ---");

        var books = _libraryService.GetAllBooks();
        if (books.Count == 0)
        {
            System.Console.WriteLine("No books in the library.");
        }
        else
        {
            foreach (var book in books)
            {
                var status = book.IsAvailable ? "Available" : "Not Available";
                System.Console.WriteLine($"  {book.Id}. {book.Title} by {book.Author.Name} ({book.PublicationYear}) - {status}");
            }
        }

        PauseWithMessage(string.Empty);
    }

    private static void PauseWithMessage(string message)
    {
        if (!string.IsNullOrWhiteSpace(message))
        {
            System.Console.WriteLine();
            System.Console.WriteLine(message);
        }

        System.Console.WriteLine();
        System.Console.WriteLine("Press any key to continue...");
        System.Console.ReadKey();
    }
}
