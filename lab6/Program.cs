﻿using System;
using System.Collections.Generic;
using System.Linq;
using lab6.Models;

// Власний делегат (приклад арифметичної операції)
public delegate int Operation(int x, int y);

namespace lab6
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // ===== 1) Делегати: анонімний метод + лямбда =====
            // Анонімний метод (delegate)
            Operation addAnonymous = delegate (int a, int b) { return a + b; }; // 👈 анонімний метод

            // Лямбда-вираз
            Operation multiplyLambda = (a, b) => a * b; // 👈 лямбда-вираз

            Console.WriteLine("== Делегати ==");
            Console.WriteLine($"addAnonymous(7, 5) = {addAnonymous(7, 5)}");
            Console.WriteLine($"multiplyLambda(7, 5) = {multiplyLambda(7, 5)}");
            Console.WriteLine();

            // ===== 2) Стандартні делегати: Func, Action, Predicate =====
            // Func<T1,T2,TReturn> — функція з результатом
            Func<decimal, decimal, decimal> applyDiscount = (price, rate) => price * (1 - rate); // 👈 Func

            // Action<T> — процедура без повернення значення
            Action<Product> print = p => Console.WriteLine(p.ToString()); // 👈 Action

            // Predicate<T> — булева перевірка
            Predicate<Product> isExpensive = p => p.Price >= 1000m; // 👈 Predicate

            // ===== 3) Дані =====
            var products = new List<Product>
            {
                new Product("Milk",       42m,   "Grocery"),
                new Product("Bread",      28m,   "Grocery"),
                new Product("Coffee",     320m,  "Grocery"),
                new Product("Headphones", 1499m, "Electronics"),
                new Product("Keyboard",   899m,  "Electronics"),
                new Product("TV",         12999m,"Electronics"),
                new Product("Apple",      15m,   "Grocery"),
            };

            Console.WriteLine("== Початковий список товарів ==");
            products.ForEach(print);
            Console.WriteLine();

            // ===== 4) LINQ з лямбда-виразами =====
            // Фільтрація за ціною (вимога завдання)
            var filteredByPrice = products.Where(p => p.Price >= 100m).ToList();

            // Пошук найдорожчого (вимога завдання)
            var mostExpensive = products.OrderByDescending(p => p.Price).First();

            // Середня вартість (вимога завдання)
            var averagePrice = products.Average(p => p.Price);

            // Додатково: фільтр Predicate
            var expensiveProducts = products.Where(p => isExpensive(p)).ToList();

            // Додатково: Select + перетворення (імена з цінами зі знижкою 10%)
            var discountedNames = products
                .Select(p => $"{p.Name} → {applyDiscount(p.Price, 0.10m):0.00} ₴ (−10%)")
                .ToList();

            // Додатково: OrderBy
            var orderedByCategoryThenPrice = products
                .OrderBy(p => p.Category)
                .ThenBy(p => p.Price)
                .ToList();

            // Додатково: Aggregate — підсумкова сума
            var totalSum = products.Aggregate(0m, (acc, p) => acc + p.Price);

            // ===== 5) Вивід результатів =====
            Console.WriteLine("== Фільтрація за ціною >= 100 ==");
            filteredByPrice.ForEach(print);
            Console.WriteLine();

            Console.WriteLine("== Найдорожчий товар ==");
            Console.WriteLine(mostExpensive);
            Console.WriteLine($"Середня ціна: {averagePrice:0.00} ₴");
            Console.WriteLine();

            Console.WriteLine("== Дорогі товари (Predicate: price >= 1000) ==");
            expensiveProducts.ForEach(print);
            Console.WriteLine();

            Console.WriteLine("== Знижка 10% (Func) ==");
            discountedNames.ForEach(s => Console.WriteLine(s));
            Console.WriteLine();

            Console.WriteLine("== Сортування: Category -> Price (OrderBy/ThenBy) ==");
            orderedByCategoryThenPrice.ForEach(print);
            Console.WriteLine();

            Console.WriteLine($"Загальна сума (Aggregate): {totalSum:0.00} ₴");
            Console.WriteLine("\nРоботу програми завершено.");
        }
    }
}
