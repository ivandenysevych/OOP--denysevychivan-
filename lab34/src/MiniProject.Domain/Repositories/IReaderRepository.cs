using MiniProject.Domain.Entities;

namespace MiniProject.Domain.Repositories;

/// <summary>
/// Interface for reader repository operations.
/// </summary>
public interface IReaderRepository
{
    /// <summary>
    /// Adds a new reader to the repository.
    /// </summary>
    /// <param name="reader">The reader to add.</param>
    void Add(Reader reader);

    /// <summary>
    /// Removes a reader from the repository by ID.
    /// </summary>
    /// <param name="readerId">The ID of the reader to remove.</param>
    /// <returns>True if the reader was removed; otherwise false.</returns>
    bool Remove(int readerId);

    /// <summary>
    /// Gets a reader by their ID.
    /// </summary>
    /// <param name="readerId">The ID of the reader to retrieve.</param>
    /// <returns>The reader if found; otherwise null.</returns>
    Reader? GetById(int readerId);

    /// <summary>
    /// Gets all readers in the repository.
    /// </summary>
    /// <returns>A list of all readers.</returns>
    List<Reader> GetAll();

    /// <summary>
    /// Updates reader information.
    /// </summary>
    /// <param name="reader">The updated reader information.</param>
    /// <returns>True if the reader was updated; otherwise false.</returns>
    bool Update(Reader reader);
}
