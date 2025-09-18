using System;

namespace lab4.Domain
{
    // Конкретна фігура: КОЛО. Формула S = π * r^2
    public sealed class Circle : Shape
    {
        public double Radius { get; }

        public Circle(double radius) : base($"Circle(r={radius})")
        {
            if (radius <= 0) throw new ArgumentOutOfRangeException(nameof(radius), "Радіус має бути > 0");
            Radius = radius;
        }

        public override double GetArea() => Math.PI * Radius * Radius;
    }
}
