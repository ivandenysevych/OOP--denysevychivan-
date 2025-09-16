using System;

namespace Lab3.Models
{
    public class Rectangle : Shape
    {
        public double Width  { get; private set; }
        public double Height { get; private set; }

        public Rectangle(double width, double height) : base("Rectangle")
        {
            Width = width;
            Height = height;
        }

        public override double Area() => Width * Height;
        public override double Perimeter() => 2 * (Width + Height);

        public override string ToString()
            => $"{base.ToString()} (W={Width}, H={Height})";
    }
}
