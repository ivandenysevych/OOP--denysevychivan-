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
            // Встановлюємо культуру для відображення чисел з крапкою
            System.Globalization.CultureInfo.CurrentCulture =
                System.Globalization.CultureInfo.InvariantCulture;

            // Колекція фігур. Поліморфізм: зберігаємо різні об'єкти у списку базового типу
            var shapes = new List<Shape>
            {
                new Circle(3.5),       // створення об'єкта кола
                new Rectangle(4, 7),   // створення об'єкта прямокутника
                new Circle(1.2),       // ще одне коло
                new Rectangle(10, 2.5) // ще один прямокутник
            };

            // Вивід усіх фігур
            Console.WriteLine("-- All shapes --");
            foreach (var s in shapes)
                Console.WriteLine(s.DisplayInfo());

            // Обчислення сумарної площі та периметра
            double totalArea = shapes.Sum(s => s.Area());
            double totalPerimeter = shapes.Sum(s => s.Perimeter());

            // Вивід результатів
            Console.WriteLine("\nTotal area: {0:0.###}", totalArea);
            Console.WriteLine("Total perimeter: {0:0.###}", totalPerimeter);

            // Знаходимо фігуру з найбільшою площею
            var maxShape = shapes.OrderByDescending(s => s.Area()).First();
            Console.WriteLine("\nMax area shape: {0} with S={1:0.###}", maxShape.Name, maxShape.Area());
        }
    }
}
