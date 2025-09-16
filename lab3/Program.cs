using System;
using System.Collections.Generic;
using System.Linq;
using Lab3.Models;

namespace Lab3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var shapes = new List<Shape>
            {
                new Circle(3.5),
                new Rectangle(4, 7),
                new Circle(1.2),
                new Rectangle(10, 2.5),
            };

            Console.WriteLine("-- All shapes --");
            foreach (var s in shapes)
                Console.WriteLine(s);

            double totalArea = shapes.Sum(s => s.Area());
            double totalPerimeter = shapes.Sum(s => s.Perimeter());

            Console.WriteLine($"\nTotal area: {totalArea:0.###}");
            Console.WriteLine($"Total perimeter: {totalPerimeter:0.###}");

            var maxShape = shapes.OrderByDescending(s => s.Area()).First();
            Console.WriteLine($"\nMax area shape: {maxShape.Name} with S={maxShape.Area():0.###}");
        }
    }
}
