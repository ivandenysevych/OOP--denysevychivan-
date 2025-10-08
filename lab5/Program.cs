﻿using System;
using lab5.Models;

namespace lab5
{
    class Program
    {
        static void Main()
        {
            var repo = new Repository<Receipt>();

            try
            {
                // створення чеків
                var r1 = new Receipt(1);
                r1.AddItem(new LineItem("Milk", 3, 40m));
                r1.AddItem(new LineItem("Bread", 5, 50m));
                r1.AddItem(new LineItem("Cheese", 2, 250m));

                var r2 = new Receipt(2);
                r2.AddItem(new LineItem("TV", 1, 1200m));
                r2.AddItem(new LineItem("Headphones", 1, 900m));
                r2.AddItem(new LineItem("Cable", 2, 100m));

                repo.Add(r1);
                repo.Add(r2);

                // вивід усіх чеків
                Console.WriteLine("-- All Receipts --");
                foreach (var receipt in repo.All())
                {
                    Console.WriteLine(receipt);
                    Console.WriteLine();
                }

                // LINQ: пошук чеків із сумою > 2000
                Console.WriteLine("-- Receipts with discount (>2000) --");
                foreach (var receipt in repo.Where(r => r.HasDiscount()))
                {
                    Console.WriteLine($"Receipt #{receipt.Id} total: {receipt.DiscountedTotal():0.00} ₴");
                }

                // приклад винятку
                Console.WriteLine("\n-- Test invalid item --");
                var bad = new LineItem("BadItem", -2, 100m); // викличе помилку
                r1.AddItem(bad);
            }
            catch (InvalidItemException ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("\nРоботу програми завершено.");
            }
        }
    }
}
