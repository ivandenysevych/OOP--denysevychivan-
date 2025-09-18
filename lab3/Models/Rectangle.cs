using System;

namespace Lab3.Models
{
    /// <summary>Другий похідний клас від Shape. Override + фіналізатор.</summary>
    public class Rectangle : Shape
    {
        public double Width  { get; private set; }
        public double Height { get; private set; }

        public Rectangle(double width, double height) : base("Rectangle")
        {
            if (width  <= 0) throw new ArgumentOutOfRangeException(nameof(width));
            if (height <= 0) throw new ArgumentOutOfRangeException(nameof(height));
            Width = width;
            Height = height;
        }

        public override double Area() => Width * Height;
        public override double Perimeter() => 2 * (Width + Height);

        public override string DisplayInfo()
        {
            return string.Format("{0}: S={1:0.###}, P={2:0.###} (W={3:0.###}, H={4:0.###})",
                Name, Area(), Perimeter(), Width, Height);
        }

        ~Rectangle() { } // фіналізатор для демонстрації
    }
}
