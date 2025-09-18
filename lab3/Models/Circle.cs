using System;

namespace Lab3.Models
{
    // Клас Коло. Наслідується від Shape
    public class Circle : Shape
    {
        // Властивість для зберігання радіуса
        public double Radius { get; private set; }

        // Конструктор з параметром. Викликає базовий конструктор (base)
        public Circle(double radius) : base("Circle")
        {
            // Перевірка на коректність значення
            if (radius <= 0) throw new ArgumentOutOfRangeException(nameof(radius));
            Radius = radius;
        }

        // Реалізація абстрактних методів
        public override double Area() => Math.PI * Radius * Radius;         // Площа кола
        public override double Perimeter() => 2 * Math.PI * Radius;         // Довжина кола

        // Перевизначення віртуального методу для відображення інформації
        public override string DisplayInfo()
        {
            return string.Format("{0}: S={1:0.###}, P={2:0.###} (R={3:0.###})",
                Name, Area(), Perimeter(), Radius);
        }

        // Фіналізатор (деструктор) для демонстрації
        ~Circle() { }
    }
}
