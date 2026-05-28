using MiniProject.Application.Services;
using MiniProject.Infrastructure.Repositories;

namespace MiniProject.Tests;

public class LibraryServiceTests
{
    private readonly LibraryService _libraryService;

    public LibraryServiceTests()
    {
        var bookRepository = new InMemoryBookRepository();
        var readerRepository = new InMemoryReaderRepository();
        _libraryService = new LibraryService(bookRepository, readerRepository);
    }

    [Fact]
    public void BookCreation_WithValidData_Succeeds()
    {
        var book = _libraryService.AddBook(
            "Clean Code",
            "9780132350884",
            "Robert C. Martin",
            2008,
            464);

        Assert.Equal("Clean Code", book.Title);
        Assert.True(book.IsAvailable);
    }

    [Fact]
    public void BookCreation_WithInvalidData_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() =>
            _libraryService.AddBook("Bad Book", "123", "Author", 2020, 100));
    }

    [Fact]
    public void ReaderRegistration_WithValidData_Succeeds()
    {
        var reader = _libraryService.RegisterReader("Ivan Petrenko", "ivan@example.com", "+380501112233");

        Assert.Equal("Ivan Petrenko", reader.FullName);
        Assert.Equal(0, reader.GetBorrowedBooksCount());
    }

    [Fact]
    public void BorrowBook_WithExistingBookAndReader_Succeeds()
    {
        var book = _libraryService.AddBook("DDD", "9780321125217", "Eric Evans", 2003, 560);
        var reader = _libraryService.RegisterReader("Oksana", "oksana@example.com", "123456789");

        var loan = _libraryService.BorrowBook(book.Id, reader.Id);

        Assert.Equal(book.Id, loan.BookId);
        Assert.False(book.IsAvailable);
    }

    [Fact]
    public void ReturnBook_ForActiveLoan_Succeeds()
    {
        var book = _libraryService.AddBook("Refactoring", "9780201485677", "Martin Fowler", 1999, 448);
        var reader = _libraryService.RegisterReader("Nazar", "nazar@example.com", "9999999");
        var loan = _libraryService.BorrowBook(book.Id, reader.Id);

        _libraryService.ReturnBook(loan.Id);

        Assert.True(book.IsAvailable);
        Assert.False(loan.IsActive);
    }
}
