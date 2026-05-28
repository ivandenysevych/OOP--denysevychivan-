namespace MiniProject.Domain.Entities;

public class Reader
{
    private readonly List<int> _borrowedBookIds = new();

    public int Id { get; }

    public string FullName { get; }

    public string Email { get; }

    public string PhoneNumber { get; }

    public DateTime RegistrationDate { get; }

    public IReadOnlyCollection<int> BorrowedBookIds => _borrowedBookIds.AsReadOnly();

    public Reader(int id, string fullName, string email, string phoneNumber)
    {
        if (id <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(id), "Reader ID must be positive.");
        }

        if (string.IsNullOrWhiteSpace(fullName))
        {
            throw new ArgumentException("Full name cannot be empty.", nameof(fullName));
        }

        if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
        {
            throw new ArgumentException("Valid email is required.", nameof(email));
        }

        if (string.IsNullOrWhiteSpace(phoneNumber))
        {
            throw new ArgumentException("Phone number cannot be empty.", nameof(phoneNumber));
        }

        Id = id;
        FullName = fullName;
        Email = email;
        PhoneNumber = phoneNumber;
        RegistrationDate = DateTime.Now;
    }

    public void BorrowBook(int bookId)
    {
        if (bookId <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(bookId), "Book ID must be positive.");
        }

        if (_borrowedBookIds.Contains(bookId))
        {
            throw new InvalidOperationException("Reader has already borrowed this book.");
        }

        _borrowedBookIds.Add(bookId);
    }

    public void ReturnBook(int bookId)
    {
        if (!_borrowedBookIds.Remove(bookId))
        {
            throw new InvalidOperationException("Reader does not have this book.");
        }
    }

    public int GetBorrowedBooksCount()
    {
        return _borrowedBookIds.Count;
    }

    public override string ToString()
    {
        return $"Reader: {FullName}, Email: {Email}, Phone: {PhoneNumber}, Borrowed Books: {GetBorrowedBooksCount()}";
    }
}
