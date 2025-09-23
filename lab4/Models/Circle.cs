using System;

namespace Lab4.Models;

public class Circle : IArea
{
    public double Radius { get; }
    public Circle(double radius)
    {
        if (radius <= 0) throw new ArgumentOutOfRangeException(nameof(radius), "Radius must be > 0.");
        Radius = radius;
    }

    public double GetArea() => Math.PI * Radius * Radius;

    public string Describe() => $"Circle: S={GetArea():0.###} (R={Radius})";
}
