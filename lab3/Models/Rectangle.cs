using System;

namespace Lab3.Models
{
    // Клас Прямокутник. Наслідується від Shape

    public class Rectangle : Shape
    {
        // Властивості для ширини та висоти
        public double Width  { get; private set; }
        public double Height { get; private set; }

        // Конструктор з параметрами. Викликає базовий конструктор (base)
        public Rectangle(double width, double height) : base("Rectangle")
        {
            // Перевірка на коректність значень
            if (width  <= 0) throw new ArgumentOutOfRangeException(nameof(width));
            if (height <= 0) throw new ArgumentOutOfRangeException(nameof(height));
            Width = width;
            Height = height;
        }

        // Реалізація абстрактних методів
        public override double Area() => Width * Height;                 // Площа прямокутника
        public override double Perimeter() => 2 * (Width + Height);      // Периметр прямокутника

        // Перевизначення віртуального методу для відображення інформації
        public override string DisplayInfo()
        {
            return string.Format("{0}: S={1:0.###}, P={2:0.###} (W={3:0.###}, H={4:0.###})",
                Name, Area(), Perimeter(), Width, Height);
        }

        // Фіналізатор (деструктор) для демонстрації
        ~Rectangle() { }
    }
}
