using System;

namespace Lab3.Models
{
    /// <summary>Похідний клас від Shape. Показує base(...), override.</summary>
    public class Circle : Shape
    {
        public double Radius { get; private set; }

        public Circle(double radius) : base("Circle")
        {
            if (radius <= 0) throw new ArgumentOutOfRangeException(nameof(radius));
            Radius = radius;
        }

        public override double Area() => Math.PI * Radius * Radius;
        public override double Perimeter() => 2 * Math.PI * Radius;

        public override string DisplayInfo()
        {
            return string.Format("{0}: S={1:0.###}, P={2:0.###} (R={3:0.###})",
                Name, Area(), Perimeter(), Radius);
        }

        ~Circle() { } // фіналізатор для демонстрації (нічого не робить)
    }
}
