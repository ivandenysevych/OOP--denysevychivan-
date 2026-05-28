namespace MiniProject.Domain.Entities;

public class Book : LibraryItem
{
    public string ISBN { get; }

    public Author Author { get; }

    public int Pages { get; }

    public Book(int id, string title, string isbn, Author author, int publicationYear, int pages)
        : base(id, title, publicationYear)
    {
        if (string.IsNullOrWhiteSpace(isbn) || isbn.Length < 10)
        {
            throw new ArgumentException("ISBN must be at least 10 characters long.", nameof(isbn));
        }

        if (author == null)
        {
            throw new ArgumentNullException(nameof(author), "Author cannot be null.");
        }

        if (pages <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(pages), "Number of pages must be positive.");
        }

        ISBN = isbn;
        Author = author;
        Pages = pages;
    }

    public override string ToString()
    {
        return $"Book: {Title} by {Author.Name}, ISBN: {ISBN}, Pages: {Pages}, {base.ToString()}";
    }
}
