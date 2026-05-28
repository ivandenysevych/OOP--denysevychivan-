namespace MiniProject.Domain.Entities;

public class Loan
{
    public int Id { get; }

    public int BookId { get; }

    public int ReaderId { get; }

    public DateTime BorrowDate { get; }

    public DateTime DueDate { get; }

    public DateTime? ReturnDate { get; private set; }

    public bool IsActive => ReturnDate == null;

    public Loan(int id, int bookId, int readerId, int borrowDays = 14)
    {
        if (id <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(id), "Loan ID must be positive.");
        }

        if (bookId <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(bookId), "Book ID must be positive.");
        }

        if (readerId <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(readerId), "Reader ID must be positive.");
        }

        if (borrowDays <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(borrowDays), "Borrow days must be positive.");
        }

        Id = id;
        BookId = bookId;
        ReaderId = readerId;
        BorrowDate = DateTime.Now;
        DueDate = BorrowDate.AddDays(borrowDays);
        ReturnDate = null;
    }
    
    public void ReturnBook()
    {
        if (!IsActive)
        {
            throw new InvalidOperationException("Book has already been returned.");
        }

        ReturnDate = DateTime.Now;
    }

    public bool IsOverdue()
    {
        return IsActive && DateTime.Now > DueDate;
    }

    public override string ToString()
    {
        var status = IsActive ? $"Due: {DueDate:yyyy-MM-dd}" : $"Returned: {ReturnDate:yyyy-MM-dd}";
        return $"Loan ID: {Id}, Book: {BookId}, Reader: {ReaderId}, Borrowed: {BorrowDate:yyyy-MM-dd}, {status}";
    }
}
