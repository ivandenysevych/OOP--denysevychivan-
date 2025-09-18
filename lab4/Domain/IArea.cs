// Інтерфейс: фігура має імʼя та вміє повертати свою площу.
namespace lab4.Domain
{
    public interface IArea
    {
        string Name { get; }
        double GetArea();
    }
}
