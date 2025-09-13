using System;

namespace lab2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Створення двох поліномів
            Polynomial p1 = new Polynomial(1, 2, 3);       // 1 + 2x + 3x^2
            Polynomial p2 = new Polynomial(3, 0, 4, 5);    // 3 + 4x^2 + 5x^3

            Console.WriteLine("p1(x) = " + p1);
            Console.WriteLine("p2(x) = " + p2);

            // Властивості
            Console.WriteLine("Степінь p1 = " + p1.Degree);
            Console.WriteLine("Старший коеф. p1 = " + p1.LeadingCoefficient);

            // Індексатор
            Console.WriteLine("p1[2] = " + p1[2]);
            p1[2] = 10;
            Console.WriteLine("Новий p1: " + p1);

            // Розширення
            p1[5] = 2;
            Console.WriteLine("p1 розширений: " + p1);

            // Оператор +
            Polynomial sum = p1 + p2;
            Console.WriteLine("p1 + p2 = " + sum);

            // Обчислення значення
            Console.WriteLine("p2(2) = " + p2.Evaluate(2));
        }
    }
}
