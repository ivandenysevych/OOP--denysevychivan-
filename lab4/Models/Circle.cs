using System;

namespace Lab4.Models
{
    // Коло: S = π * r^2
    public class Circle : Shape
    {
        public double Radius { get; private set; }

        public Circle(double radius) : base("Circle")
        {
            if (radius <= 0) throw new ArgumentOutOfRangeException(nameof(radius), "Radius must be > 0");
            Radius = radius;
        }

        public override double Area() => Math.PI * Radius * Radius;

        public override string DisplayInfo()
            => $"{Name}: S={Area():0.###} (R={Radius:0.###})";
    }
}
