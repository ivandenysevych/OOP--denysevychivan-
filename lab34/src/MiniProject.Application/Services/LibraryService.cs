using MiniProject.Domain.Entities;
using MiniProject.Domain.Repositories;

namespace MiniProject.Application.Services;

public class LibraryService
{
    private readonly IBookRepository _bookRepository;
    private readonly IReaderRepository _readerRepository;
    private readonly List<Loan> _loans;
    private int _nextBookId = 1;
    private int _nextAuthorId = 1;
    private int _nextReaderId = 1;
    private int _nextLoanId = 1;

    public LibraryService(IBookRepository bookRepository, IReaderRepository readerRepository)
    {
        _bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
        _readerRepository = readerRepository ?? throw new ArgumentNullException(nameof(readerRepository));
        _loans = new List<Loan>();
    }

    public Book AddBook(string title, string isbn, string authorName, int publicationYear, int pages)
    {
        var author = new Author(_nextAuthorId, authorName);
        var book = new Book(_nextBookId, title, isbn, author, publicationYear, pages);
        _bookRepository.Add(book);

        _nextBookId++;
        _nextAuthorId++;

        return book;
    }

    public Reader RegisterReader(string fullName, string email, string phoneNumber)
    {
        var reader = new Reader(_nextReaderId, fullName, email, phoneNumber);
        _readerRepository.Add(reader);

        _nextReaderId++;

        return reader;
    }

    public Loan BorrowBook(int bookId, int readerId, int borrowDays = 14)
    {
        var book = _bookRepository.GetById(bookId) ?? throw new KeyNotFoundException($"Book with ID {bookId} not found.");
        var reader = _readerRepository.GetById(readerId) ?? throw new KeyNotFoundException($"Reader with ID {readerId} not found.");

        if (!book.IsAvailable)
        {
            throw new InvalidOperationException($"Book '{book.Title}' is not available for borrowing.");
        }

        var loan = new Loan(_nextLoanId, bookId, readerId, borrowDays);
        _loans.Add(loan);

        reader.BorrowBook(bookId);
        _bookRepository.UpdateAvailability(bookId, isAvailable: false);
        _readerRepository.Update(reader);

        _nextLoanId++;

        return loan;
    }

    public void ReturnBook(int loanId)
    {
        var loan = _loans.FirstOrDefault(l => l.Id == loanId)
            ?? throw new KeyNotFoundException($"Loan with ID {loanId} not found.");

        loan.ReturnBook();

        _bookRepository.UpdateAvailability(loan.BookId, isAvailable: true);

        var reader = _readerRepository.GetById(loan.ReaderId);
        if (reader != null)
        {
            reader.ReturnBook(loan.BookId);
            _readerRepository.Update(reader);
        }
    }

    public List<Book> GetAvailableBooks()
    {
        return _bookRepository.GetAvailable();
    }

    public List<Book> GetAllBooks()
    {
        return _bookRepository.GetAll();
    }

    public List<Reader> GetAllReaders()
    {
        return _readerRepository.GetAll();
    }

    public List<Loan> GetActiveLoans()
    {
        return _loans.Where(l => l.IsActive).ToList();
    }

    public List<Loan> GetOverdueLoans()
    {
        return _loans.Where(l => l.IsOverdue()).ToList();
    }
}
