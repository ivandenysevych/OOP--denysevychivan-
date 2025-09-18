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
            System.Globalization.CultureInfo.CurrentCulture =
                System.Globalization.CultureInfo.InvariantCulture;

            var shapes = new List<Shape>
            {
                new Circle(3.5),
                new Rectangle(4, 7),
                new Circle(1.2),
                new Rectangle(10, 2.5),
            };

            Console.WriteLine("-- All shapes --");
            foreach (var s in shapes)
                Console.WriteLine(s.DisplayInfo());

            double totalArea = shapes.Sum(s => s.Area());
            double totalPerimeter = shapes.Sum(s => s.Perimeter());

            Console.WriteLine("\nTotal area: {0:0.###}", totalArea);
            Console.WriteLine("Total perimeter: {0:0.###}", totalPerimeter);

            var maxShape = shapes.OrderByDescending(s => s.Area()).First();
            Console.WriteLine("\nMax area shape: {0} with S={1:0.###}", maxShape.Name, maxShape.Area());
        }
    }
}
