using System;

namespace lab4.Domain
{
    // Конкретна фігура: ПРЯМОКУТНИК. Формула S = width * height
    public sealed class Rectangle : Shape
    {
        public double Width  { get; }
        public double Height { get; }

        public Rectangle(double width, double height) : base($"Rectangle({width}x{height})")
        {
            if (width  <= 0) throw new ArgumentOutOfRangeException(nameof(width),  "Ширина має бути > 0");
            if (height <= 0) throw new ArgumentOutOfRangeException(nameof(height), "Висота має бути > 0");
            Width  = width;
            Height = height;
        }

        public override double GetArea() => Width * Height;
    }
}
