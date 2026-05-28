using MiniProject.Domain.Entities;
using MiniProject.Domain.Repositories;

namespace MiniProject.Infrastructure.Repositories;

public class InMemoryBookRepository : IBookRepository
{
    private readonly Dictionary<int, Book> _books = new();

    public void Add(Book book)
    {
        if (book == null)
        {
            throw new ArgumentNullException(nameof(book));
        }

        if (_books.ContainsKey(book.Id))
        {
            throw new InvalidOperationException($"Book with ID {book.Id} already exists.");
        }

        _books[book.Id] = book;
    }

    public bool Remove(int bookId)
    {
        return _books.Remove(bookId);
    }

    public Book? GetById(int bookId)
    {
        return _books.TryGetValue(bookId, out var book) ? book : null;
    }

    public List<Book> GetAll()
    {
        return _books.Values.ToList();
    }

    public List<Book> GetAvailable()
    {
        return _books.Values.Where(b => b.IsAvailable).ToList();
    }

    public bool UpdateAvailability(int bookId, bool isAvailable)
    {
        var book = GetById(bookId);
        if (book == null)
        {
            return false;
        }

        if (book.IsAvailable == isAvailable)
        {
            return true;
        }

        if (isAvailable)
        {
            book.MarkAsReturned();
        }
        else
        {
            book.MarkAsBorrowed();
        }

        return true;
    }
}
