namespace MiniProject.Domain.Entities;

public class Author
{
    public int Id { get; }

    public string Name { get; }

    public Author(int id, string name)
    {
        if (id <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(id), "Author ID must be positive.");
        }

        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Author name cannot be empty.", nameof(name));
        }

        Id = id;
        Name = name;
    }
}
