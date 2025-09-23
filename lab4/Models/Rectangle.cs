using System;

namespace Lab4.Models;

public class Rectangle : IArea
{
    public double Width { get; }
    public double Height { get; }

    public Rectangle(double width, double height)
    {
        if (width <= 0) throw new ArgumentOutOfRangeException(nameof(width), "Width must be > 0.");
        if (height <= 0) throw new ArgumentOutOfRangeException(nameof(height), "Height must be > 0.");
        Width = width;
        Height = height;
    }

    public double GetArea() => Width * Height;

    public string Describe() => $"Rectangle: S={GetArea():0.###} (W={Width}, H={Height})";
}
