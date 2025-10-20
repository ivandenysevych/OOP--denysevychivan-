using System;
using System.Threading;

namespace SR1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== Самостійна робота №1 (SR1) ===");
            Console.WriteLine("Узагальнений кеш з обмеженнями, видаленням старих елементів і сортуванням.\n");

            // Створюємо кеш для рядків (час життя 3 секунди)
            Cache<string> cache = new Cache<string>(TimeSpan.FromSeconds(3));

            cache.Add("Банан");
            cache.Add("Яблуко");
            cache.Add("Апельсин");
            cache.Add("Ківі");

            Console.WriteLine(">>> Початкові дані:");
            cache.Display();

            // Очікуємо 2 секунди
            Console.WriteLine("\nОчікуємо 2 секунди...");
            Thread.Sleep(2000);

            cache.Add("Груша");

            Console.WriteLine("\n>>> Після додавання нового елемента:");
            cache.Display();

            // Очікуємо ще 2 секунди, щоб перші елементи стали "старими"
            Console.WriteLine("\nОчікуємо ще 2 секунди...");
            Thread.Sleep(2000);

            cache.RemoveExpired();

            Console.WriteLine("\n>>> Після видалення старих елементів:");
            cache.Display();

            // Сортуємо за абеткою
            Console.WriteLine("\n>>> Сортування за алфавітом:");
            cache.Sort((a, b) => string.Compare(a, b));
            cache.Display();

            Console.WriteLine("\nРоботу програми завершено.");
        }
    }
}
