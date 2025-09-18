namespace Lab4.Models
{
    // Контракт для фігур: імʼя + метод обчислення площі
    public interface IArea
    {
        string Name { get; }
        double Area();
    }
}
