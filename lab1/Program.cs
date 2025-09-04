using System;

class Program
{
    static void Main(string[] args)
    {
        Figure circle = new Circle("Коло", 19);
        Console.WriteLine($"{circle.Name}: площа = {circle.GetArea()}");

        Figure square = new Square("Квадрат", 10);
        Console.WriteLine($"{square.Name}: площа = {square.GetArea()}");

        Console.ReadKey();
    }
}

abstract class Figure
{
    public Figure(string name, float radius)
    {
        Name = name;
        Radius = radius;
    }

    public string Name { get; set; }
    public float Radius { get; set; }

    public virtual double GetArea()
    {
        return 0;
    }
}

class Circle : Figure
{
    public Circle(string name, float radius) : base(name, radius) { }

    public override double GetArea()
    {
        return Math.PI * Math.Pow(Radius, 2);
    }
}

class Square : Figure
{
    public Square(string name, float side) : base(name, side) { }

    public override double GetArea()
    {
        return Radius * Radius; 
    }
}
