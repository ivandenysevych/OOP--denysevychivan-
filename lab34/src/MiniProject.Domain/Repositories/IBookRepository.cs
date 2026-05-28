using MiniProject.Domain.Entities;

namespace MiniProject.Domain.Repositories;

/// <summary>
/// Interface for book repository operations.
/// </summary>
public interface IBookRepository
{
    /// <summary>
    /// Adds a new book to the repository.
    /// </summary>
    /// <param name="book">The book to add.</param>
    void Add(Book book);

    /// <summary>
    /// Removes a book from the repository by ID.
    /// </summary>
    /// <param name="bookId">The ID of the book to remove.</param>
    /// <returns>True if the book was removed; otherwise false.</returns>
    bool Remove(int bookId);

    /// <summary>
    /// Gets a book by its ID.
    /// </summary>
    /// <param name="bookId">The ID of the book to retrieve.</param>
    /// <returns>The book if found; otherwise null.</returns>
    Book? GetById(int bookId);

    /// <summary>
    /// Gets all books in the repository.
    /// </summary>
    /// <returns>A list of all books.</returns>
    List<Book> GetAll();

    /// <summary>
    /// Gets all available books.
    /// </summary>
    /// <returns>A list of available books.</returns>
    List<Book> GetAvailable();

    /// <summary>
    /// Updates the availability status of a book.
    /// </summary>
    /// <param name="bookId">The ID of the book.</param>
    /// <param name="isAvailable">The new availability status.</param>
    /// <returns>True if the book was updated; otherwise false.</returns>
    bool UpdateAvailability(int bookId, bool isAvailable);
}
