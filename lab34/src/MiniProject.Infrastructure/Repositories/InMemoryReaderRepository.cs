using MiniProject.Domain.Entities;
using MiniProject.Domain.Repositories;

namespace MiniProject.Infrastructure.Repositories;

/// <summary>
/// In-memory implementation of the reader repository.
/// </summary>
public class InMemoryReaderRepository : IReaderRepository
{
    private readonly Dictionary<int, Reader> _readers = new();

    /// <summary>
    /// Adds a new reader to the repository.
    /// </summary>
    public void Add(Reader reader)
    {
        if (reader == null)
        {
            throw new ArgumentNullException(nameof(reader));
        }

        if (_readers.ContainsKey(reader.Id))
        {
            throw new InvalidOperationException($"Reader with ID {reader.Id} already exists.");
        }

        _readers[reader.Id] = reader;
    }

    /// <summary>
    /// Removes a reader from the repository by ID.
    /// </summary>
    public bool Remove(int readerId)
    {
        return _readers.Remove(readerId);
    }

    /// <summary>
    /// Gets a reader by their ID.
    /// </summary>
    public Reader? GetById(int readerId)
    {
        return _readers.TryGetValue(readerId, out var reader) ? reader : null;
    }

    /// <summary>
    /// Gets all readers in the repository.
    /// </summary>
    public List<Reader> GetAll()
    {
        return _readers.Values.ToList();
    }

    /// <summary>
    /// Updates reader information.
    /// </summary>
    public bool Update(Reader reader)
    {
        if (reader == null)
        {
            throw new ArgumentNullException(nameof(reader));
        }

        if (!_readers.ContainsKey(reader.Id))
        {
            return false;
        }

        _readers[reader.Id] = reader;
        return true;
    }
}
