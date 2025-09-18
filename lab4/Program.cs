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
            // Встановлюємо культуру для відображення чисел (щоб була крапка замість коми)
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            // Створюємо список фігур, які реалізують інтерфейс IArea
            var shapes = new List<IArea>
            {
                new Circle(3.5),      // Коло з радіусом 3.5
                new Rectangle(4, 7),  // Прямокутник зі сторонами 4 і 7
                new Circle(1.2),      // Коло з радіусом 1.2
                new Rectangle(10, 2.5)// Прямокутник зі сторонами 10 і 2.5
            };

            // Використовуємо клас AreaCalculator (композиція) для роботи зі списком фігур
            var calc = new AreaCalculator(shapes);

            Console.WriteLine("-- All shapes --");
            // Виводимо усі фігури з їхніми параметрами
            foreach (var s in shapes)
                Console.WriteLine(s);

            // Рахуємо сумарну площу всіх фігур
            double totalArea = calc.TotalArea();
            // Шукаємо фігури з мінімальною та максимальною площею
            var (minShape, maxShape) = calc.MinMax();

            Console.WriteLine();
            // Вивід результатів у консоль
            Console.WriteLine("Total area: {0:0.###}", totalArea);
            Console.WriteLine("Min area: {0} with S={1:0.###}",  minShape.Name, minShape.Area());
            Console.WriteLine("Max area: {0} with S={1:0.###}",  maxShape.Name, maxShape.Area());
        }
    }
}
