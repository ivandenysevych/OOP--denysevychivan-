using System;
using System.Collections.Generic;
using System.Globalization;
using Lab4.Models;

namespace Lab4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            var shapes = new List<IArea>
            {
                new Circle(3.5),
                new Rectangle(4, 7),
                new Circle(1.2),
                new Rectangle(10, 2.5)
            };

            var calc = new AreaCalculator(shapes);

            Console.WriteLine("-- All shapes --");
            foreach (var s in shapes)
                Console.WriteLine(s);

            double totalArea = calc.TotalArea();
            var (minShape, maxShape) = calc.MinMax();

            Console.WriteLine();
            Console.WriteLine("Total area: {0:0.###}", totalArea);
            Console.WriteLine("Min area: {0} with S={1:0.###}",  minShape.Name, minShape.Area());
            Console.WriteLine("Max area: {0} with S={1:0.###}",  maxShape.Name, maxShape.Area());
        }
    }
}
