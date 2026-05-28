namespace MiniProject.Domain.Entities;

public abstract class LibraryItem
{
    public int Id { get; }

    public string Title { get; }

    public int PublicationYear { get; }

    public bool IsAvailable { get; private set; }

    protected LibraryItem(int id, string title, int publicationYear)
    {
        if (id <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(id), "Item ID must be positive.");
        }

        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException("Title cannot be empty.", nameof(title));
        }

        if (publicationYear < 1000 || publicationYear > DateTime.Now.Year)
        {
            throw new ArgumentOutOfRangeException(nameof(publicationYear), "Publication year must be between 1000 and current year.");
        }

        Id = id;
        Title = title;
        PublicationYear = publicationYear;
        IsAvailable = true;
    }

    public void MarkAsBorrowed()
    {
        if (!IsAvailable)
        {
            throw new InvalidOperationException("Item is already borrowed.");
        }

        IsAvailable = false;
    }

    public void MarkAsReturned()
    {
        if (IsAvailable)
        {
            throw new InvalidOperationException("Item is already available.");
        }

        IsAvailable = true;
    }

    public override string ToString()
    {
        return $"ID: {Id}, Title: {Title}, Year: {PublicationYear}, Available: {IsAvailable}";
    }
}
