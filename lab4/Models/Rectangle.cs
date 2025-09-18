using System;

namespace Lab4.Models
{
    // Прямокутник: S = width * height
    public class Rectangle : Shape
    {
        public double Width  { get; private set; }
        public double Height { get; private set; }

        public Rectangle(double width, double height) : base("Rectangle")
        {
            if (width  <= 0) throw new ArgumentOutOfRangeException(nameof(width),  "Width must be > 0");
            if (height <= 0) throw new ArgumentOutOfRangeException(nameof(height), "Height must be > 0");
            Width  = width;
            Height = height;
        }

        public override double Area() => Width * Height;

        public override string DisplayInfo()
            => $"{Name}: S={Area():0.###} (W={Width:0.###}, H={Height:0.###})";
    }
}
